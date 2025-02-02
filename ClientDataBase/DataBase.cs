using Microsoft.Data.SqlClient;
using ClientDataModels;
using System.Data;
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

        public static int GetFriendID(string friendUsername)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Friend WHERE username = @username", sqlConnection);
            cmd.Parameters.AddWithValue ("username", friendUsername);
            int id = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            return id;
        }


        private static int SaveMessage(string message)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO FriendMessage (body)  OUTPUT INSERTED.id VALUES (@msgBody) ", sqlConnection);
            cmd.Parameters.AddWithValue("msgBody", message);
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            return (int)result;
        }
        public static int SaveSent(int friendId, string message)
        {
            int id = SaveMessage(message);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SentMessages] ([msg_id], [toFriend]) VALUES (@msgId ,@friendId)", sqlConnection);
            cmd.Parameters.AddWithValue("msgId", id);
            cmd.Parameters.AddWithValue("friendId", friendId);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return id;
        }

        public static void SaveRecieved(string sender_username, string msg_body)
        {
            int msgId = SaveMessage(msg_body);
            int sender_id = GetFriendID(sender_username);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RecievedMessages (msg_id, fromFriend) VALUES (@msgId , @friendId)", sqlConnection);
            cmd.Parameters.AddWithValue("msgId", msgId);
            cmd.Parameters.AddWithValue("friendId", sender_id);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static List<RecievedMessage> GetMessagesRecievedFrom(int senderId)
        {
            sqlConnection.Open();
            string query = "SELECT FriendMessage.id , FriendMessage.time, FriendMessage.body FROM FriendMessage INNER JOIN RecievedMessages ON RecievedMessages.msg_id = FriendMessage.id AND RecievedMessages.fromFriend = @friendID ORDER BY FriendMessage.time ASC";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("friendID", senderId);
            DataTable msgs_dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(msgs_dataTable);
            sqlConnection.Close();
            var messages = new List<RecievedMessage>();
            foreach (DataRow row in msgs_dataTable.Rows) 
            {
                messages.Add(new RecievedMessage
                {
                    msg_id = (int)row["id"],
                    msg_body = (string)row["body"],
                    msg_time = (DateTime)row["time"],
                    sender_id = senderId
                });
            }
            return messages;

        }

        public static List<SendedMessage> GetMessagesSentTo(int recieverId)
        {
            sqlConnection.Open();
            string query = "SELECT FriendMessage.id , FriendMessage.time, FriendMessage.body, SentMessages.seen, SentMessages.recieved FROM FriendMessage INNER JOIN SentMessages ON SentMessages.msg_id = FriendMessage.id AND SentMessages.toFriend = @friendID ORDER BY FriendMessage.time ASC";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("friendID", recieverId);
            DataTable msgs_dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(msgs_dataTable);
            sqlConnection.Close();
            var messages = new List<SendedMessage>();
            foreach (DataRow row in msgs_dataTable.Rows)
            {
                messages.Add(new SendedMessage
                {
                    msg_id = (int)row["id"],
                    msg_body = (string)row["body"],
                    msg_time = (DateTime)row["time"],
                    reciever_id = recieverId,
                    recieved = (bool)row["recieved"],
                    seen = (bool)row["seen"]
                });
            }
            return messages;
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

        public static void SetMessageRecieved(string msgId)
        {
            sqlConnection.Open();
            var cmd = new SqlCommand("UPDATE SentMessages SET recieved = 1 WHERE msg_id = @msgID", sqlConnection);
            cmd.Parameters.AddWithValue("msgID", msgId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void SetMessageSeen(string msgId)
        {
            sqlConnection.Open();
            var cmd = new SqlCommand("UPDATE SentMessages SET seen = 1 WHERE msg_id = @msgID", sqlConnection);
            cmd.Parameters.AddWithValue("msgID", msgId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
