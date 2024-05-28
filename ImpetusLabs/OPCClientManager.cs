using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Windows.Forms;

namespace ImpetusLabs
{
    public class OpcConnectionManager
    {
        private OpcClient opcClient;
        private bool isConnected;

        public OpcConnectionManager()
        {
            isConnected = false;
        }

        public void Connect(string serverUrl)
        {
            try
            {
                opcClient = new OpcClient(serverUrl);
                opcClient.Connect();
                isConnected = true;
                MessageBox.Show("Connected to OPC Server!");
            }
            catch (Exception ex)
            {
                isConnected = false;
                MessageBox.Show("Failed to connect to OPC Server: " + ex.Message);
            }
        }

        public void Disconnect()
        {
            if (opcClient != null && isConnected)
            {
                opcClient.Disconnect();
                isConnected = false;
                MessageBox.Show("Disconnected from OPC Server.");
            }
        }

        public bool IsConnected()
        {
            return isConnected;
        }
    }
}
