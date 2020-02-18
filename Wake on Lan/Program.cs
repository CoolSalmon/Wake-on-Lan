using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Wake_on_Lan
{
    public class Program
    {

       
        // Setting up variables   
        static byte[] macaddrss = new byte[6];
        public static byte[] packetdata = new byte[102];

        // Getting the domain's IP and opening a socket
        static IPHostEntry serverentry = Dns.GetHostEntry("www.google.com");
        static IPAddress ipaddress = serverentry.AddressList[0];
        static IPEndPoint ep = new IPEndPoint(ipaddress, 7);
        static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        


        public static void Main() {
            
         // Enter here your mac address
            macaddrss[0] = 0x00;
            macaddrss[1] = 0x00;
            macaddrss[2] = 0x00;
            macaddrss[3] = 0x00;
            macaddrss[4] = 0x00;
            macaddrss[5] = 0x00;

         // Makes the MagicPacket
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
         
         // Sends the packet   
            sock.SendTo(packetdata, ep);
        }
    
    }


}
