﻿using System.Net;
using System.Net.Sockets;
using ClientDataModels;
using ClientDataBase;
using Microsoft.VisualBasic;
namespace ChattingWithFriends_Client
{

    internal class ChatObserver
    {
        public string username { get; set; }
        public Action<string> OnMessageReceived;
        public Action ChatUpdated;
    }

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

        public List<ChatObserver> chatObservers = new List<ChatObserver>();
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
            SendPacketToServer(ServerCommunicationTemplate.GetLogInTemplate(username, password).ToString());
            string? serverResponse = ReadServerPacket();
            if (serverResponse != null)
                if (serverResponse.Equals("200"))
                {
                    DataBase.InitDB(username);
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
                        int FriendmsgId = int.Parse(data[0]);
                        string sender = data[1];
                        string msgBody = data[2];
                        OnMessageRecieved(sender, msgBody);
                        AcknowledgRecievement(FriendmsgId, sender);
                    }
                    else if(header == 3)
                    {
                        //aknowledgment
                        string[] data = packet[1].Split('$');
                        string msgId = data[0];
                        string friend_name = data[1];
                        DataBase.SetMessageRecieved(msgId);
                        NotifyChatObserver(friend_name);
                    }
                    else if (header == 4)
                    {
                        //aknowledgment
                        string[] data = packet[1].Split('$');
                        string msgId = data[0];
                        string friend_name = data[1];
                        DataBase.SetMessageSeen(msgId);
                        NotifyChatObserver(friend_name);
                    }
                }
            }
        }

        private void AcknowledgRecievement(int friendmsgId, string sender)
        {
            SendPacketToServerAsync(ServerCommunicationTemplate.GetMessageAknowledgment(friendmsgId, sender).ToString());
        }

        private void OnMessageRecieved(string sender_username, string message)
        {
            DataBase.SaveRecieved(sender_username, message);
            foreach (ChatObserver chat in chatObservers)
            {
                if (chat.username == sender_username)
                {
                    chat.OnMessageReceived(message);
                }
            }
        }

        public void UpdateClientList()
        {
            SendPacketToServerAsync(ServerCommunicationTemplate.GetAllClientsRequestTemplate().ToString());
        }

        internal void SendMessageToFriend(string friendUsername, string message)
        {
            //todo add the message in database and get its ID add the id to the server to wait for recieved and seen replies from the server
            int friendID = DataBase.GetFriendID(friendUsername);
            int msgId = DataBase.SaveSent(friendID, message);
            SendPacketToServerAsync($"2#{msgId}${friendUsername}${message}");
        }

        public void RemoveMyChatObserver(string friendUsername)
        {
            int index = 0;
            for (index = 0; index < chatObservers.Count; index++)
                if (chatObservers[index].username == friendUsername)
                    break;
            chatObservers.RemoveAt(index);
        }

        private void NotifyChatObserver(string friendUsername) 
        {
            foreach(ChatObserver chatObserver in chatObservers)
            {
                if(chatObserver.username == friendUsername)
                {
                    chatObserver.ChatUpdated?.Invoke();
                }
            }
        }
    }
}
