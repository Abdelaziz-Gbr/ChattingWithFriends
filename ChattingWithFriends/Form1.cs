namespace ChattingWithFriends
{
    public partial class Form1 : Form
    {
        private Service myService;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_StartService(object sender, EventArgs e)
        {
            myService = Program.GetService();
            myService.StartService();
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

        }
    }
}
