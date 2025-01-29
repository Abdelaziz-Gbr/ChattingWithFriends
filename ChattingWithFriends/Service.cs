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
        private UsersManager usersManager;

        public event Action OnConnectedUsersListUpdated;
        public Service()
        {
            ip = IPAddress.Loopback;
            listener = new TcpListener(ip, port);
            usersManager = new UsersManager();
        }

        public void StartService()
        {

            servicing = true;
            serviceJob = new Task(AcceptIncomming);
            serviceJob.Start();
        }

        public void EndService()
        {
            servicing = false;
            serviceJob?.Dispose();
        }

        private void AcceptIncomming()
        {
            listener.Start();
            while(servicing)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                UserDataModel? user = GetUserCreditentials(tcpClient);
                if(user != null) 
                {
                    bool userCorrect = usersManager.AddUserOrCheckIfCredsCorrect(user, tcpClient);
                    if (userCorrect)
                        OnConnectedUsersListUpdated?.Invoke();
                    else
                        throw new Exception("to do");
                }
            }
        }

        private UserDataModel? GetUserCreditentials(TcpClient tcpClient)
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                string packet = sr.ReadLine();
                string[] creds = packet.Split(',');
                return new UserDataModel { password = creds[1], username = creds[0] };
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "error getting user creds");
                return null;
            }
        }

        public List<UserDataModel> GetAllUsers()
        {
            return usersManager.allUsers;
        }
    }
}
