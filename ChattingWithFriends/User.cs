using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChattingWithFriends
{
    internal class User
    {
        public UserDataModel dataModel{ get; set; }

        public TcpClient socket { get; set; }

        private StreamWriter sw;
        private StreamReader sr;

        public User(UserDataModel data, TcpClient tcpClient)
        {
            dataModel = data;
            socket = tcpClient;
            sr = new StreamReader(socket.GetStream());
            sw = new StreamWriter(socket.GetStream());
            sw.AutoFlush = true;
        }

        public string GetUsername()
        {
            return dataModel.username;
        }

        internal void SendOkMessage()
        {
            Task.Run(() => { SendMessageToClient("200"); });
        }

        private void SendMessageToClient(string message)
        {
            try
            {
                sw.WriteLine(message);
            }
            catch
            {
                MessageBox.Show($"{dataModel.username} got a prblem");
            }
        }
    }
}
