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

        public void refreshForm()
        {
            try
            {
                //hello
                string showAll = "Select * FROM user";

                //
                MySqlConnection connect = new MySqlConnection(database);

                //
                MySqlCommand command = new MySqlCommand(showAll, connect);

                //
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.SelectCommand = command;

                DataTable table = new DataTable();

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
        }

        //onload Form
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshForm();
        }

        //Create user
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //create user
                string create = "Insert Into user(firstName, lastName) Values ('" + textBox1.Text + "', '" + textBox2.Text + "')";

                //connects to db
                MySqlConnection connect = new MySqlConnection(database);
                
                //command
                MySqlCommand command = new MySqlCommand(create, connect);
                MySqlDataReader myReader;
                connect.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("User Added!");

                refreshForm();

                //clears first name and last name textbox
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //delete user
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //create user
                string create = "Delete From user Where id="+textBox3.Text;

                //connects to db
                MySqlConnection connect = new MySqlConnection(database);

                //command
                MySqlCommand command = new MySqlCommand(create, connect);
                MySqlDataReader myReader;
                connect.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("User Deleted!");

                refreshForm();

                //clears first name and last name textbox
                textBox3.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
