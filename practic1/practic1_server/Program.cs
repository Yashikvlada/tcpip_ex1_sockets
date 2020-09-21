using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace practic1_server
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

            Socket clientSock=null;

            try
            {
                clientSock = sock.Accept();
                Console.WriteLine("Client connected!");

                //получаем
                byte[] buff = new byte[1024];
                int len;

                len = clientSock.Receive(buff);
                string recMsg = Encoding.Unicode.GetString(buff, 0, len);

                string outputMsg = $"В {DateTime.Now.Hour}:{DateTime.Now.Second} от " +
                    $"[{clientSock.RemoteEndPoint}] получена строка: {recMsg}";
                Console.WriteLine(outputMsg);

                //отправляем
                string sendMsg = "Привет клиент!";
                clientSock.Send(Encoding.Unicode.GetBytes(sendMsg));

            }
            catch(Exception ex)
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
