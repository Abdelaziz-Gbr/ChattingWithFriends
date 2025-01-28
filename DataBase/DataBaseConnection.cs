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

        public int UserExists(UserDataModel model)
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
            int userid = UserExists(userData);
            if (userid == -1)
                userid =  AddUsesr(userData);
            return userid;
/*
            try
            {
                string selectQuery = "SELECT id FROM Users WHERE username = @username AND password = @password";
                string insertQuery = "INSERT INTO Users (username, password) OUTPUT INSERTED.id VALUES (@username, @password)";

                sqlConnection.Open();

                    // Check if user exists
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection))
                    {
                        selectCommand.Parameters.AddWithValue("@username", userData.username);
                        selectCommand.Parameters.AddWithValue("@password", userData.password);

                        object result = selectCommand.ExecuteScalar();

                        if (result != null) // User exists
                        {
                            sqlConnection.Close();
                            return Convert.ToInt32(result);
                        }
                    }

                    // Add user if not found
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        insertCommand.Parameters.AddWithValue("@username", userData.username);
                        insertCommand.Parameters.AddWithValue("@password", userData.password);

                        sqlConnection.Close();
                        return (int)insertCommand.ExecuteScalar();
                    }
            }
            catch (SqlException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"SQL Error: {ex.Message}");
                sqlConnection.Close();
                return -1; // Return an error code
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                sqlConnection.Close();
                return -1;
            }*/
        }


    }
}
