using System.Net;
using System.Net.Sockets;
using ClientDataModels;
using ClientDataBase;
namespace ChattingWithFriends_Client
{
    internal class Connection
    {
        private int port = 45000;
        private TcpClient serverSocket;

        private StreamReader reader;
        private StreamWriter writer;

        public event Action? OnLoggedIn;

        private bool accepting = false;

        public string? username { get; private set; }

        public event Action OnNewClientList;

        public Connection()
        {
            serverSocket = new TcpClient();
            serverSocket.Connect(IPAddress.Loopback, port);
            reader = new StreamReader(serverSocket.GetStream());
            writer = new StreamWriter(serverSocket.GetStream());
            writer.AutoFlush = true;
        }

        public void LogIn(string username, string password)
        {
            DataBase.InitDB("username");
            SendPacketToServer(ServerCommunicationTemplate.GetLogInTemplate(username, password).ToString());
            string? serverResponse = ReadServerPacket();
            if (serverResponse != null)
                if (serverResponse.Equals("200"))
                {
                    this.username = username;
                    //getClientsListFromServer();
                    OnLoggedIn?.Invoke();
                }
                else
                    MessageBox.Show($"{serverResponse}", "Try Again");
            else
                MessageBox.Show("Failed To send credentials to the server", "Server Error");
        }


        private void SendPacketToServer(string packet)
        {
            try
            {
                writer.WriteLine(packet);
            }
            catch 
            {
                MessageBox.Show("Server Disconnected");
                Application.Exit();
            }
        }
        private void SendPacketToServerAsync(string packet)
        {
            try
            {
                Task writingToServer = writer.WriteLineAsync(packet);
            }
            catch
            {
                MessageBox.Show("Server Disconnected");
                Application.Exit();
            }
        }


        private string ReadServerPacket()
        {
            try
            {
                string incommingPacket = reader.ReadLine();
                return incommingPacket;
            }
            catch
            {
                MessageBox.Show("Server Down");
                Application.Exit();
            }
            return null;

        }

        public List<Friend> GetAllFriends()
        {
            var friends = DataBase.GetFriends();
            return friends;
        }

        public async void AcceptIncommingMessages() 
        {
            accepting = true;
            while(accepting)
            {
                string? serverPacket = await reader.ReadLineAsync();
                if (serverPacket != null) 
                {
                    //message could be new client list or a new message from a client.
                    //todo
                    string[] packet = serverPacket.Split('#');
                    int header = int.Parse(packet[0]);
                    if(header == 1)
                    {
                        //new client list
                        string[] friends = packet[1].Split('$');
                        foreach(string friend in friends)
                        {
                            string[] friendData = friend.Split(',');
                            string friendID = friendData[0];
                            string friendUserName = friendData[1];
                            DataBase.AddIfNotExists(new Friend { id = int.Parse(friendID) , username = friendUserName});
                        }
                        OnNewClientList?.Invoke();

                    }
                    else if (header == 2)
                    {
                        //message recieved
                        string[] data = packet[1].Split('$');
                        string sender = data[0];
                        string msgBody = data[1];
                        MessageBox.Show($"{sender}: {msgBody}");
                        OnMessageRecieved(sender, msgBody);
                    }
                }
            }
        }

        private void OnMessageRecieved(string sender_username, string message)
        {
            //JUST SHOW THE MESSAGE FOR NOW
            //DataBase.SaveMessage(new ClientDataModels.Message {recieverName = username, senderName = sender_username, text = message });
            //let the user know they recieved a new message.
            //todo
        }

        public void UpdateClientList()
        {
            SendPacketToServerAsync(ServerCommunicationTemplate.GetAllClientsRequestTemplate().ToString());
        }

        internal void SendMessageToFriend(string username, string message)
        {
            //todo add the message in database and get its ID add the id to the server to wait for recieved and seen replies from the server
            SendPacketToServerAsync($"2${username}#message");
        }
    }
}
