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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            lbl_username.Text += connection.username;
            LoadPastChats();
        }
        private void LoadPastChats()
        {
            connection.GetAllFriends().ForEach(friend => {checkedList_pastChats.Items.Add(friend);});
        }
    }
}
