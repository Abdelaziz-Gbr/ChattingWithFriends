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
            Task.Run(() => { WriteToClient("200"); });
            AcceptMessages();
        }

        public void WriteToClient(string message)
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
            Task.Run(() => { WriteToClient("Password Incorrect"); });
        }

        public async void AcceptMessages()
        {
            working = true;
            while (working)
            {
                string tempReq = await reader.ReadLineAsync();

                var userReq =  UserRequest.ParseFromString(tempReq);

                switch (userReq.reqType)
                {
                    case 1:
                        {
                            //update client list for the user.
                            Task.Run(() => { WriteToClient("1#" +parentUserManager.GetAllUsersAsString()); });
                            break;
                        }
                    case 2:
                        {
                            //send message from user
                            MessageDataModel msg = ParseMessage(userReq.reqBody);
                            parentUserManager.ForwardMessage(msg, dataModel.username);
                            break;
                        }
                    case 3:
                        {
                            //aknoldejment of recievement.
                            break;
                        }
                }
            }
        }

        private MessageDataModel ParseMessage(string reqBody)
        {
            string[] data = reqBody.Split("$");
            string msgID = data[0];
            string toUser = data[1];
            string msg = data[2];
            return new MessageDataModel { id = int.Parse(msgID), username = toUser, body = msg };
           
        }
    }
}
