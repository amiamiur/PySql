using System;
using System.Data.SqlClient;

namespace ConnectDB
{
    class lesson3
    {
        static void Main(string[] args)
        {
            string conn_str = "Data Source=COMP7A2\\SQLEXPRESS;" +
                              "Initial Catalog=TestIndex2;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(conn_str);

            connection.Open();

            string [] sql_command = { "SELECT TOP 10 * FROM Table_1", "INSERT INTO Table_1(id,name,balance,credit) VALUES(@id,@name,@balance,@credit)"};

            SqlCommand command = new SqlCommand(sql_command[0], connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal balance = reader.GetDecimal(3);
                decimal credit = reader.GetDecimal(4);
                decimal diff_balance = reader.GetDecimal(5);

                Console.WriteLine($"----------------\n" +
                    $"ID: {id}\n" +
                    $"Имя: {name}\n" +
                    $"Баланс: {balance}\n" +
                    $"Снятие: {credit}\n" +
                    $"Остаток: {diff_balance}\n" +
                    $"----------------");
            }
        }
    }
}
