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

        public UsersManager parentUserManager { get; set; }

        private StreamWriter sw;
        private StreamReader reader;

        private bool working = false;
        public User(UserDataModel data, TcpClient tcpClient, UsersManager userManager)
        {
            parentUserManager = userManager;
            dataModel = data;
            socket = tcpClient;
            reader = new StreamReader(socket.GetStream());
            sw = new StreamWriter(socket.GetStream());
            sw.AutoFlush = true;
        }

        public string GetUsername()
        {
            return dataModel.username;
        }

        internal void SendLogInSuccessMessage()
        {
            Task.Run(() => { SendMessageToClient("200"); });
            AcceptMessages();
        }

        public void SendMessageToClient(string message)
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

        internal void SendPasswordIncorrectMessage()
        {
            Task.Run(() => { SendMessageToClient("Password Incorrect"); });
        }

        public void AcceptMessages()
        {
            working = true;
            while (working)
            {
                string tempReq = reader.ReadLine();

                var userReq =  UserRequest.ParseFromString(tempReq);

                switch (userReq.reqType)
                {
                    case 1:
                        {
                            Task.Run(() => { SendMessageToClient(parentUserManager.GetAllUsersAsString()); });
                            break;
                        }
                }
            }
        }
    }
}
