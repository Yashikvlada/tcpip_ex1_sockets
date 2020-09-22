using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace practic2_client
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

                Console.WriteLine("Подключено!");
                Console.WriteLine("Узнать дату или время? enter: 'date' or 'time'");
                string menu = Console.ReadLine();

                if (sock.Connected)
                {
                    //отправляем
                    string sendMsg = menu;
                    sock.Send(Encoding.Unicode.GetBytes(sendMsg));

                    //получаем
                    byte[] buff = new byte[1024];
                    int len;

                    len = sock.Receive(buff);
                    string recMsg = Encoding.Unicode.GetString(buff, 0, len);

                    Console.WriteLine(recMsg);
                }
                else
                    Console.WriteLine("Error!");
            }
            catch (Exception ex)
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
