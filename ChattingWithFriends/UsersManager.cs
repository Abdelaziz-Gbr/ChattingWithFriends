using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataBase;
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;
namespace ChattingWithFriends
{
    internal class UsersManager
    {
        private readonly List<User> connectedUsers;
        private readonly DataBaseConnection db;
        public event Action OnAllUsersListUpdated;
        public List<UserDataModel> allUsers { get; }
        public UsersManager() 
        {
            connectedUsers = new List<User>();
            db= new DataBaseConnection();
            allUsers = db.GetUsers();
        }
        public string[] GetUsernames() 
        {
            string[] usernames = new string[connectedUsers.Count];
            for(int i =0; i < connectedUsers.Count; i++)
            {
                usernames[i] = connectedUsers[i].GetUsername();
            }
            return usernames;
        }

        public void AttemptLogin(string reqBody, TcpClient tcpClient)
        {
            string[] data = reqBody.Split('$');
            string _username = data[0];
            string _password = data[1];
            var userData = db.GetUesrByUserName(_username);
            var newUser = new User(userData, tcpClient, this);
            if (userData != null)
            {
                //user exists
                //check for _password
                if (userData.password == _password) 
                {
                    //_password correct -> log the user in
                    connectedUsers.Add(newUser);
                    newUser.SendLogInSuccessMessage();
                }
                else
                {
                    //_password incorrect
                    newUser.SendPasswordIncorrectMessage();
                }
            }
            else
            {
                //user doesn't exist
                //add user
                var userDataModel = new UserDataModel { username = _username, password = _password };
                int user_id = db.AddUsesr(userDataModel);
                userDataModel.id = user_id;
                allUsers.Add(userDataModel);
                newUser.dataModel = userDataModel;
                connectedUsers.Add(newUser);
                OnAllUsersListUpdated?.Invoke();
                newUser.SendLogInSuccessMessage();
            }
        }

    /*    public void SendClientsList(string reqBody)
        {
            string _username = reqBody;
            var user = GetUserByUserName(_username);
            user?.WriteToClient(AllUsers());
            
        }
*/
        private User? GetUserByUserName(string username)
        {
            foreach (var user in connectedUsers) 
            {
                if(user.GetUsername() == username)
                    return user;
            }
            return null;
        }

        public string GetAllUsersAsString()
        {
            string allUsersString = "";
            for(int i =0;i<allUsers.Count;i++)
            {
                if(i == allUsers.Count-1)
                    allUsersString += allUsers[i].ToString();
                else
                    allUsersString += allUsers[i].ToString() + "$";
            }
            return allUsersString;
        }

        internal void ForwardMessage(MessageDataModel msg, string sender)
        {
            string username = msg.username;
            foreach (var user in connectedUsers) 
            {
                if (user.dataModel.username == username)
                    user.WriteToClient($"2#{msg.id}${sender}${msg.body}");
            }
        }

        internal void SendAknowledgment(string msgId, string friendUsername, string username)
        {
            int userIndex = -1;
            for (int i = 0; i < connectedUsers.Count; i++) 
            {
                if (connectedUsers[i].GetUsername() == friendUsername)
                {
                    userIndex = i;
                    break;
                }
            }
            if(userIndex != -1)
            {
                connectedUsers[userIndex].WriteToClient($"3#{msgId}${username}");
            }
        }

        internal void SendMsgSeen(string msgId, string friendUsername, string username)
        {
            int userIndex = -1;
            for (int i = 0; i < connectedUsers.Count; i++)
            {
                if (connectedUsers[i].GetUsername() == friendUsername)
                {
                    userIndex = i;
                    break;
                }
            }
            if (userIndex != -1)
            {
                connectedUsers[userIndex].WriteToClient($"4#{msgId}${username}");
            }
        }
    }
}
