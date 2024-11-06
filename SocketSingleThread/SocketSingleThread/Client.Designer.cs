namespace SocketSingleThread
{
    partial class Client
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
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Receive = new System.Windows.Forms.RichTextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Accpet = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(524, 345);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(395, 289);
            this.richTextBox_Send.TabIndex = 23;
            this.richTextBox_Send.Text = "";
            // 
            // richTextBox_Receive
            // 
            this.richTextBox_Receive.Location = new System.Drawing.Point(524, 85);
            this.richTextBox_Receive.Name = "richTextBox_Receive";
            this.richTextBox_Receive.Size = new System.Drawing.Size(395, 236);
            this.richTextBox_Receive.TabIndex = 22;
            this.richTextBox_Receive.Text = "";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(258, 457);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 38);
            this.button_Send.TabIndex = 21;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(91, 457);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(92, 38);
            this.button_Clear.TabIndex = 20;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(258, 318);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 40);
            this.button_Close.TabIndex = 19;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Accpet
            // 
            this.button_Accpet.Location = new System.Drawing.Point(91, 318);
            this.button_Accpet.Name = "button_Accpet";
            this.button_Accpet.Size = new System.Drawing.Size(92, 40);
            this.button_Accpet.TabIndex = 18;
            this.button_Accpet.Text = "Connect";
            this.button_Accpet.UseVisualStyleBackColor = true;
            this.button_Accpet.Click += new System.EventHandler(this.button_Accpet_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(191, 137);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(231, 28);
            this.textBox_Port.TabIndex = 16;
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Location = new System.Drawing.Point(191, 85);
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(231, 28);
            this.textBox_Addr.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Address";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 718);
            this.Controls.Add(this.richTextBox_Send);
            this.Controls.Add(this.richTextBox_Receive);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Accpet);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Addr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Receive;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Accpet;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}