﻿using ClientDataModels;
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
        private Connection connection;
        public HomeScreen()
        {
            InitializeComponent();
            connection = Program.GetConnection();
            connection.OnNewClientList += ClientsListUpdated;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            lbl_username.Text += connection.username;
            connection.AcceptIncommingMessages();
            LoadChats();
        }
        private void LoadChats()
        {
            connection.GetAllFriends().ForEach(friend => { checkedList_chats.Items.Add(friend); });
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
    }
}
