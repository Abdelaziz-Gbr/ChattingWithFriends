using ClientDataModels;
using Microsoft.VisualBasic;
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
    public partial class HomeScreen : Form
    {
        int checkedIndex = -1;
        private Connection connection;
        private readonly List<string> activeChats = [];
        public HomeScreen()
        {
            InitializeComponent();
            connection = Program.GetConnection();
            connection.OnNewClientList += ClientsListUpdated;
        }

        private void btn_OpenChat_Click(object sender, EventArgs e)
        {
            string selectedUser = checkedList_chats.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedUser) || checkedList_chats.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user to open chat with.");
                return;
            }
            if (activeChats.Contains(selectedUser))
            {
                MessageBox.Show($"Chat with {selectedUser} already open");
                return;
            }
            var chatWindow = new ChattingWithFriend(selectedUser);
            chatWindow.CloseEvent += ChatClose;
            activeChats.Add(selectedUser);
            chatWindow.Show();
        }

        private void ChatClose(string username)
        {
            int index = -1;
            for (int i = 0; i < activeChats.Count; i++)
                if (activeChats[i] == username)
                {
                    index = i; break;
                }
            if (index != -1)
                activeChats.RemoveAt(index);

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            lbl_username.Text += connection.username;
            connection.AcceptIncommingMessages();
            ClientsListUpdated();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            checkedList_chats.Items.Clear();
            connection.UpdateClientList();
        }

        private void ClientsListUpdated()
        {
            List<Friend> friends = connection.GetAllFriends();
            checkedList_chats.Items.Clear();
            foreach (Friend friend in friends)
            {
                if (friend.username != connection.username)
                    checkedList_chats.Items.Add(friend.username);

            }
        }

        private void checkedList_chats_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*    var checkedItem = checkedList_chats.SelectedItem;
            checkedList_chats.SelectedItems.Clear();
            checkedList_chats.SelectedItems.Add(checkedItem);*/
        }
    }
}
