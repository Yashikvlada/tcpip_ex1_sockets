namespace ex3_server
{
    partial class Form_server
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
            this.comboBox_ip = new System.Windows.Forms.ComboBox();
            this.button_send = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_listen = new System.Windows.Forms.Button();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_ip
            // 
            this.comboBox_ip.FormattingEnabled = true;
            this.comboBox_ip.Location = new System.Drawing.Point(12, 28);
            this.comboBox_ip.Name = "comboBox_ip";
            this.comboBox_ip.Size = new System.Drawing.Size(183, 21);
            this.comboBox_ip.TabIndex = 27;
            this.comboBox_ip.Text = "127.0.0.1";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(12, 217);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(183, 23);
            this.button_send.TabIndex = 26;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(12, 136);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(50, 13);
            this.label_message.TabIndex = 25;
            this.label_message.Text = "Message";
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(12, 152);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_message.Size = new System.Drawing.Size(183, 59);
            this.textBox_message.TabIndex = 24;
            this.textBox_message.Text = "Hello world!";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(12, 93);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(183, 23);
            this.button_listen.TabIndex = 23;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(12, 51);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 22;
            this.label_port.Text = "Port";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(12, 67);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(183, 20);
            this.textBox_port.TabIndex = 21;
            this.textBox_port.Text = "1024";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(12, 12);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(17, 13);
            this.label_ip.TabIndex = 20;
            this.label_ip.Text = "IP";
            // 
            // textBox_console
            // 
            this.textBox_console.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_console.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox_console.Location = new System.Drawing.Point(212, 12);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_console.Size = new System.Drawing.Size(318, 228);
            this.textBox_console.TabIndex = 19;
            // 
            // Form_server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 244);
            this.Controls.Add(this.comboBox_ip);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.textBox_console);
            this.Name = "Form_server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ip;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.TextBox textBox_console;
    }
}

