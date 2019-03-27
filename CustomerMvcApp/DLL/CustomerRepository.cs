using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.DLL
{
    public class CustomerRepository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        public static SqlConnection sqlConnection = new SqlConnection(cs);
        SqlCommand sqlCommand = new SqlCommand("", sqlConnection);

        public bool Saved(Customer customer)
        {
            bool chk = false;

            string query = @"INSERT INTO Customers([Name],[Code],[Address],[Email],[Contact],[Age],[LoyalityPoint]) VALUES
                            ('" + customer.Name + "','" + customer.Code + "','" + customer.Address + "','" + customer.Email + "','" + customer.Contact + "'," + customer.Age + "," + customer.LoyalityPoint + ");";

            sqlConnection.Open();
            sqlCommand.CommandText = query;
            int isSaved = sqlCommand.ExecuteNonQuery();

            if (isSaved > 0)
            {
                chk = true;
            }
            sqlConnection.Close();
            return chk;


        }

        public bool Updated(Customer customer)
        {
            bool chk = false;

            string findIdQuery = @"select *from Customers where Code = '" + customer.Code + "';";

            sqlConnection.Open();

            sqlCommand.CommandText = findIdQuery;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string id = "";
            if (sqlDataReader.Read())
            {
                id = sqlDataReader["Id"].ToString();
            }

            customer.Id = Convert.ToInt32(id);

            sqlConnection.Close();
            sqlConnection.Open();

            string updateQuery = @"UPDATE Customers SET Name = '" + customer.Name + "',Code = '" + customer.Code + "',Address = '" + customer.Address + "',Email = '" +
                customer.Email + "',Contact= '" + customer.Contact + "',Age = " + customer.Age + ",LoyalityPoint = " + customer.LoyalityPoint + " WHERE Id = " + customer.Id;
            sqlCommand.CommandText = updateQuery;
            int isUpdated = sqlCommand.ExecuteNonQuery();
            if (isUpdated > 0)
            {
                chk = true;
            }
            sqlConnection.Close();
            return chk;
        }

        public DataTable Show(string name)
        {
            string query = "";
            if (name == null)
            {
                query = @"select *from Customers";
            }
            else
            {
                query = @"select *from Customers where Name = '" + name+"';";
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }



        public bool Delete(string code)
        {
            bool chk = false;

            string findIdQuery = @"select *from Customers where Code = '" +code+"';";

            sqlConnection.Open();

            sqlCommand.CommandText = findIdQuery;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string id = "";
            if (sqlDataReader.Read())
            {
                id = sqlDataReader["Id"].ToString();
            }

            int Id = Convert.ToInt32(id);

            sqlConnection.Close();
            sqlConnection.Open();

            string deleteQuery = @"Delete from Customers where Id = " + Id;
            sqlCommand.CommandText = deleteQuery;
            int isDeleted = sqlCommand.ExecuteNonQuery();
            if (isDeleted > 0)
            {
                chk = true;
            }
            return chk;

        }
    }
}