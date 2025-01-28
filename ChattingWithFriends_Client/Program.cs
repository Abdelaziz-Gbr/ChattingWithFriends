namespace ChattingWithFriends_Client
{
    internal static class Program
    {
        private static Connection serverConnection;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static Connection GetConnection()
        {
            if (serverConnection == null)
                serverConnection = new Connection();
            return serverConnection;
        }
    }
}