using ClientDataBase;
using ClientDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattingWithFriends_Client
{
    public delegate void OnCloseEvent(string x);
    public partial class ChattingWithFriend : Form
    {
        private Connection connection;
        private string friendUsername;
        public event OnCloseEvent CloseEvent;
        private int userID;
        public ChattingWithFriend(string username)
        {
            this.friendUsername = username;
            userID = DataBase.GetFriendID(username);
            InitializeComponent();
            connection = Program.GetConnection();
            connection.chatObservers.Add(new ChatObserver { username = friendUsername, OnMessageReceived = NewMessageRecieved });
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string message = txtBox_MessageInput.Text;
            txtBox_MessageInput.Clear();
            txtBox_DisplayChat.Text += $"(sent){DateTime.Now} seen: false, recieved: false.{Environment.NewLine}{message}{Environment.NewLine}";
            connection.SendMessageToFriend(friendUsername, message);
        }

        private void ChattingWithFriend_Load(object sender, EventArgs e)
        {
            Text += $" {friendUsername}";
            ReloadChat();
        }

        private void ChattingWithFriend_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent?.Invoke(friendUsername);
            connection.RemoveMyChatObserver(friendUsername);
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            //btn_reload.Enabled = false;
            txtBox_DisplayChat.Clear();
            ReloadChat();
            lbl_reload.Visible = false;
            btn_reload.Enabled = false;
        }

        private void ReloadChat()
        {
            var recievedMsgs = DataBase.GetMessagesRecievedFrom(userID);
            var sentMsgs = DataBase.GetMessagesSentTo(userID);

            int recPointer = 0;
            int senPointer = 0;

            while (recPointer < recievedMsgs.Count && senPointer < sentMsgs.Count)
            {
                DateTime recievedtime = recievedMsgs[recPointer].msg_time;
                DateTime sentTime = sentMsgs[senPointer].msg_time;
                if (recievedtime < sentTime)
                {
                    //recieved message is earlier.
                    txtBox_DisplayChat.Text += $"(recieved){recievedMsgs[recPointer++]}{Environment.NewLine}";
                }
                else
                {
                    //sent message is earlier.
                    txtBox_DisplayChat.Text += $"(sent){sentMsgs[senPointer++]}{Environment.NewLine}";
                }
            }

            while (recPointer < recievedMsgs.Count)
            {
                txtBox_DisplayChat.Text += $"(recieved){recievedMsgs[recPointer++]}{Environment.NewLine}";
            }

            while (senPointer < sentMsgs.Count)
            {
                txtBox_DisplayChat.Text += $"(sent){sentMsgs[senPointer++]}{Environment.NewLine}";
            }

        }

        private void NewMessageRecieved(string msg)
        {
            txtBox_DisplayChat.Text += $"(recieved) {DateTime.Now}: {Environment.NewLine}{msg}{Environment.NewLine}";
        }
        private void OnChatUpdated()
        {
            lbl_reload.Visible = true;
            btn_reload.Enabled = true;
        }
    }
}
