using KostKompas.Models;
using Microsoft.Data.SqlClient;

namespace KostKompas.Services
{
    public class DBServiceUser
    {
        protected string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(localdb)\\MSSQLLocalDB";
                builder.InitialCatalog = "KostKompas";

                return builder.ConnectionString;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> data = new List<User>();
            string queryStr = $"SELECT * FROM Users";

            // Etablér DB-forbindelse (med brug af using-syntaksen)
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            // 2) Definér og udfør SQL-statement
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // 3) Processér de læste data
            while (reader.Read())
            {
                data.Add(GetRow(reader));
            }

            return data;

        }


        public int Create(User user)
        {
            int id = NextId();
            user.Id = id;
            string queryStr = $"INSERT INTO Users (Id, Name, Email, Password, kcal_goal, protein_goal, fat_goal, carbohydrate_goal, fibre_goal) VALUES (@Id, @name, @email, @password, @kcal_goal, @protein_goal, @fat_goal, @carbohydrate_goal, @fibre_goal)";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, user);

            cmd.ExecuteNonQuery();

            return id;

        }

        private int NextId()
        {
            return GetAllUsers().Select(t => t.Id).DefaultIfEmpty(0).Max() + 1;
        }

        protected User GetRow(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("user_id"));
            string Name = reader.GetString(reader.GetOrdinal("Name"));
            string Email = reader.GetString(reader.GetOrdinal("Email"));
            string Password = reader.GetString(reader.GetOrdinal("Password"));
            double kcal_goal =(double) reader.GetDecimal(reader.GetOrdinal("kcal_goal"));
            double protein_goal =(double) reader.GetDecimal(reader.GetOrdinal("protein_goal"));
            double fat_goal =(double) reader.GetDecimal(reader.GetOrdinal("fat_goal"));
            double carbohydrate_goal =(double) reader.GetDecimal(reader.GetOrdinal("carbohydrate_goal"));
            double fibre_goal =(double) reader.GetDecimal(reader.GetOrdinal("fibre_goal"));






            return new User(id, Name, Email, Password, kcal_goal, protein_goal, fat_goal, carbohydrate_goal, fibre_goal);
        }

        protected void AddParameterValues(SqlCommand cmd, User user)
        {
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Id", user.Name);
            cmd.Parameters.AddWithValue("@Id", user.Email);
            cmd.Parameters.AddWithValue("@Id", user.Password);
            cmd.Parameters.AddWithValue("@Id", user.Kcal_goal);
            cmd.Parameters.AddWithValue("@Id", user.Protein_goal);
            cmd.Parameters.AddWithValue("@Id", user.Fat_goal);
            cmd.Parameters.AddWithValue("@Id", user.Carbohydrate_goal);
            cmd.Parameters.AddWithValue("@Id", user.Fibre_goal);






        }
    }
}
