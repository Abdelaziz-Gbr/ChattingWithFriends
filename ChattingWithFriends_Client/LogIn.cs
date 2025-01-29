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
            string username = "Abdelaziz";// txtBox_username.Text;
            string password = "123";// txtBox_password.Text;

            serverConneection = Program.GetConnection();
            serverConneection.OnLoggedIn += SignedIn;
            serverConneection.LogIn(username, password);
        }

        private void SignedIn() 
        {
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            this.Hide();
        }
    }
}
