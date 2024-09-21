namespace SocketApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtReceivedMessages = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReceivedMessages
            // 
            this.txtReceivedMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedMessages.Location = new System.Drawing.Point(30, 40);
            this.txtReceivedMessages.Name = "txtReceivedMessages";
            this.txtReceivedMessages.Size = new System.Drawing.Size(625, 35);
            this.txtReceivedMessages.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(713, 40);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(281, 26);
            this.txtMessage.TabIndex = 1;
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnStartServer.Location = new System.Drawing.Point(219, 94);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(239, 54);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Connect to Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Location = new System.Drawing.Point(713, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Location = new System.Drawing.Point(219, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 601);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtReceivedMessages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceivedMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

