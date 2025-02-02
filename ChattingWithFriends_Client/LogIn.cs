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
            if (!CheckForValidInput())
            {
                pnl_Instructions.Visible = true;
                return;
            }
            string username = txtBox_username.Text;
            string password = txtBox_password.Text;
            serverConneection = Program.GetConnection();
            serverConneection.OnLoggedIn += SignedIn;
            serverConneection.LogIn(username, password);
        }

        private bool CheckForValidInput()
        {
            if (txtBox_username.Text.Length < 1 || txtBox_username.Text.Contains('#') || txtBox_username.Text.Contains('$'))
            {
                return false;
            }
            if (txtBox_password.Text.Length < 1 || txtBox_password.Text.Contains('#') || txtBox_password.Text.Contains('$'))
            {
                return false;
            }
            return true;
        }

        private void SignedIn()
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            this.Hide();
        }


        private void chkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBox_ShowPassword.Checked) 
            {
                txtBox_password.PasswordChar = '\0';
            }
            else
            {
                txtBox_password.PasswordChar = '*';
            }
        }
    }
}
