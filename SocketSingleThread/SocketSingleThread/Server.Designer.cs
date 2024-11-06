namespace SocketSingleThread
{
    partial class Server
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.comBox_Clients = new System.Windows.Forms.ComboBox();
            this.button_Accpet = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.richTextBox_Receive = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clients";
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(186, 69);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(231, 28);
            this.textBox_Addr.TabIndex = 3;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(186, 121);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(231, 28);
            this.textBox_Port.TabIndex = 4;
            // 
            // comBox_Clients
            // 
            this.comBox_Clients.FormattingEnabled = true;
            this.comBox_Clients.Location = new System.Drawing.Point(186, 183);
            this.comBox_Clients.Name = "comBox_Clients";
            this.comBox_Clients.Size = new System.Drawing.Size(231, 26);
            this.comBox_Clients.TabIndex = 5;
            this.comBox_Clients.SelectedIndexChanged += new System.EventHandler(this.comBox_Clients_SelectedIndexChanged);
            // 
            // button_Accpet
            // 
            this.button_Accpet.Location = new System.Drawing.Point(86, 302);
            this.button_Accpet.Name = "button_Accpet";
            this.button_Accpet.Size = new System.Drawing.Size(75, 42);
            this.button_Accpet.TabIndex = 6;
            this.button_Accpet.Text = "Recive";
            this.button_Accpet.UseVisualStyleBackColor = true;
            this.button_Accpet.Click += new System.EventHandler(this.button_Accpet_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(253, 302);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(87, 42);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(86, 441);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 44);
            this.button_Clear.TabIndex = 8;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(253, 441);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(76, 44);
            this.button_Send.TabIndex = 9;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // richTextBox_Receive
            // 
            this.richTextBox_Receive.Location = new System.Drawing.Point(519, 69);
            this.richTextBox_Receive.Name = "richTextBox_Receive";
            this.richTextBox_Receive.Size = new System.Drawing.Size(395, 236);
            this.richTextBox_Receive.TabIndex = 10;
            this.richTextBox_Receive.Text = "";
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(519, 329);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(395, 289);
            this.richTextBox_Send.TabIndex = 11;
            this.richTextBox_Send.Text = "";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 719);
            this.Controls.Add(this.richTextBox_Send);
            this.Controls.Add(this.richTextBox_Receive);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Accpet);
            this.Controls.Add(this.comBox_Clients);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Addr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.ComboBox comBox_Clients;
        private System.Windows.Forms.Button button_Accpet;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Receive;
        private System.Windows.Forms.RichTextBox richTextBox_Send;
    }
}