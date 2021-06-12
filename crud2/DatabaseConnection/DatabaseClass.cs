using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace crud2.DatabaseConnection
{
    class DatabaseClass
    {
        public static string database = "datasource=localhost; port=3306; username=root; password=; database=crud";

        public static string SQL_ShowAllRecords = "Select * FROM user"; 
        public static string SQLBuidler_Insert(string FirstName, string LastName)
        { 
            return "Insert Into user(firstName, lastName) Values ('" + FirstName + "', '" + LastName + "')"; 
        } 
        public static string SQLBuidler_Delete(string ID)
        {
            return "Delete From user Where id=" + ID;
        }
    }
}
