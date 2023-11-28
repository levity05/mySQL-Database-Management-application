using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursovaya_rabota
{
    public partial class Form5 : Form
    {
        private Database connect;
        private MySqlCommand command;
        private MySqlDataAdapter dataadapter;
        private DataTable datatable;
        public event Action DataAdded;
        public Form5()
        {
            InitializeComponent();
            connect = new Database();
            connect.Connect();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("SELECT * FROM departments", connect.cn);
                command.ExecuteNonQuery();
                datatable = new DataTable();
                dataadapter = new MySqlDataAdapter(command);
                dataadapter.Fill(datatable);
                connect.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("INSERT INTO departments(Department_id, Department_name) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", connect.cn);
                command.ExecuteNonQuery();
                connect.cn.Close();
                DataAdded?.Invoke();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Close();
        }
    }
}
