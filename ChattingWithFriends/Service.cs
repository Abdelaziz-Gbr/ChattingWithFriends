using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataModels;
namespace ChattingWithFriends
{
    //internal delegate void ConnectedUsersListUpdated(List<UserDataModel> users);
    internal class Service
    {
        private IPAddress ip;
        private int port = 45000;
        private TcpListener listener;
        private bool servicing = false;
        private Task? serviceJob;
        public UsersManager usersManager;
        public event Action OnAllUsersListUpdated;

        public event Action OnConnectedUsersListUpdated;
        public Service()
        {
            ip = IPAddress.Loopback;
            listener = new TcpListener(ip, port);
            usersManager = new UsersManager();
            usersManager.OnAllUsersListUpdated += UsersListUpdated;

        }

        public void StartService()
        {

            servicing = true;
            serviceJob = new Task(AcceptClientRequests);
            serviceJob.Start();
        }

        public void EndService()
        {
            servicing = false;
            serviceJob?.Dispose();
        }

        public List<UserDataModel> GetAllUsers()
        {
            return usersManager.allUsers;
        }

        private void UsersListUpdated()
        {
            OnAllUsersListUpdated();
        }

        private void AcceptClientRequests()
        {
            listener.Start();
            while (servicing)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                var userReq = GetUserRequest(tcpClient);
                switch(userReq.reqType)
                {
                    case 0:
                        {
                            //log IN
                            usersManager.AttemptLogin(userReq.reqBody, tcpClient);
                            break;
                        }
                    default:
                        {
                            BadRequest(tcpClient);
                            break;
                        }
                }
            }
        }

        private UserRequest GetUserRequest(TcpClient tcpClient)
        {
            int req = -1;
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            string tempReq = reader.ReadLine();
            
            return UserRequest.ParseFromString(tempReq);
        }

        private void BadRequest(TcpClient tcpClient)
        {
            try
            {
                StreamWriter tempWriter = new StreamWriter(tcpClient.GetStream());
                tempWriter.WriteLine("Bad Request");
                tempWriter.Flush();
                tempWriter.Close();
            }
            catch
            {
                //donothing
            }
        }
    }
}
