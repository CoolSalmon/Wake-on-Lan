using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Wake_on_Lan
{
    public class Program
    {

        
        static byte[] macaddrss;

        static IPHostEntry serverentry = Dns.GetHostEntry("google.com");
        static IPAddress ipaddress = serverentry.AddressList[0];
        static IPEndPoint ep = new IPEndPoint(ipaddress, 10);
        static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public static byte[] packetdata;


        public static void Main() {
            macaddrss[0] = 00;
            macaddrss[1] = 26;
            macaddrss[2] = 160;
            macaddrss[3] = 93;
            macaddrss[4] = 251;
            macaddrss[5] = 213;
            for (int i = 0; i < 6; i++)
            {
                packetdata[i] = 0xFF;
            }

            for (int i = 1; i <= 16; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    packetdata[i * 6 + j] = macaddrss[j];
                }
            }
            sock.SendTo(packetdata, ep);
        }
    
    }


}
