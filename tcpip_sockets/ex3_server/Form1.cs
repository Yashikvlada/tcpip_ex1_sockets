using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ex3_server
{
    public partial class Form_server : Form
    {
        private ServerSide _serverSocket;
        private Bot _bot;
        public Form_server()
        {
            InitializeComponent();

            FormClosing += Form_server_FormClosing;

            _serverSocket = new ServerSide();

            BindUItoClientSide();

            GetHostIp();

            _bot = new Bot(_serverSocket.Send);
            _bot.ReadWords("phrases.txt");
        }

        private void Form_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serverSocket.CloseConnection();
        }
        
        private void BindUItoClientSide()
        {
            //привязываем консоль winforms к логеру объекта ClientSide
            textBox_console.DataBindings.Add("Text", _serverSocket, "Log", false, DataSourceUpdateMode.OnPropertyChanged);

            //привязка к обратному значению IsConnected объекта ClientSide

            //если IsConnected==false, значит нужно включить контролы связанные с 
            //созданием нового подключения, поэтому нужен ReverseBoolProperty
            Binding ipBinding = new Binding("Enabled", _serverSocket, "IsConnected");
            ipBinding.Parse += ReverseBoolProperty;
            ipBinding.Format += ReverseBoolProperty;
            comboBox_ip.DataBindings.Add(ipBinding);

            Binding portBinding = new Binding("Enabled", _serverSocket, "IsConnected");
            portBinding.Parse += ReverseBoolProperty;
            portBinding.Format += ReverseBoolProperty;
            textBox_port.DataBindings.Add(portBinding);

            Binding connectBinding = new Binding("Enabled", _serverSocket, "IsConnected");
            connectBinding.Parse += ReverseBoolProperty;
            connectBinding.Format += ReverseBoolProperty;
            button_listen.DataBindings.Add(connectBinding);

            ////привязка к прямому значению IsConnected объекта ClientSide.
            ////если IsConnected==true , то панель с отправкой можно включить и наоборот
            Binding msgBinding = new Binding("Enabled", _serverSocket, "IsConnected");
            textBox_message.DataBindings.Add(msgBinding);

            Binding sendBinding = new Binding("Enabled", _serverSocket, "IsConnected");
            button_send.DataBindings.Add(sendBinding);
        }
        private void ReverseBoolProperty(object s, ConvertEventArgs e)
        {
            e.Value = !(bool)e.Value;
        }
        
        private void GetHostIp()
        {
            string hostName = System.Net.Dns.GetHostName();
            var ip = System.Net.Dns.GetHostAddresses(hostName);
            comboBox_ip.Items.AddRange(ip);
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            _serverSocket.Listen(comboBox_ip.Text, textBox_port.Text);
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            _serverSocket.Send(textBox_message.Text);           
        }

        private void checkBox_bot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_bot.Checked)
                _bot.BotOn();
            else
                _bot.BotOff();
            
        }
    }
    public class Bot
    {
        public delegate void SendMsgDelegate(string msg);
        private SendMsgDelegate _sendMsg;
        private List<string> _phrases;
        private bool _isOn;
        public Bot(SendMsgDelegate sendMsg)
        {
            _phrases = new List<string>();
            _sendMsg = sendMsg;           
        }
        public void ReadWords(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    _phrases.Add(sr.ReadLine());
                }
            }
        }
        public void BotOn()
        {
            if (_phrases.Count == 0)
                throw new ApplicationException("Empty bot base! (try to use Bot.ReadWords first)!");

            _isOn = true;

            Thread botThread = new Thread(new ThreadStart(BotWorkingThread));
            botThread.Start();
        }
        private void BotWorkingThread()
        {
            Random rnd = new Random(new Guid().GetHashCode());

            double elapsedTime=0;
            while (_isOn)
            {
                if (elapsedTime == 0)
                {
                    elapsedTime = rnd.Next(1000000, 4000000);

                    int index = rnd.Next(0, _phrases.Count - 1);
                    _sendMsg(_phrases[index]);
                }

                --elapsedTime;
            }
        }
        public void BotOff()
        {
            _isOn = false;
        }
    }
}
