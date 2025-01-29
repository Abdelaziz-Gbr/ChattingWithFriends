﻿using Microsoft.Data.SqlClient;
using ClientDataModels;
namespace ClientDataBase
{
    public class DataBase
    {
        SqlConnection sqlConnection;

        public DataBase()
        {
            sqlConnection = new SqlConnection(@"Data Source=s3dy;Initial Catalog=ChatWithFriendClientDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=FalseData Source=s3dy;Initial Catalog=ChatWithFriendClientDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public void SaveFriend(Friend friend)
        {
            if (GetFriend(friend.id) != null)
                return;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TABLE Friend (id, username) VALUES (@id, @username)", sqlConnection);
            cmd.Parameters.AddWithValue("id", friend.id);
            cmd.Parameters.AddWithValue("username", friend.username);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Friend? GetFriend(int fId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT username FROM TABLE Friend WHERE id = @id", sqlConnection);
            cmd.Parameters.AddWithValue("id", fId);
            object result = cmd.ExecuteScalar();

            sqlConnection.Close();

            if (result != null)
                return new Friend { id = fId, username = (string)result };
            else
                return null;
        }

        public void SaveMessage(Message message)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TABLE Messages (id, sender_id, body) VALUES (@message_id, @sender_id, @body)", sqlConnection);
            cmd.Parameters.AddWithValue("message_id", message.id);
            cmd.Parameters.AddWithValue("sender_id", message.senderId);
            cmd.Parameters.AddWithValue("body", message.text);
            int rows = cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public List<Friend> GetFriends() 
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
