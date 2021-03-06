using Lidgren.Network;
using System;

namespace Client
{
    class Client
    {
        private NetClient client;

        public void StartClient()
        {
            var config = new NetPeerConfiguration("hej");
            config.AutoFlushSendQueue = false;
            client = new NetClient(config);
            client.Start();

            string ip = "localhost";
            int port = 14242;
            client.Connect(ip, port);
        }

        public void SendMessage(string text)
        {
            Console.WriteLine(text);
            NetOutgoingMessage message = client.CreateMessage(text);
            
            NetSendResult nsr = client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            client.FlushSendQueue();
        }

        public void Disconnect()
        {
            client.Disconnect("Bye");
        }
    }
}
