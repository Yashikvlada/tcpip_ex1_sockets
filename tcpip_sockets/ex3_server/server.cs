using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace ex3_server
{
    class ServerSide : INotifyPropertyChanged
    {
        private string _log;
        private Socket _serverSocket;
        private Socket _clientSocket;
        private bool _isConnected = false;


        public event PropertyChangedEventHandler PropertyChanged;

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

        public ServerSide()
        {

        }
        public void Listen(string serverIp, string serverPort, int maxHosts = 1)
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
                _serverSocket.Listen(maxHosts);

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
        private void ReceiveThreadFunct()
        {
            while (_clientSocket != null && _clientSocket.Connected)
            {
                byte[] buff = new byte[1024];
                int len = _clientSocket.Receive(buff);

                if (len == 0)
                    break;

                string recMsg = $"TO ME: {Encoding.Unicode.GetString(buff, 0, len)}";
                Log += recMsg;
            }
            CloseConnection();
            IsConnected = false;

        }
        public void Send(string msg)
        {
            if (_clientSocket == null || !_clientSocket.Connected)
            {
                Log += "Can't send. No client connected!";
                return;
            }
            try
            {
                if (msg == string.Empty)
                    return;

                _clientSocket.Send(Encoding.Unicode.GetBytes(msg));
                Log += $"I: {msg}";
            }
            catch (Exception ex)
            {
                Log += ex.Message;
            }
        }
        public void CloseConnection()
        {
            if (_clientSocket != null)
            {
                if (_clientSocket.Connected)
                    _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();

                Log += "Client connection closed!";

            }
            if (_serverSocket != null)
            {
                if (_serverSocket.Connected)
                    _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
                Log += "Server closed!";
            }

            IsConnected = false;
        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
