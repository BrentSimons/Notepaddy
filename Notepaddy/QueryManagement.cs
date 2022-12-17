using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SQLite;

namespace Notepaddy
{
    public class QueryManagement
    {
        public IDbConnection getConnection()
        {
            // The SQLiteConnection class is a implementation of the IDbConnection interface for SQLite databases.
            // The connection string passed to the constructor specifies the path to the database file and the option to create a new database if it does not exist.
            return new SQLiteConnection(@"Data Source=.\NoteDatabase.db;New=true;");
        }

    }
}
