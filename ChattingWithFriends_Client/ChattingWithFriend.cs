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
    public partial class ChattingWithFriend : Form
    {
        private Connection connection;
        private string username;
        public ChattingWithFriend(string username)
        {
            this.username = username;
            InitializeComponent();
            connection = Program.GetConnection();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string message = txtBox_MessageInput.Text;
            connection.SendMessageToFriend(username, message);
        }
    }
}
