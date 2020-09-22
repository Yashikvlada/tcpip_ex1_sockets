namespace ex1_client
{
    partial class Form_client
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_console
            // 
            this.textBox_console.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_console.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox_console.Location = new System.Drawing.Point(212, 9);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_console.Size = new System.Drawing.Size(318, 228);
            this.textBox_console.TabIndex = 0;
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(12, 25);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(183, 20);
            this.textBox_ip.TabIndex = 1;
            this.textBox_ip.Text = "127.0.0.1";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(12, 9);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(17, 13);
            this.label_ip.TabIndex = 2;
            this.label_ip.Text = "IP";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(12, 48);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 4;
            this.label_port.Text = "Port";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(12, 64);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(183, 20);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "1024";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(12, 90);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(183, 23);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(12, 133);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(50, 13);
            this.label_message.TabIndex = 7;
            this.label_message.Text = "Message";
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(12, 149);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_message.Size = new System.Drawing.Size(183, 59);
            this.textBox_message.TabIndex = 6;
            this.textBox_message.Text = "Hello world!";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(12, 214);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(183, 23);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // Form_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 248);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.textBox_console);
            this.Name = "Form_client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_send;
    }
}

