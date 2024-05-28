using Opc.UaFx.Client;
using System;

namespace ImpetusLabs
{
    public static class OpcClientManager
    {
        private static OpcClient client;
        private static string serverUrl;
        private static bool isConnected = false;

        public static bool IsConnected => isConnected;

        public static void Connect(string url)
        {
            if (client == null || !isConnected || serverUrl != url)
            {
                Disconnect(); // Ensure previous client is disconnected
                client = new OpcClient(url);
                client.Connect();
                isConnected = true;
                serverUrl = url;
            }
        }

        public static void Disconnect()
        {
            if (client != null && isConnected)
            {
                client.Disconnect();
                isConnected = false;
                client = null;
            }
        }

        public static object ReadNode(string nodeId)
        {
            if (client == null || !isConnected)
                throw new InvalidOperationException("Client is not connected.");

            return client.ReadNode(nodeId).Value;
        }

        public static void WriteNode(string nodeId, object value)
        {
            if (client == null || !isConnected)
                throw new InvalidOperationException("Client is not connected.");

            client.WriteNode(nodeId, value);
        }
    }
}
