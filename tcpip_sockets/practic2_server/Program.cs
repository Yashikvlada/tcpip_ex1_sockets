using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace practic2_server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, 1024);
            Socket sock = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);
            
            sock.Bind(endPoint);
            sock.Listen(1);
            Console.WriteLine("Server on!");

            Socket clientSock = null;

            try
            {
                clientSock = sock.Accept();
                Console.WriteLine($"Client [{clientSock.RemoteEndPoint}] connected!");

                //получаем
                byte[] buff = new byte[1024];
                int len;

                len = clientSock.Receive(buff);
                string recMsg = Encoding.Unicode.GetString(buff, 0, len);

                string sendMsg = string.Empty;

                if (recMsg == "date")
                    sendMsg = $"{DateTime.Now.Day}d:{DateTime.Now.Month}m:{DateTime.Now.Year}y";
                else if (recMsg == "time")
                    sendMsg = $"{DateTime.Now.Hour}h:{DateTime.Now.Minute}m:{DateTime.Now.Second}s";
                else
                    sendMsg = "Incorrect command!";

                //отправляем
                clientSock.Send(Encoding.Unicode.GetBytes(sendMsg));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                clientSock?.Shutdown(SocketShutdown.Both);
                clientSock?.Close();
            }

        }
    }
}
