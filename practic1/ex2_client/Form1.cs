﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ex2_client
{
    public partial class Form_client : Form
    {
        private Socket _clientSocket = null;
        public Form_client()
        {
            InitializeComponent();
            textBox_console.ReadOnly = true;

            FormClosed += Form_client_FormClosed;

            comboBox_query.Items.Add("date");
            comboBox_query.Items.Add("time");
            comboBox_query.SelectedIndex = 0;
        }

        private void Form_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnection();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (_clientSocket != null)
            {
                if (_clientSocket.Connected)
                    _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            try
            {
                button_connect.Enabled = false;

                IPAddress ip = IPAddress.Parse(textBox_ip.Text);
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(textBox_port.Text));
                _clientSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.IP);

                _clientSocket.Connect(endPoint);
                textBox_console.Text += "\r\nConnected!";

                SendMessage(comboBox_query.SelectedItem.ToString());

                string msgFromServer = ReceiveMessage();
                textBox_console.Text += $"\r\nВ {DateTime.Now.Hour}:{DateTime.Now.Second} от [{ip}] получена строка: {msgFromServer}";

                CloseConnection(); 

            }
            catch (Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
                button_connect.Enabled = true;
            }

        }
        private string ReceiveMessage()
        {
            string result = string.Empty;

            byte[] buff = new byte[1024];
            int len = _clientSocket.Receive(buff);

            result = Encoding.Unicode.GetString(buff, 0, len);

            return result;
        }
        private void SendMessage(string msg)
        {
            _clientSocket.Send(Encoding.Unicode.GetBytes(msg));
        }
        private void CloseConnection()
        {
            if (_clientSocket != null)
            {
                if (_clientSocket.Connected)
                    _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }

            textBox_console.Text += $"\r\nConnection closed!";
            button_connect.Enabled = true;
        }

    }
}
