using KostKompas.Models;
using Microsoft.Data.SqlClient;

namespace KostKompas.Services
{
    public class DBServiceFood
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

        public List<Food> GetAllFoods()
        {
            List<Food> data = new List<Food>();
            string queryStr = $"SELECT * FROM Foods";

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


        public int Create(Food food)
        {
            int id = NextId();
            food.Id = id;
            string queryStr = $"INSERT INTO Foods (Name, Kcal, Protein, Fat, Carbohydrate, Fibre) VALUES (@Name, @Kcal, @Protein, @Fat, @Carbohydrate, @Fibre)";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, food);

            cmd.ExecuteNonQuery();

            return id;

        }
        public int Delete(int id)
        {
            string queryStr = $"DELETE FROM Foods WHERE food_id = @id";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            return id;

        }

        public int Update(Food food)
        {

            string queryStr = $"Update Foods SET Name = @name, Kcal = @kcal, Protein = @protein, Fat = @fat, Carbohydrate = @carbohydrate, Fibre = @fibre WHERE food_id = @id;";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, food);
            cmd.Parameters.AddWithValue("@id", food.Id);


            cmd.ExecuteNonQuery();

            return food.Id;

        }

        private int NextId()
        {
            return GetAllFoods().Select(t => t.Id).DefaultIfEmpty(0).Max() + 1;
        }

        protected Food GetRow(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("food_id"));
            string Name = reader.GetString(reader.GetOrdinal("Name"));
            double Kcal =(double) reader.GetDecimal(reader.GetOrdinal("Kcal"));
            double Protein =(double) reader.GetDecimal(reader.GetOrdinal("Protein"));
            double Fat =(double) reader.GetDecimal(reader.GetOrdinal("Fat"));
            double Carbohydrate =(double) reader.GetDecimal(reader.GetOrdinal("Carbohydrate"));
            double Fibre =(double) reader.GetDecimal(reader.GetOrdinal("Fibre"));

            return new Food(id, Name, Kcal, Protein, Fat, Carbohydrate, Fibre);
        }

        protected void AddParameterValues(SqlCommand cmd, Food food)
        {
            cmd.Parameters.AddWithValue("@Name", food.Name);
            cmd.Parameters.AddWithValue("@Kcal", food.Kcal);
            cmd.Parameters.AddWithValue("@Protein", food.Protein);
            cmd.Parameters.AddWithValue("@Fat", food.Fat);
            cmd.Parameters.AddWithValue("@Fibre", food.Fibre);
            cmd.Parameters.AddWithValue("@Carbohydrate", food.Carbohydrate);
          

        }
    }
}

