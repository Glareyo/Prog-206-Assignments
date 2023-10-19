// Using the classes that'll read the SQL Client
using System.Data.SqlClient;
using Wk6_HW;

DataHandler data = new DataHandler();

Console.WriteLine("Press ENTER ==> Execute Code");
Console.ReadLine();
Console.WriteLine("Executing");


data.InitDataCreation();


foreach(List<string> dataStrings in data.allFiles[0].Data)
    foreach(string s in dataStrings)
        Console.WriteLine(s);


Console.ReadLine();


//Get the database to a string
//This builds a string that will connect to the target database
SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();

mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB"; // Connect to the server holding the table
mySqlConBldr["Trusted_Connection"] = true; //Ensure that the connection is trusted
mySqlConBldr["Integrated Security"] = "SSPI"; // Not too sure what this is 
mySqlConBldr["Initial Catalog"] = "PROG260FA23"; // Connect to the target database that holds the table

string sqlConStr = mySqlConBldr.ToString();

using (SqlConnection conn = new SqlConnection(sqlConStr))
{
    conn.Open();
    //Add a new row
    Console.WriteLine("\n\nInserting a new Row\n\n");
    foreach(List<string> item in data.allFiles[0].Data)
    {
        string inlineSQL = @"INSERT [dbo].[Produce] ([Name],[Location],[Price],[UoM],[Sell_by_Date])";
        inlineSQL += $" VALUES ('{item[0]}','{item[1]}','{item[2]}',{item[3]},{item[4]})";
        
        using (var command = new SqlCommand(inlineSQL, conn))
        {
            var query = command.ExecuteNonQuery();
        }
    }



    conn.Close();
}