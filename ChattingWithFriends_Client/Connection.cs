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
            writer.WriteLine($"{username},{password}");
            string? serverResponse = reader.ReadLine();
            if (serverResponse != null)
                if (serverResponse.Equals("200"))
                {
                    this.username = username;
                    OnLoggedIn?.Invoke();

                }
                else
                    MessageBox.Show("Wrong username or password", "Try Again");
            else
                MessageBox.Show("Failed To send credentials to the server", "Server Error");
        }

        public List<Friend> GetAllFriends()
        {
            var friends = DataBase.GetFriends();
            return friends;
        }
    }
}
