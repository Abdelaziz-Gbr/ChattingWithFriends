namespace ChattingWithFriends
{
    public partial class Form1 : Form
    {
        private Service myService;
        private List<DataModels.UserDataModel> myUsers;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_StartService(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myService = Program.GetService();
            myService.StartService();
            myService.OnAllUsersListUpdated += UpdatedUsersList;
            UpdatedUsersList();

        }

        private void UpdatedUsersList()
        {
            if(InvokeRequired)
            {
                Invoke(new Action(UpdatedUsersList));
                return;
            }
            var users = myService.GetAllUsers();
            checkedList_UnblockedClients.Items.Clear();
            checkedList_BlockedClients.Items.Clear();
            foreach (var user in users)
            {
                if(!user.blocked)
                    checkedList_UnblockedClients.Items.Add(user);
                else
                    checkedList_BlockedClients.Items.Add(user);
            }
        }
    }
}
