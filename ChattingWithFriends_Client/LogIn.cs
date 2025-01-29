namespace ChattingWithFriends_Client
{
    public partial class LogIn : Form
    {
        private Connection serverConneection;
        public LogIn()
        {
            InitializeComponent();
        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            string username = txtBox_username.Text;
            string password = txtBox_password.Text;

            serverConneection = Program.GetConnection();
            serverConneection.OnLoggedIn += SignedIn;
            serverConneection.LogIn(username, password);
        }

        private void SignedIn() 
        {
            MessageBox.Show("congratulations now you have to make sure you save that username and use it to send upcomming messages", "Log in success");

        }
    }
}
