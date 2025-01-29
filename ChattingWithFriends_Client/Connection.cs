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
            SendPacketToServer($"{username},{password}");
            string? serverResponse = ReadServerPacket();
            if (serverResponse != null)
                if (serverResponse.Equals("200"))
                {
                    this.username = username;
                    getClientsListFromServer();
                    OnLoggedIn?.Invoke();
                }
                else
                    MessageBox.Show("Wrong username or password", "Try Again");
            else
                MessageBox.Show("Failed To send credentials to the server", "Server Error");
        }

        private void getClientsListFromServer()
        {
            SendPacketToServer("get_users");
            string incommning = ReadServerPacket();
            if (incommning != null) 
            {
                string[] friends = incommning.Split('$');
                foreach (string friendString in friends) 
                {
                    string[] temp = friendString.Split(",");
                    DataBase.AddIfNotExists(new Friend
                    {
                        id= int.Parse(temp[0]),
                        username = temp[1]
                    });

                }
            }
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

        private async Task<string> ReadServerPacketAsync()
        {
            try
            {
                string incommingPacket = await reader.ReadLineAsync();
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
                    string[] splitPacked = serverPacket.Split('$');
                    int senderID = int.Parse(splitPacked[0]);
                    string senderName = splitPacked[1];
                    string message = splitPacked[2];
                    OnMessageRecieved(senderID, senderName, message);
                }
            }
        }

        private void OnMessageRecieved(int sender_id, string sender_username, string message)
        {
            DataBase.SaveMessage(new ClientDataModels.Message {recieverName = username, senderName = sender_username, text = message });
            //let the user know they recieved a new message.
            //todo
        }

        public void SendMessage()
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
