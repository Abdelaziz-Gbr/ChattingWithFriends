using Microsoft.Data.SqlClient;
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

        public int GetUserIDIfExists(UserDataModel model)
        {
            string selectQuery = $"SELECT id FROM Users WHERE username=@username AND password=@password";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(selectQuery, sqlConnection);
            cmd.Parameters.AddWithValue("username", model.username);
            cmd.Parameters.AddWithValue("password", model.password);
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if(result == null)
                return -1;
            return (int)result;
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

        public int CheckUserCredsOrAddIfNotFound(UserDataModel userData)
        {
            int userid = GetUserIDIfExists(userData);
            if (userid == -1)
                userid =  AddUsesr(userData);
            return userid;

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


            return users;
        }


    }
}
