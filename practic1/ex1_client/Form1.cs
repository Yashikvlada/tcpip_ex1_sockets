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

namespace ex1_client
{
    public partial class Form_client : Form
    {
        private Socket _clientSocket = null;
        public Form_client()
        {
            InitializeComponent();
            textBox_console.Enabled = false;

            OnOffSendInfo();
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
                if(_clientSocket.Connected)
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
            }
            catch(Exception ex)
            {
                textBox_console.Text += "\r\n"+ex.Message;
            }

        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (_clientSocket == null || !_clientSocket.Connected)
            {
                textBox_console.Text += "\r\nCan't send! Connect to server first!";
                return;
            }

            string sendMsg = textBox_message.Text;
            _clientSocket.Send(Encoding.Unicode.GetBytes(sendMsg));
            textBox_console.Text += $"\r\nCLIENT: {sendMsg}";
        }
    }
}
