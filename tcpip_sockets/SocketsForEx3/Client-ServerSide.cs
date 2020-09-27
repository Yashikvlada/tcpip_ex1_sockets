using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SocketsForEx3
{
    public abstract class CommonSide : INotifyPropertyChanged
    {
        protected string _log;
        protected Socket _clientSocket;
        protected bool _isConnected = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public string StopWord { get; set; }
        /// <summary>
        /// Свойство с уведомлением (можно забайндить в wf, wpf)
        /// </summary>
        public string Log
        {
            get => _log;
            set
            {
                if (_log != value)
                {
                    _log = value + $" :[{DateTime.Now}]\r\n";
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Свойство с уведомлением (можно забайндить в wf, wpf)
        /// </summary>
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged();
                }
            }
        }

        /// ///////////////////////
        public abstract void Start(string serverIp, string serverPort);
        /// <summary>
        /// Получение сообщения в Log, необходимо использовать в отдельном потоке
        /// </summary>
        protected void ReceiveThreadFunct()
        {
            while (_clientSocket != null && _clientSocket.Connected)
            {
                byte[] buff = new byte[1024];
                int len = _clientSocket.Receive(buff);

                if (len == 0)
                    break;

                string recMsg = Encoding.Unicode.GetString(buff, 0, len);
                Log += $"TO ME: {recMsg}";

                if (recMsg == StopWord)
                {
                    Log += $"Stop word [{recMsg}] received!";
                    break;
                }
            }
            CloseConnection();
            IsConnected = false;

        }
        public void Send(string msg)
        {
            if (_clientSocket == null || !_clientSocket.Connected)
            {
                Log += "Can't send. Not connected!";
                return;
            }
            if (msg == string.Empty)
                return;
            try
            {
                _clientSocket.Send(Encoding.Unicode.GetBytes(msg));
                Log += $"I: {msg}";
            }
            catch (Exception ex)
            {
                Log += ex.Message;
            }
        }
        public virtual void CloseConnection()
        {
            if (_clientSocket != null)
            {
                if (_clientSocket.Connected)
                    _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }

            Log += "Connection closed!";
            IsConnected = false;
        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ServerSide : CommonSide
    {
        private Socket _serverSocket;
        /// //////////////////////////

        /// <summary>
        /// Listen and Accept one client (in new thread)
        /// </summary>
        public override void Start(string serverIp, string serverPort)
        {
            if (_serverSocket != null)
            {
                if (_serverSocket.Connected)
                    _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
            }
            try
            {
                IPAddress ip = IPAddress.Parse(serverIp);
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(serverPort));
                _serverSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.IP);

                _serverSocket.Bind(endPoint);
                _serverSocket.Listen(/*maxHosts=*/1);

                Log += "Server on!";

                Thread listenThread =
                    new Thread(new ThreadStart(AcceptThreadFunct));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                Log += ex.Message;
            }
        }
        private void AcceptThreadFunct()
        {
            try
            {
                Log += "Waiting...";

                _clientSocket = _serverSocket.Accept();

                Log += "Client connected!";

                IsConnected = true;

                ReceiveThreadFunct();
            }
            catch (Exception ex)
            {
                Log += ex.Message;
            }
        }
        public override void CloseConnection()
        {
            base.CloseConnection();

            if (_serverSocket != null)
            {
                if (_serverSocket.Connected)
                    _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
                Log += "Server closed!";
            }
        }
    }
    public class ClientSide : CommonSide
    {
        /// <summary>
        /// Connect to server
        /// </summary>
        public override void Start(string serverIp, string serverPort)
        {
            if (_clientSocket != null)
            {
                if (_clientSocket.Connected)
                    _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            try
            {
                IPAddress ip = IPAddress.Parse(serverIp);
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(serverPort));
                _clientSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.IP);

                _clientSocket.Connect(endPoint);
                Log += "Connected!";
                IsConnected = true;

                Thread receiveThread = new Thread(new ThreadStart(ReceiveThreadFunct));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Log += ex.Message;
            }
        }
    }
}
