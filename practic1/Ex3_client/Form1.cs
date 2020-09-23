using System;
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
using System.Threading;

namespace Ex3_client
{
    public partial class Form_client : Form
    {
        private Socket _clientSocket = null;
        private Color _baseConsoleClr;
        private Color _clientConsoleClr;
        private Color _serverConsoleClr;
        public Form_client()
        {
            InitializeComponent();
            _baseConsoleClr = textBox_console.ForeColor;
            _clientConsoleClr = Color.LawnGreen;
            _serverConsoleClr = Color.DarkRed;

            textBox_console.ReadOnly = true;

            OnOffSendInfo();
            FormClosed += Form_client_FormClosed;
        }

        private void Form_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnection();
        }

        private void OnOffConnectInfo()
        {
            textBox_ip.Enabled = !textBox_ip.Enabled;
            textBox_port.Enabled = !textBox_port.Enabled;
            button_connect.Enabled = !button_connect.Enabled;
        }
        private void OnOffSendInfo()
        {
            textBox_message.Enabled = !textBox_message.Enabled;
            button_send.Enabled = !button_send.Enabled;
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
                IPAddress ip = IPAddress.Parse(textBox_ip.Text);
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(textBox_port.Text));
                _clientSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.IP);

                _clientSocket.Connect(endPoint);
                textBox_console.Text += "\r\nConnected!";

                OnOffConnectInfo();
                OnOffSendInfo();

                Thread receiveThread = new Thread(new ThreadStart(ReceiveThreadFunct));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
            }

        }
        private void ReceiveThreadFunct()
        {
            while (_clientSocket != null && _clientSocket.Connected)
            {
                byte[] buff = new byte[1024];
                int len = _clientSocket.Receive(buff);

                if (len == 0)
                    break;

                string recMsg = $"\r\n[{DateTime.Now}] TO ME: {Encoding.Unicode.GetString(buff, 0, len)}";

                textBox_console.Text += recMsg;
            }
            CloseConnection();
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            if (_clientSocket == null || !_clientSocket.Connected)
            {
                textBox_console.Text += "\r\nCan't send! Connect to server first!";
                return;
            }
            if (textBox_message.Text == string.Empty)
                return;

            try
            {
                string sendMsg = textBox_message.Text;
                _clientSocket.Send(Encoding.Unicode.GetBytes(sendMsg));

                textBox_console.Text += $"\r\n[{DateTime.Now}] I: {sendMsg}";
            }
            catch (Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
            }
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

            OnOffSendInfo();
            OnOffConnectInfo();
        }
    }
}
