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
        public event Action OnAllUsersListUpdated;
        public List<UserDataModel> allUsers { get; }
        public UsersManager() 
        {
            connectedUsers = new List<User>();
            db= new DataBaseConnection();
            allUsers = db.GetUsers();
        }

        public bool AddUserOrCheckIfCredsCorrect(UserDataModel user, TcpClient tcpClient)
        {
            var checkedUser = db.GetUesrByUserName(user.username);
            if (checkedUser != null)
            {
                
                //is not null then username exists -> check for password
                if (checkedUser.password.Equals(user.password))
                {
                    //password correct check if blocked
                    if (!checkedUser.blocked)
                    {
                        //all good let the user know he his credentials are ok and keep its connection open.
                        //for security and performance reasons remove the password field 
                        AddOnlineUser(tcpClient, checkedUser);
                        //no need to add it to the Allusers list as it should be there already.
                       // MessageBox.Show("1", "got here");
                        return true;
                    }
                    else
                    {
                        //user is blocked -> 
                        //maybe imp to let the user know they are blocked later? 
                        //MessageBox.Show("2", "got here");
                        return false;
                    }
                }
                else
                {
                    //password is incorrect
                    //imp func to tell the user the password is incorrect.
                    //MessageBox.Show("3", "got here");
                    return false;
                }
            }
            else
            {
                //sign the user up
                int userID = db.AddUsesr(user);
                if(userID != -1)
                {
                    //user signed up succesfully
                    var newUser = new UserDataModel { id = userID, username = user.username };
                    AddOnlineUser(tcpClient, newUser);
                    allUsers.Add(newUser);

                    //let subscribers know the list have been updated.
                    OnAllUsersListUpdated?.Invoke();

                  //  MessageBox.Show("3", "got here");
                    return true;
                }
                else
                {
                    //username dublicated
                    //send message to the user to let'em know
                    //MessageBox.Show("4", "got here");
                    return false;
                }

            }
           
        }

        private void AddOnlineUser(TcpClient tcpClient, UserDataModel? checkedUser)
        {
            UserDataModel OnlineUser = new UserDataModel
            {
                username = checkedUser.username,
                id = checkedUser.id,
            };
            User newConnection = new(OnlineUser, tcpClient);
            newConnection.SendOkMessage();
            connectedUsers.Add(newConnection);
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
