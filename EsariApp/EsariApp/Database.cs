using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsariApp.Tables;
using SQLite;

namespace EsariApp
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database (string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RegisterUserTable>();

        }

    }
}
