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

namespace ex1_server
{
    public partial class Form_server : Form
    {
        private Socket _serverSocket = null;
        private Socket _clientSocket = null;
        public Form_server()
        {
            InitializeComponent();
            textBox_console.Enabled = false;

            OnOffSendInfo();

            GetHostIp();
        }
        private void GetHostIp()
        {
            string hostName = Dns.GetHostName();
            var ip = Dns.GetHostAddresses(hostName);
            comboBox_ip.Items.AddRange(ip);           
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            if (_serverSocket != null)
            {
                _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
            }
            try
            {
                IPAddress ip = IPAddress.Parse(comboBox_ip.Text);
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
            }
            catch(Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
            }
        }
        private void OnOffSendInfo()
        {
            textBox_message.Enabled = !textBox_message.Enabled;
            button_send.Enabled = !button_send.Enabled;            
        }
        private void OnOffServerInfo()
        {
            comboBox_ip.Enabled = !comboBox_ip.Enabled;
            textBox_port.Enabled = !textBox_port.Enabled;
            button_listen.Enabled = !button_listen.Enabled;
        }

        private void AcceptThreadFunct()
        {
            try
            {
                BeginInvoke(new MethodInvoker(OnOffServerInfo));

                Invoke(new MethodInvoker(
                    ()=> { textBox_console.Text += "\r\nWaiting...";}));
                
                _clientSocket = _serverSocket.Accept();

                Invoke(new MethodInvoker(
                    () => { textBox_console.Text += "\r\nClient connected!"; }));               
            }
            catch(Exception ex)
            {
                Invoke(new MethodInvoker(
                    () => { textBox_console.Text += "\r\n" + ex.Message; }));                
            }
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            if (_clientSocket == null)
            {
                textBox_console.Text += "\r\nCan't send. Start server first!";
                return;
            }
            try
            {
                string sendMsg = textBox_message.Text;
                _clientSocket.Send(Encoding.Unicode.GetBytes(sendMsg));
            }
            catch(Exception ex)
            {
                textBox_console.Text += "\r\n" + ex.Message;
            }
            finally
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
        }
    }
}
