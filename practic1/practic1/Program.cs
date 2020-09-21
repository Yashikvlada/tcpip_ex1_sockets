using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace practic1_client
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

            try
            {
                sock.Connect(endPoint);

                if (sock.Connected)
                {
                    //отправляем
                    string sendMsg = "Привет сервер!";
                    sock.Send(Encoding.Unicode.GetBytes(sendMsg));

                    //получаем
                    byte[] buff = new byte[1024];
                    int len;
                   
                    len = sock.Receive(buff);
                    string recMsg = Encoding.Unicode.GetString(buff, 0, len);
                  
                    string outputMsg = $"В {DateTime.Now.Hour}:{DateTime.Now.Second} от [{ip}] получена строка: {recMsg}";
                    Console.WriteLine(outputMsg);
                }
                else
                    Console.WriteLine("Error!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

    }
}
