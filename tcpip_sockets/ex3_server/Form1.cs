using System;
using System.Windows.Forms;

namespace ex3_server
{
    public partial class Form_server : Form
    {
        private ServerSide _serverSocket;
        public Form_server()
        {
            InitializeComponent();

            FormClosing += Form_server_FormClosing;

            _serverSocket = new ServerSide();

            BindUItoClientSide();

            GetHostIp();
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

    }
}
