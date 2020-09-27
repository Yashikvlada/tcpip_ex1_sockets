using System;
using System.Windows.Forms;
using ChatBot;
using SocketsForEx3;

namespace ex3_client
{
    public partial class Form_client : Form
    {
        private ClientSide _clientSocket;
        private Bot _bot;

        public Form_client()
        {
            InitializeComponent();

            _clientSocket = new ClientSide();
            _clientSocket.StopWord = "bye";

            BindUItoClientSide();

            FormClosed += Form_client_FormClosed;

            _bot = new Bot(_clientSocket.Send);
        }
        private void BindUItoClientSide()
        {
            //привязываем консоль winforms к логеру объекта ClientSide
            textBox_console.DataBindings.Add("Text", _clientSocket, "Log", false, DataSourceUpdateMode.OnPropertyChanged);

            //привязка к обратному значению IsConnected объекта ClientSide

            //если IsConnected==false, значит нужно включить контролы связанные с 
            //созданием нового подключения, поэтому нужен ReverseBoolProperty
            Binding ipBinding = new Binding("Enabled", _clientSocket, "IsConnected");
            ipBinding.Parse += ReverseBoolProperty;
            ipBinding.Format += ReverseBoolProperty;
            textBox_ip.DataBindings.Add(ipBinding);

            Binding portBinding = new Binding("Enabled", _clientSocket, "IsConnected");
            portBinding.Parse += ReverseBoolProperty;
            portBinding.Format += ReverseBoolProperty;
            textBox_port.DataBindings.Add(portBinding);

            Binding connectBinding = new Binding("Enabled", _clientSocket, "IsConnected");
            connectBinding.Parse += ReverseBoolProperty;
            connectBinding.Format += ReverseBoolProperty;
            button_connect.DataBindings.Add(connectBinding);

            ////привязка к прямому значению IsConnected объекта ClientSide.
            ////если IsConnected==true , то панель с отправкой можно включить и наоборот
            Binding msgBinding = new Binding("Enabled", _clientSocket, "IsConnected");
            textBox_message.DataBindings.Add(msgBinding);

            Binding sendBinding = new Binding("Enabled", _clientSocket, "IsConnected");
            button_send.DataBindings.Add(sendBinding);
        }
        private void ReverseBoolProperty(object s, ConvertEventArgs e)
        {
            e.Value = !(bool)e.Value;
        }
        private void Form_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            _clientSocket.CloseConnection();
        }
        private void button_connect_Click(object sender, EventArgs e)
        {
            _clientSocket.Start(textBox_ip.Text, textBox_port.Text);
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            _clientSocket.Send(textBox_message.Text);
        }

        private void checkBox_bot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_bot.Checked)
                    _bot.BotOn();
                else
                    _bot.BotOff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                checkBox_bot.Checked = !checkBox_bot.Checked;
            }
        }

        private void button_load_bot_base_Click(object sender, EventArgs e)
        {
            string fileName = "phrases.txt";

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFile.FileName;
                }
                else
                {
                    MessageBox.Show("Choose file pls!");
                    return;
                }
            }

            try
            {
                _bot.ReadWords(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
   
}
