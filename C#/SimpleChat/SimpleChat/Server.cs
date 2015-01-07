using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SimpleChat
{
    class Server
    {
        static void Main(string[] args)
        {
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listeningSocket.Bind(new IPEndPoint(0, 1994));
            listeningSocket.Listen(0);//listen to local connections

            Socket acc = listeningSocket.Accept();//creates a new connection with the same IP/ports than the initial on

            byte[] accBuffer = Encoding.Default.GetBytes("Hello client, I just saw your connection :-)");
            acc.Send(accBuffer, 0, accBuffer.Length,0);

            accBuffer = new byte[255];

            int rec = acc.Receive(accBuffer, 0, accBuffer.Length, 0);

            Array.Resize(ref accBuffer, rec);

            Console.WriteLine("Received {0}", Encoding.Default.GetString(accBuffer));

            listeningSocket.Close();
            acc.Close();

            Console.Read();


        }
    }
}
