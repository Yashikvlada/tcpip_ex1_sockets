﻿namespace ex3_client
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
            this.button_send = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_bot = new System.Windows.Forms.CheckBox();
            this.button_load_bot_base = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_send.Location = new System.Drawing.Point(4, 281);
            this.button_send.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(292, 35);
            this.button_send.TabIndex = 17;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(4, 157);
            this.label_message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(74, 20);
            this.label_message.TabIndex = 16;
            this.label_message.Text = "Message";
            // 
            // textBox_message
            // 
            this.textBox_message.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_message.Location = new System.Drawing.Point(4, 182);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_message.Size = new System.Drawing.Size(292, 89);
            this.textBox_message.TabIndex = 15;
            this.textBox_message.Text = "Hello world!";
            // 
            // button_connect
            // 
            this.button_connect.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_connect.Location = new System.Drawing.Point(4, 117);
            this.button_connect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(292, 35);
            this.button_connect.TabIndex = 14;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(4, 56);
            this.label_port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(38, 20);
            this.label_port.TabIndex = 13;
            this.label_port.Text = "Port";
            // 
            // textBox_port
            // 
            this.textBox_port.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_port.Location = new System.Drawing.Point(4, 81);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(292, 26);
            this.textBox_port.TabIndex = 12;
            this.textBox_port.Text = "1024";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(4, 0);
            this.label_ip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(24, 20);
            this.label_ip.TabIndex = 11;
            this.label_ip.Text = "IP";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_ip.Location = new System.Drawing.Point(4, 25);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(292, 26);
            this.textBox_ip.TabIndex = 10;
            this.textBox_ip.Text = "127.0.0.1";
            // 
            // textBox_console
            // 
            this.textBox_console.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_console.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.textBox_console.Location = new System.Drawing.Point(312, 5);
            this.textBox_console.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ReadOnly = true;
            this.textBox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_console.Size = new System.Drawing.Size(794, 544);
            this.textBox_console.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_console, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 554);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_ip, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_send, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox_ip, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_message, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label_message, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label_port, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_port, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button_connect, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_bot, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.button_load_bot_base, 0, 9);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 544);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBox_bot
            // 
            this.checkBox_bot.AutoSize = true;
            this.checkBox_bot.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_bot.Location = new System.Drawing.Point(3, 324);
            this.checkBox_bot.Name = "checkBox_bot";
            this.checkBox_bot.Size = new System.Drawing.Size(294, 24);
            this.checkBox_bot.TabIndex = 19;
            this.checkBox_bot.Text = "Chat bot";
            this.checkBox_bot.UseVisualStyleBackColor = true;
            this.checkBox_bot.CheckedChanged += new System.EventHandler(this.checkBox_bot_CheckedChanged);
            // 
            // button_load_bot_base
            // 
            this.button_load_bot_base.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_load_bot_base.Location = new System.Drawing.Point(3, 354);
            this.button_load_bot_base.Name = "button_load_bot_base";
            this.button_load_bot_base.Size = new System.Drawing.Size(294, 35);
            this.button_load_bot_base.TabIndex = 20;
            this.button_load_bot_base.Text = "Load bot base";
            this.button_load_bot_base.UseVisualStyleBackColor = true;
            this.button_load_bot_base.Click += new System.EventHandler(this.button_load_bot_base_Click);
            // 
            // Form_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_client";
            this.Text = "Client";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox_bot;
        private System.Windows.Forms.Button button_load_bot_base;
    }
}

