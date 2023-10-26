// Nehemiah Cedillo
// FA23-PROG 260-01

//Credit: Documentation + Online Question on how to replace chars within a column
//https://stackoverflow.com/questions/814548/how-to-replace-a-string-in-a-sql-server-table-column
//https://www.w3schools.com/SQL/func_sqlserver_replace.asp

//Credit: How to add ' to strings using an escape => '' for a '
//https://stackoverflow.com/questions/5139770/escape-character-in-sql-server

//Credit:
//https://stackoverflow.com/questions/34851800/export-data-from-sql-server-to-text-file-in-c-sharp-saving-to-a-specific-folder
//Helped demonstrate how to print / create a file from SQL to a text file

// Credit: Leo Hazou
//Provided Presentation / Lectures on DataDesign

//Credit:
//https://www.w3schools.com/sql/sql_ref_not.asp
// Demonstrated the NOT Command for SQL

// Using the classes that'll read the SQL Client


using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Wk7_HW;
using static System.Net.WebRequestMethods;

DataHandler dataHandler = new DataHandler();



Console.WriteLine("Press ENTER ==> Execute Code");
Console.ReadLine();
Console.WriteLine("Executing");


dataHandler.InitDataCreation();

// Credit: Leo Hazou
//Provided Presentation / Lectures on DataDesign

//Get the database to a string
//This builds a string that will connect to the target database
SqlConnectionStringBuilder mySqlConBldr = new SqlConnectionStringBuilder();

mySqlConBldr["server"] = @"(localdb)\MSSQLLocalDB"; // Connect to the server holding the table
mySqlConBldr["Trusted_Connection"] = true; //Ensure that the connection is trusted
mySqlConBldr["Integrated Security"] = "SSPI"; // Not too sure what this is 
mySqlConBldr["Initial Catalog"] = "PROG260FA23"; // Connect to the target database that holds the table

string sqlConStr = mySqlConBldr.ToString();


Console.WriteLine("Press ENTER to Execute");
Console.ReadLine();

using (SqlConnection conn = new SqlConnection(sqlConStr))
{
    conn.Open();
    //Remove Data that is already in the table

    Console.WriteLine("Deleting Data from table");
    string inlineSQL_delete = @"delete from dbo.Characters";

    ExecuteSQLCommandOnly(inlineSQL_delete, conn);


    //Add data row
    Console.WriteLine("\n\nInserting Data of Characters\n\n");
    foreach (List<string> item in dataHandler.allFiles[0].Data)
    {
        // Insert the produce
        string inlineSQL_one = @"INSERT INTO [dbo].[Characters] ([Character],[Type],[Map_Location],[Original_charachter],[Sword_Fighter],[Magic_User])";
        inlineSQL_one += $" VALUES ('{item[0]}','{item[1]}','{item[2]}','{item[3]}','{item[4]}','{item[5]}')";

        ExecuteSQLCommandOnly(inlineSQL_one, conn);
    }


    Console.WriteLine("Writing Full Report");
    // Inner Join All Information together
    string inlineSQL_InnerJoinAll = @"select Characters.Character,Types.Type,Locations.Location,Characters.Original_charachter,Characters.Sword_Fighter,Characters.Magic_User
From Characters
Inner Join Locations
ON Characters.Map_Location = Locations.LocationID
Inner Join Types
ON Characters.Type = Types.TypeID
";

    ExecuteSQLCommand(inlineSQL_InnerJoinAll, conn, "FullReport");


    Console.WriteLine("Writing Names of those who are lost");
    //Lost People
    string inlineSQL_PrintLostPeople = @"Select Characters.Character
From Characters
Left Outer Join Locations
ON Characters.Map_Location = Locations.LocationID
Where Locations.LocationID is NULL";

    ExecuteSQLCommand(inlineSQL_PrintLostPeople, conn, "Lost");



    Console.WriteLine("Writing sword wielders who are non human");
    //Sword Wielders who are non human
    //SwordNonHuman

    //Credit:
    //https://www.w3schools.com/sql/sql_ref_not.asp
    // Demonstrated the NOT Command for SQL

    string inlineSQL_PrintSwordNonHuman = @"Select Characters.Character, Types.Type
From Characters
Left Outer Join Types
ON Characters.Type = Types.TypeID
Where Not Types.Type = 'Human' and Characters.Sword_Fighter = 1";

    ExecuteSQLCommand(inlineSQL_PrintSwordNonHuman, conn, "SwordNonHuman");

    conn.Close();
}


//Methods for executing SQL Commands
//Reduce redundancy

void ExecuteSQLCommandOnly(string targetCommand, SqlConnection conn)
{
    using (var command = new SqlCommand(targetCommand, conn))
    {
        var query = command.ExecuteNonQuery();
    }
}
void ExecuteSQLCommand(string targetCommand, SqlConnection conn, string targetTextFile)
{
    using (var command = new SqlCommand(targetCommand, conn))
    {
        var query = command.ExecuteNonQuery();

        //Credit:
        //https://stackoverflow.com/questions/34851800/export-data-from-sql-server-to-text-file-in-c-sharp-saving-to-a-specific-folder
        //Helped demonstrate how to print / create a file from SQL to a text file
        using (SqlDataAdapter myAdapter = new SqlDataAdapter()) //Enables editing of the sql table
        {
            command.Connection = conn;
            myAdapter.SelectCommand = command;

            //Target path to write the file
            string resultsPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\data\PrintedResults");
            resultsPath = Path.Combine(resultsPath, $"{targetTextFile}.txt");

            using (StreamWriter targetFile = new StreamWriter(resultsPath))
            {
                using (DataTable myTable = new DataTable()) //Create a new table
                {
                    myAdapter.Fill(myTable); //Update the table with information

                    foreach (DataRow dataRow in myTable.Rows) //Run through each row
                    {
                        string info = "";
                        Console.WriteLine();
                        foreach (DataColumn dataColumn in myTable.Columns) //Run through each column
                        {
                            //Add the information to the temp string
                            info += $"{dataRow[dataColumn.ColumnName]}, ";
                        }
                        //Write the info into the file
                        targetFile.WriteLine(info);
                    }
                }
            }


        }
    }
}