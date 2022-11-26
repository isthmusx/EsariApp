using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace EsariApp.Tables
{
    public class RegisterUserTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StoreName { get; set; }


    }
}
