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
        private List<User> users;
        private DataBaseConnection db;
        public UsersManager() 
        {
            users = new List<User>();
            db= new DataBaseConnection();
        }

        public bool AddUserOrCheckIfCredsCorrect(UserDataModel user, TcpClient tcpClient)
        {
            //now contact DB to Add user or get its ID
            int id = db.CheckUserCredsOrAddIfNotFound(user);
            if(id != -1)
            {
                user.id = id;
                User newConnection = new User(user,tcpClient);
                newConnection.SendOkMessage();
                users.Add(newConnection);
                return true;
            }
            return false;
        }

        public string[] GetUsernames() 
        {
            string[] usernames = new string[users.Count];
            for(int i =0; i < users.Count; i++)
            {
                usernames[i] = users[i].GetUsername();
            }
            return usernames;
        }
    }
}
