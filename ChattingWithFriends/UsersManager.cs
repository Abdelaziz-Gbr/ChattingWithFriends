using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataBase;
using System.Net.Sockets;
namespace ChattingWithFriends
{
    internal class UsersManager
    {
        private readonly List<User> connectedUsers;
        private readonly DataBaseConnection db;
        public List<UserDataModel> allUsers { get; }
        public UsersManager() 
        {
            connectedUsers = new List<User>();
            db= new DataBaseConnection();
            allUsers = db.GetUsers();
        }

        public bool AddUserOrCheckIfCredsCorrect(UserDataModel user, TcpClient tcpClient)
        {
            //now contact DB to Add user or get its ID
            UserDataModel? SignInUser = db.CheckUserCredsOrAddIfNotFound(user);
            if (SignInUser != null && !SignInUser.blocked)
            {
                User newConnection = new User(SignInUser, tcpClient);
                newConnection.SendOkMessage();
                connectedUsers.Add(newConnection);
                allUsers.Add(user);
                return true;
            }
            return false;
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
    }
}
