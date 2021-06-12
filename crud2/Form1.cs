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

namespace crud2
{
    public partial class Form1 : Form
    {

        //database
        string database = "datasource=localhost; port=3306; username=root; password=; database=crud";

        public static MySqlConnection connect;
        public static MySqlCommand command;
        public static MySqlDataAdapter adapter;
        public static DataTable table;

        public static string sSql_ShowAll = DatabaseConnection.DatabaseClass.SQL_ShowAllRecords;

        public void setupDB()
        {
            connect = new MySqlConnection(database);
            adapter = new MySqlDataAdapter();
            table = new DataTable();
        }

        public void refreshForm()
        { 
            try
            { 
                connect.Open();
                command = new MySqlCommand(sSql_ShowAll, connect);  
                adapter.SelectCommand = command; 
                adapter.Fill(table);

                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public Form1()
        {
            InitializeComponent();
            
                setupDB();  
        }

        //onload Form
        private void Form1_Load(object sender, EventArgs e)
        {
          refreshForm();
        }

        //Create user
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Close();
            try
            { 
                //command
                MySqlCommand command = new MySqlCommand(DatabaseConnection.DatabaseClass.SQLBuidler_Insert(textBox1.Text, textBox2.Text), connect);
                MySqlDataReader myReader;
                connect.Open();
                myReader = command.ExecuteReader();
                connect.Close();
                MessageBox.Show("User Added!", "CRUD"); 
                //clears first name and last name textbox
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                refreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }  

        //delete user
        private void button2_Click(object sender, EventArgs e)
        {
            //Verification
            DialogResult dialogResult = MessageBox.Show("Are you sure?","CRUD", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                connect.Close();
                try
                {
                    command = new MySqlCommand(DatabaseConnection.DatabaseClass.SQLBuidler_Delete(textBox3.Text), connect);
                    MySqlDataReader myReader; 
                    connect.Open(); 
                    myReader = command.ExecuteReader(); 
                    connect.Close(); 
                    MessageBox.Show("User Deleted!", "CRUD"); 
                    refreshForm();  
                    textBox3.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }  
        } 

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}