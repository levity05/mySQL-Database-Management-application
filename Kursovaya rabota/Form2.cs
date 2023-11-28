using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursovaya_rabota
{
    public partial class Form2 : Form
    {
        private Database connect;
        private MySqlCommand command;
        private MySqlDataAdapter dataadapter;
        private DataTable datatable;
        public event Action DataAdded;
        public Form2()
        {
            InitializeComponent();
            connect = new Database(); 
            connect.Connect(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("INSERT INTO employees(Employee_id, Last_name, First_name, Middle_name, Departament) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", connect.cn);
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

        private void LoadData()
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("SELECT * FROM employees", connect.cn);
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
        private void LoadComboBox()
        {
            string sql = "SELECT * FROM Departments";
            using (MySqlCommand cmd = new MySqlCommand(sql, connect.cn))    
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox1.ValueMember = "Department_id";
                comboBox1.DisplayMember = "Department_id";
                comboBox1.DataSource = table;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                Close();
        }
    }

}
