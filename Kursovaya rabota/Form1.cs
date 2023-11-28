using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kursovaya_rabota
{
    public partial class Form1 : Form
    {
        private Database connect;
        private MySqlCommand command;
        private MySqlDataAdapter dataadapter;
        private DataTable datatable;
        public static DataGridViewRow selectedrow;
        private string selectedTableName;

        public Form1()
        {
            InitializeComponent();
            connect = new Database();
            connect.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "departments")
            {
                Form5 dob = new Form5();
                dob.DataAdded += () => LoadData();
                dob.Show();
            }
            if (comboBox1.Text == "employees")
            {
                Form2 dob = new Form2();
                dob.DataAdded += () => LoadData();
                dob.Show();
            }
            if (comboBox1.Text == "empoyees_info")
            {
                Form4 dob = new Form4();
                dob.DataAdded += () => LoadData();
                dob.Show();
            }
            if (comboBox1.Text == "work_time")
            {
                Form6 dob = new Form6();
                dob.DataAdded += () => LoadData();
                dob.Show();
            }

        }

        private void LoadData()
        {
            if (comboBox1.Text == "departments")
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
                    dataGridView1.DataSource = datatable.DefaultView;
                    connect.cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "employees")
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
                    dataGridView1.DataSource = datatable.DefaultView;
                    connect.cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "empoyees_info")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("SELECT * FROM empoyees_info", connect.cn);
                    command.ExecuteNonQuery();
                    datatable = new DataTable();
                    dataadapter = new MySqlDataAdapter(command);
                    dataadapter.Fill(datatable);
                    dataGridView1.DataSource = datatable.DefaultView;
                    connect.cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "work_time")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("SELECT * FROM work_time", connect.cn);
                    command.ExecuteNonQuery();
                    datatable = new DataTable();
                    dataadapter = new MySqlDataAdapter(command);
                    dataadapter.Fill(datatable);
                    dataGridView1.DataSource = datatable.DefaultView;
                    connect.cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadTables();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "departments")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("DELETE FROM departments WHERE Department_id = '" + textBox1.Text + "'", connect.cn);
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Данные успешно удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "employees")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("DELETE FROM employees WHERE Employee_id = '" + textBox1.Text + "'", connect.cn);
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Данные успешно удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "empoyees_info")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("DELETE FROM empoyees_info WHERE Employee_info_id = '" + textBox1.Text + "'", connect.cn);
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Данные успешно удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "work_time")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("DELETE FROM work_time WHERE Traking_id = '" + textBox1.Text + "'", connect.cn);
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Данные успешно удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }
        
        private void dataDridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            if (comboBox1.Text == "departments")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            if (comboBox1.Text == "employees")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            if (comboBox1.Text == "empoyees_info")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            if (comboBox1.Text == "work_time")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "departments")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("UPDATE departments SET Department_name ='" + textBox2.Text + "' WHERE Department_id = '" + textBox1.Text + "' ", connect.cn);
                    command.ExecuteNonQuery();
                    connect.cn.Close();
                    LoadData();
                    MessageBox.Show("Данные успешно обновлены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "employees")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("UPDATE employees SET Last_name='" + textBox2.Text + "',First_name='" + textBox3.Text + "',Middle_name='" + textBox4.Text + "',Departament='" + textBox5.Text + "' WHERE Employee_id = '" + textBox1.Text + "' ", connect.cn);
                    command.ExecuteNonQuery();
                    connect.cn.Close();
                    LoadData();
                    MessageBox.Show("Данные успешно обновлены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "empoyees_info")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("UPDATE empoyees_info SET Employee='" + textBox2.Text + "', Addres='" + textBox3.Text + "', Phone_number='" + textBox4.Text + "', Email='" + textBox5.Text + "' WHERE Employee_info_id = '" + textBox1.Text + "'", connect.cn);
                    command.ExecuteNonQuery();
                    connect.cn.Close();
                    LoadData();
                    MessageBox.Show("Данные успешно обновлены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "work_time")
            {
                try
                {
                    connect.cn.Close();
                    connect.cn.Open();
                    command = new MySqlCommand("UPDATE work_time SET Employee_id='" + textBox2.Text + "',Date='" + textBox3.Text + "',Start_time='" + textBox4.Text + "',End_time='" + textBox5.Text + "',Lanch_start='" + textBox7.Text + "',Lanch_end='" + textBox8.Text + "' WHERE Traking_id = '" + textBox1.Text + "' ", connect.cn);
                    command.ExecuteNonQuery();
                    connect.cn.Close();
                    LoadData();
                    MessageBox.Show("Данные успешно обновлены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void LoadTables()
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                DataTable tableSchema = connect.cn.GetSchema("Tables");
                comboBox1.Items.Clear();

                foreach (DataRow row in tableSchema.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();

                    if (tableName == "departments" || tableName == "employees" || tableName == "empoyees_info" || tableName == "work_time")
                    {
                        comboBox1.Items.Add(tableName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.cn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedTableName = comboBox1.SelectedItem.ToString();
                string query = $"SELECT * FROM {selectedTableName}";

                using (MySqlCommand cmd = new MySqlCommand(query, connect.cn))
                {
                    connect.cn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, selectedTableName);
                    DataTable orderedTable = new DataTable();
                    foreach (DataColumn column in dataSet.Tables[selectedTableName].Columns)
                    {
                        orderedTable.Columns.Add(column.ColumnName, column.DataType);
                    }
                    foreach (DataRow row in dataSet.Tables[selectedTableName].Rows)
                    {
                        DataRow newRow = orderedTable.NewRow();
                        foreach (DataColumn column in orderedTable.Columns)
                        {
                            newRow[column.ColumnName] = row[column.ColumnName];
                        }
                        orderedTable.Rows.Add(newRow);
                    }

                    dataGridView1.DataSource = orderedTable;
                    LoadFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.cn.Close();
            }
        }

        private string[] GetColumnNames(string tableName)
        {
            try
            {
                connect.cn.Open();
                DataTable schemaTable = connect.cn.GetSchema("Columns", new[] { null, null, tableName });
                connect.cn.Close();

                string[] columnNames = new string[schemaTable.Rows.Count];
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    columnNames[i] = schemaTable.Rows[i]["COLUMN_NAME"].ToString();
                }

                return columnNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (connect.cn.State == ConnectionState.Open)
                {
                    connect.cn.Close();
                }
            }
        }

        private void LoadFields()
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                string selectedToble = comboBox1.SelectedItem.ToString();  
                string columnsQuery = $"SHOW COLUMNS FROM {selectedToble}";
                MySqlCommand columnsCmd = new
                MySqlCommand(columnsQuery, connect.cn);
                MySqlDataReader reader = columnsCmd.ExecuteReader();
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    string columnName = reader["Field"].ToString();
                    comboBox2.Items.Add(columnName);
                }
                connect.cn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                string selectedToble = comboBox1.SelectedItem.ToString();
                string selectedColumn = comboBox2.SelectedItem.ToString();
                string searchTerm = textBox6.Text;
                string searchQuery = $"SELECT * FROM {selectedToble} WHERE { selectedColumn} LIKE @searchTerm";
                MySqlCommand cmd = new MySqlCommand(searchQuery,connect.cn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataGridView1.DataSource = dataTable;
                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                connect.cn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); 
            }
        }

        private void btnSorn_Click(object sender, EventArgs e)
        {
            string selectedToble = comboBox1.SelectedItem.ToString();
            string selectedColumn = comboBox2.SelectedItem.ToString();
            string filterQuery = $"SELECT * FROM {selectedToble} ORDER BY { selectedColumn} ASC";
            MySqlCommand cmd = new MySqlCommand(filterQuery, connect.cn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
        }

        private void btnSearchInID_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();

                string searchQuery = "SELECT Employee_id, Last_name, First_name, Middle_name, Addres, Phone_number, Email " +
                     "FROM employees " +
                     "JOIN empoyees_info ON Employee_id = Employee " +
                     "WHERE Employee_id = @employeeId";
                MySqlCommand cmd = new MySqlCommand(searchQuery, connect.cn);
                cmd.Parameters.AddWithValue("@employeeId", textBox9.Text);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataGridView1.DataSource = dataTable;
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                connect.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInstuctionHelp_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "C:\\Users\\Acer\\OneDrive\\3 курс\\РПМ\\Проекты\\Финальная версия\\Инструкция.pdf";
                if (System.IO.File.Exists(filePath))
                {
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}