﻿using Microsoft.Data.SqlClient;
using DataModels;
using System.Reflection;
namespace DataBase
{
    public class DataBaseConnection
    {
        private SqlConnection sqlConnection;

        public DataBaseConnection()
        {
            sqlConnection = new SqlConnection("Data Source=s3dy;Initial Catalog=ChatApplication;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public int AddUsesr(UserDataModel userDataModel)
        {
            string sqlQuery = "INSERT INTO Users (username, password) OUTPUT INSERTED.id VALUES (@username,@password)";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            cmd.Parameters.AddWithValue("username", userDataModel.username);
            cmd.Parameters.AddWithValue("password", userDataModel.password);
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if(result == null) return -1; return (int)result;
        }

        public bool IsUserBlocked(UserDataModel user)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT BLOCKED FROM Users WHERE username = @username", sqlConnection);
            sqlCommand.Parameters.AddWithValue("username", user.username);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                sqlConnection.Close();
                if (reader.Read())
                    return (bool)reader[0];
                return false;
            }
        }
        public UserDataModel? GetUesrByUserName(string username)
        {
            UserDataModel user = null;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, BLOCKED, password FROM Users WHERE username = @username", sqlConnection);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if(sqlDataReader.Read())
            {
                user = new UserDataModel 
                { 
                    blocked = (bool)sqlDataReader["BLOCKED"],
                    id = (int)sqlDataReader["id"],
                    username = username ,
                    password = (string)sqlDataReader["password"]
                };
            }
            sqlConnection.Close();
            return user;
        }

        public List<UserDataModel> GetUsers() 
        {
            var users = new List<UserDataModel>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, username, blocked FROM Users", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var usesr = new UserDataModel 
                {
                    id = (int)reader["id"],
                    username = (string)reader["username"],
                    blocked = (bool)reader["BLOCKED"] 
                };
                users.Add(usesr);
            }

            sqlConnection.Close();
            return users;
        }


    }
}
