using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Integration
{
    public partial class Form1 : Form
    {
        static string connectionString = @"server=127.0.0.1;port=3306;uid=root;password=;database=mysql;"; //Строка подключения к бд

        public string col, zapros, otvet, combobox;
        public int colvo;
 
        private MySqlDataAdapter mySqlDataAdapter;
       

        MySqlConnection DBconnect = new MySqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnect.Open();
            MySqlCommand coom = new MySqlCommand("SELECT COUNT(id) FROM `tasks_task`", DBconnect);
            col = coom.ExecuteScalar().ToString();
            colvo = Convert.ToInt32(col);
            InfoDataBase.Text = "Записей из БД: " + colvo;
            DBconnect.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditFromDatabase();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditOneFromDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

   

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(comboBox2, "Выберите статус");
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Введите количество записей");
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(comboBox3, "Выберите статус");
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox2, "Введите количество записей");
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(comboBox1, "Выберите желаемый фильтр для записей");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //где Form2 - название вашей формы
            frm2.Show();
        }

        private void EditOneFromDatabase()
        {
            int number = int.Parse(textBox2.Text);


            string selectedState2 = comboBox3.SelectedItem.ToString();
            switch (selectedState2)
            {
                case "New":
                    DBconnect.Open();    
                    MySqlCommand myCommand2 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '1' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter2 = new MySqlDataAdapter(myCommand2);
                    DataSet DS2 = new DataSet();

                    myCommand2.ExecuteNonQuery();
                    DBconnect.Close();
                    LoadData();
                    break;

                case "Verified":
                    DBconnect.Open();
                    
                    MySqlCommand myCommand3 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '2' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter3 = new MySqlDataAdapter(myCommand3);
                    DataSet DS3 = new DataSet();

                    myCommand3.ExecuteNonQuery();
              
                    DBconnect.Close();
                    LoadData();
                    break;

                case "In progress":
                    DBconnect.Open();
                    MySqlCommand myCommand4 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '3' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter4 = new MySqlDataAdapter(myCommand4);
                    DataSet DS4 = new DataSet();

                    myCommand4.ExecuteNonQuery();
          
                    DBconnect.Close();
                    LoadData();
                    break;
                case "Postponed":
                    DBconnect.Open();

                    MySqlCommand myCommand5 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '4' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter5 = new MySqlDataAdapter(myCommand5);
                    DataSet DS5 = new DataSet();

                    myCommand5.ExecuteNonQuery();
                    
                    DBconnect.Close();
                    LoadData();
                    break;
                case "Canceled":
                    DBconnect.Open();

                    MySqlCommand myCommand6 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '5' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter6 = new MySqlDataAdapter(myCommand6);
                    DataSet DS6 = new DataSet();

                    myCommand6.ExecuteNonQuery();
                  
                    DBconnect.Close();
                    LoadData();
                    break;

                case "Resumed":
                    DBconnect.Open();

                    MySqlCommand myCommand7 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '6' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter7 = new MySqlDataAdapter(myCommand7);
                    DataSet DS7 = new DataSet();

                    myCommand7.ExecuteNonQuery();
                    
                    DBconnect.Close();
                    LoadData();
                    break;

                case "Completed":
                    DBconnect.Open();

                    MySqlCommand myCommand8 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '7' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter8 = new MySqlDataAdapter(myCommand8);
                    DataSet DS8 = new DataSet();

                    myCommand8.ExecuteNonQuery();
                    

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Reconciliation":
                    DBconnect.Open();

                    MySqlCommand myCommand9 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '8' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter9 = new MySqlDataAdapter(myCommand9);
                    DataSet DS9 = new DataSet();
                    myCommand9.ExecuteNonQuery();
                  
                    DBconnect.Close();
                    LoadData();
                    break;

                case "Blocked":
                    DBconnect.Open();
                    MySqlCommand myCommand10 = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '9' WHERE `tasks_task`.`id` = {number}", DBconnect);
                    MySqlDataAdapter DataAdapter10 = new MySqlDataAdapter(myCommand10);
                    DataSet DS10 = new DataSet();

                    myCommand10.ExecuteNonQuery();

                    DBconnect.Close();
                    LoadData();
                    break;
                default:
                    MessageBox.Show("Вы ввели неверный статус!");
                    break;
            }
            LoadData();

        }
        private void EditFromDatabase()
        {
            string selectedState2 = comboBox2.SelectedItem.ToString();
            switch (selectedState2)
            {
                case "New":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '1' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Verified":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '2' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "In progress":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '3' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Postponed":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '4' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Canceled":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '5' WHERE `tasks_task`.`id` = {i}", DBconnect); 
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }
                 
                    DBconnect.Close();
                    LoadData();
                    break;
                case "Resumed":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '6' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Completed":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '7' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Reconciliation":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '8' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                case "Blocked":
                    DBconnect.Open();

                    for (int i = 0; i <= int.Parse(textBox1.Text); i++)
                    {
                        MySqlCommand myCommand = new MySqlCommand($"UPDATE `tasks_task` SET `status_id` = '9' WHERE `tasks_task`.`id` = {i}", DBconnect);
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(myCommand);
                        DataSet DS = new DataSet();

                        myCommand.ExecuteNonQuery();
                    }

                    DBconnect.Close();
                    LoadData();
                    break;
                default:
                    MessageBox.Show("Вы ввели неверный статус!");
                    break;
            }
            //UPDATE `tasks_task` SET `status_id` = '5' WHERE `tasks_task`.`id` = 1
            //UPDATE `tasks_task` SET `status_id` = '1' WHERE `tasks_task`.`id` = 1
            //UPDATE `tasks_task` SET `status_id` = '1' WHERE `tasks_task`.`id` = 2
        }
        private void LoadData()
        {

            string selectedState = comboBox1.SelectedItem.ToString();

            DBconnect.Open();
            mySqlDataAdapter = new MySqlDataAdapter($"SELECT id, subject, status_id, date_added FROM `tasks_task` ORDER BY `tasks_task`.`{selectedState}` ASC", DBconnect);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];

            DBconnect.Close();
        }
    }
}
