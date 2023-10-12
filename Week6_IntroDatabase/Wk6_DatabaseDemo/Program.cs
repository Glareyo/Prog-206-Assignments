using System.Data.SqlClient;

SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();

mySqlConBldr["server"] = @"(localdb)\MMSQLLocalDB";
mySqlConBldr["Trusted_Connection"] = true;
mySqlConBldr["Integrated Security"] = "SSPI";
mySqlConBldr["Initial Catalog"] = "PROG260FA23";
string sqlConStr = mySqlConBldr.ToString();

using (SqlConnection conn = new SqlConnection(sqlConStr))
{
    conn.Open();
    string inlineSQL = @"Select * from Game";
    using (var command = new SqlCommand(inlineSQL, conn))
    {
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var value = $"{reader.GetValue(0)},{reader.GetValue(1)},{reader.GetValue(2)},{reader.GetValue(3)},{reader.GetValue(4)}";
            Console.WriteLine(value);
        }
        reader.Close();
    }
    conn.Close();
}

using (SqlConnection conn = new SqlConnection(sqlConStr))
{
    conn.Open();
    string inlineSQL = @"INSERT [dbo].[Game] ([Name],[Publisher],[Release_Date],[Sold],[Rating]) VALUES";
    using (var command = new SqlCommand(inlineSQL, conn))
    {
        var query = command.ExecuteNonQuery();
    }
    conn.Close();
}