using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ex1_server
{
    public partial class Form_server : Form
    {
        private Socket _serverSocket = null;
        private Socket _clientSocket = null;
        public Form_server()
        {
            InitializeComponent();
            textBox_console.ReadOnly = true;

            FormClosing += Form_server_FormClosing;
        }

        private void Form_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            if (_serverSocket != null)
            {
                if(_serverSocket.Connected)
                    _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
            }
            try
            {
                button_listen.Enabled = false;

                IPAddress ip = IPAddress.Parse(textBox_ip.Text);
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(textBox_port.Text));
                _serverSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.IP);

                _serverSocket.Bind(endPoint);
                _serverSocket.Listen(1);

                textBox_console.Text += "\r\nServer on!";

                Thread listenThread = 
                    new Thread(new ThreadStart(AcceptThreadFunct));
                listenThread.Start();
            }
            catch(Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
                button_listen.Enabled = true;
            }
        }
        private void AcceptThreadFunct()
        {
            try
            {
                textBox_console.Text += "\r\nWaiting...";
                
                _clientSocket = _serverSocket.Accept();

                textBox_console.Text += "\r\nClient connected!";

                SendMessage("Привет клиент!");

                string msgFromClient = ReceiveMessage();
                textBox_console.Text += $"\r\nВ {DateTime.Now.Hour}:{DateTime.Now.Second} от " +
                    $"[{_clientSocket.RemoteEndPoint}] получена строка: {msgFromClient}";

                CloseConnection();

            }
            catch(Exception ex)
            {
                 textBox_console.Text += "\r\n" + ex.Message;                
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

                textBox_console.Text += $"\r\nClient connection closed!";
                

            }
            if (_serverSocket != null)
            {
                if (_serverSocket.Connected)
                    _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
                textBox_console.Text += $"\r\nServer closed!";
            }
        }

    }
}
