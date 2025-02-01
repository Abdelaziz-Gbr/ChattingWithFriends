using Microsoft.Data.SqlClient;
using ClientDataModels;
namespace ClientDataBase
{
    public class DataBase
    {
        private static SqlConnection sqlConnection;

        private static string baseConnectionString = @"Data Source=s3dy;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private DataBase()
        {
            
        }

        public static void InitDB(string username)
        {
            string databaseName = $"ChatWithFriendsClientDB_{username}";
            string userConnectionString = $"{baseConnectionString};Initial Catalog={databaseName}";
            using (SqlConnection conn = new SqlConnection(baseConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"IF NOT EXISTS (SELECT NAME FROM sys.databases WHERE name = '{databaseName}')" +
                    $"CREATE DATABASE {databaseName}", conn);
                cmd.ExecuteNonQuery();
            }
            sqlConnection = new SqlConnection(userConnectionString);
            CreatTables();
        }

        private static void CreatTables()
        {
            /*using (SqlConnection conn = sqlConnection)
            {
                

            }*/

            sqlConnection.Open();
            string createFriendTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Friend')
                    BEGIN
                        CREATE TABLE Friend
                        (
                            id int not null unique,
                            username NVARCHAR(10) not null
                        );
                    END;
                    ";
            string createFriendMessagesTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FriendMessage')
                    BEGIN
                    CREATE TABLE FriendMessage
                    (
                        id int IDENTITY(1,1) PRIMARY KEY,
                        body NVARCHAR(50) not null,
                        time DATETIME DEFAULT GETDATE()
                    );
                    END;
                    ";
            string createRecievedMessagesQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RecievedMessages')
                    BEGIN
                    CREATE TABLE RecievedMessages
                    (
                        msg_id int REFERENCES FriendMessage(id),
                        fromFriend int REFERENCES Friend(id)
                    );
                    END;
                    ";
            string createSentMessagesQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SentMessages')
                    BEGIN
                    CREATE TABLE SentMessages
                    (
                        msg_id int REFERENCES FriendMessage(id),
                        toFriend int REFERENCES Friend(id),
                        seen BIT DEFAULT 0,
                        recieved BIT DEFAULT 0
                    );
                    END;
                    ";

            SqlCommand sqlCommand =
                new SqlCommand(
                createFriendTableQuery +
                createFriendMessagesTableQuery +
                createRecievedMessagesQuery +
                createSentMessagesQuery, sqlConnection);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public static void SaveFriend(Friend friend)
        {
            if (GetFriend(friend.id) != null)
                return;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Friend (id, username) VALUES (@id, @username)", sqlConnection);
            cmd.Parameters.AddWithValue("id", friend.id);
            cmd.Parameters.AddWithValue("username", friend.username);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static Friend? GetFriend(int fId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT username FROM Friend WHERE id = @id", sqlConnection);
            cmd.Parameters.AddWithValue("id", fId);
            object result = cmd.ExecuteScalar();

            sqlConnection.Close();

            if (result != null)
                return new Friend { id = fId, username = (string)result };
            else
                return null;
        }

        public static void AddIfNotExists(Friend friend)
        {
            //friend already exists
            if(GetFriend(friend.id) != null) return;
            //frind does not exist -> save
            SaveFriend(friend);
        }


        public static int SaveMessage(string message)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[FriendMessage] (body) OUTPUT INSERTED.id VALUES (@msgBody) ", sqlConnection);
            cmd.Parameters.AddWithValue("msgBody", message);
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            return (int)result;
        }
        public static void SaveSent(SendedMessage message)
        {
            int id = SaveMessage(message.msg_body);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SentMessages] ([msg_id], [toFriend]) VALUES (@msgId ,@friendId)", sqlConnection);
            cmd.Parameters.AddWithValue("msgId", id);
            cmd.Parameters.AddWithValue("friendId", message.reciever_id);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public static void SaveRecieved(RecievedMessage message)
        {
            int id = SaveMessage(message.msg_body);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RecievedMessages (msg_id, fromFriend) VALUES (@msgId , @friendId)", sqlConnection);
            cmd.Parameters.AddWithValue("msgId", message.msg_id);
            cmd.Parameters.AddWithValue("friendId", message.sender_id);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static List<MessageModel> GetMessagesRecievedFrom(int senderId)
        {
            throw new NotImplementedException();
        }

        public static List<MessageModel> GetMessagesSentTo(int recieverId)
        {
            throw new NotImplementedException();
        }

        public static List<Friend> GetFriends() 
        {
            var friends = new List<Friend>();
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT username , id FROM Friend ", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                var friend = new Friend { id = (int)reader["id"], username = (string)reader["username"] };
                friends.Add(friend);
            }


            sqlConnection.Close();
            return friends;
        }

    }
}
