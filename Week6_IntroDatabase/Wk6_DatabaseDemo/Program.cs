using System.Data.SqlClient;

Console.WriteLine("Press ENTER ==> Execute Code");
Console.ReadLine();
Console.WriteLine("Executing");


//Get the database to a string
SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();

mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB";
mySqlConBldr["Trusted_Connection"] = true;
mySqlConBldr["Integrated Security"] = "SSPI";
mySqlConBldr["Initial Catalog"] = "PROG260FA23";
string sqlConStr = mySqlConBldr.ToString();


//Begin reading database
using (SqlConnection conn = new SqlConnection(sqlConStr))
{
    conn.Open();

    Console.WriteLine("Reading");

    //Executes the code in SQL, exactly the code from SSMS
    string inlineSQL = @"Select * from Game";
    using (var command = new SqlCommand(inlineSQL, conn))
    {
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            //Print data
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
    //Add a new row
    Console.WriteLine("\n\nInserting a new Row\n\n");
    string inlineSQL = @"INSERT [dbo].[Game] ([Name],[Publisher],[Release_Date],[Sold],[Rating]) VALUES ('NO IDEAD','Lucasfilm Games','10-01-1990',NULL,94)";
    using (var command = new SqlCommand(inlineSQL, conn))
    {
        var query = command.ExecuteNonQuery();
    }
    conn.Close();
}

Console.WriteLine("Reaching Here");
Console.ReadLine();