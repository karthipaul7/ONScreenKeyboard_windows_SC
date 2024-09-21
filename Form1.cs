using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace SocketApp
{
    public partial class Form1 : Form
    {
        private TcpListener _listener;
        private Thread _listenerThread;
        private const int Port = 5000;
        private bool isBroadcasting = false;
        private HttpListener httpListener;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void StartHttpServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            Console.WriteLine("Listening for connections...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                // Send a message to confirm the app is running on this PC
                string message = "App is running";
                byte[] data = Encoding.ASCII.GetBytes(Environment.MachineName);
                stream.Write(data, 0, data.Length);

                client.Close();
            }
        }

        private void StartServer()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
           // AppendText("Server started and waiting for a connection...");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                AppendText(message);

                // Send acknowledgment to the client
               // string response = "Message received";
               // byte[] responseBytes = Encoding.ASCII.GetBytes(response);
               // stream.Write(responseBytes, 0, responseBytes.Length);

                client.Close();
            }
        }

        private void AppendText(string text)
        {
            var specialCharacters = new HashSet<String> { "+", "^", "%", "~", "(", ")", "{", "}", "[", "]" };

            if (specialCharacters.Contains(text))
            {
                SendKeys.SendWait("{" + text + "}");
            }
            else
            {
                SendKeys.SendWait(text);
            }
            
        }

        // Helper method to escape special characters
        private string EscapeSpecialCharacters(string input, HashSet<char> specialChars)
        {
            string result = "";

            foreach (char c in input)
            {
                if (specialChars.Contains(c))
                {
                    result += "{" + c + "}";
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

       
        // Function to get the local IPv4 address
        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener?.Stop();
            _listenerThread?.Abort();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
             _listenerThread = new Thread(StartServer);
             _listenerThread.IsBackground = true;
             _listenerThread.Start();
             btnStartServer.Enabled = false;
            MessageBox.Show("Connected");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = "192.168.0.105"; // IP address of the Kotlin server
            int port = 8080; // Port number where the Kotlin server is listening
            string message = txtMessage.Text; // Message to send (from a TextBox)

            try
            {
                // Create a TcpClient and connect to the server
                using (TcpClient client = new TcpClient("192.168.0.105", 8080))

                {
                    // Convert message to bytes
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    // Get the stream for writing
                    using (NetworkStream stream = client.GetStream())
                    {
                        // Write data to the stream
                        stream.Write(data, 0, data.Length);
                       // MessageBox.Show("Message sent to the server");

                        // Optionally, read a response from the server
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string response = reader.ReadLine();
                           // MessageBox.Show("Response from server: " + response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            _listenerThread = new Thread(StartHttpServer);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
            button2.Enabled = false;
        }
    }
}
