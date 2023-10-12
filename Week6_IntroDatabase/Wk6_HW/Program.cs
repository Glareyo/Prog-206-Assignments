// Using the classes that'll read the SQL Client
using System.Data.SqlClient;

Console.WriteLine("Press ENTER ==> Execute Code");
Console.ReadLine();
Console.WriteLine("Executing");



//Get the database to a string
//This builds a string that will connect to the target database
SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();

mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB"; // Connect to the server holding the table
mySqlConBldr["Trusted_Connection"] = true; //Ensure that the connection is trusted
mySqlConBldr["Integrated Security"] = "SSPI"; // Not too sure what this is 
mySqlConBldr["Initial Catalog"] = "PROG260FA23"; // Connect to the target database that holds the table

string sqlConStr = mySqlConBldr.ToString();