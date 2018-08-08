using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Telemedicine
{
    public partial class Form2 : Form
    {
        MySqlConnection connect = new MySqlConnection("SERVER=localhost; USERID=root; PASSWORD=nuel; DATABASE=energy_db;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        int k;
        public Form2()
        {
            InitializeComponent();
        }
        private void comboSelect()
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //DISPLAY FULLSCREEN
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("You can only enter numeric values");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //Industrial Appliance
            if (comboBox1.Text == "Industrial Appliance")
            {
                comboBox2.Items.Clear();
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "SELECT * FROM gadget_tb WHERE Gadget_type='Industrial'";
                    da.SelectCommand = cmd;
                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox2.Items.Add(myReader.GetValue(1).ToString());
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            //OFFICE APPLIANCE
            if (comboBox1.Text == "Office Appliance")
            {
                comboBox2.Items.Clear();
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "SELECT * FROM gadget_tb WHERE Gadget_type='Office'";
                    da.SelectCommand = cmd;
                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox2.Items.Add(myReader.GetValue(1).ToString());
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            //HOME APPLIANCE
            if (comboBox1.Text == "Home Appliance")
            {
                comboBox2.Items.Clear();
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "SELECT * FROM gadget_tb WHERE Gadget_type='Home'";
                    da.SelectCommand = cmd;
                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox2.Items.Add(myReader.GetValue(1).ToString());
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            //COMBOBOX2 SELECTED VALUE CHANGE
            //ADDING THE SELECTED ITEMS TO THE DATAGRIDVIEW
            try
            {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "SELECT Power_rating FROM gadget_tb WHERE Gadget_name = '" + comboBox2.Text + " ' ";
                    da.SelectCommand = cmd;
                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        this.dataGridView1.Rows.Add("i", comboBox2.Text, myReader.GetValue(0).ToString());
                    }
                    connect.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // this.dataGridView1.Rows.Add("1", comboBox2.Text);   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //ARITHMETIC OPERATIONS GOES IN HERE
            {
                int dataRow = dataGridView1.CurrentCell.RowIndex;
                int quantityColumn = dataGridView1.CurrentCell.ColumnIndex;
                int powerColumn = dataGridView1.CurrentCell.ColumnIndex - 1;
                String quantityValue = this.dataGridView1.Rows[dataRow].Cells[quantityColumn].Value.ToString();
                String powerValue = this.dataGridView1.Rows[dataRow].Cells[powerColumn].Value.ToString();
                int quantityVal = int.Parse(quantityValue);
                int powerVal = int.Parse(powerValue);
                int result = quantityVal * powerVal;
                // MessageBox.Show("Your quantity column is " + quantityColumn + "powervalue is " + powerVal);

                //TO GET RESULT VALUE
                int resultColumn = this.dataGridView1.CurrentCell.ColumnIndex + 1;
                this.dataGridView1.Rows[dataRow].Cells[resultColumn].Value = result;
                MessageBox.Show("Your quantity value is " + quantityValue + " and your power value is " + powerValue);

                //COMPUTE
                decimal Total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column4"].Value);
                }
                textBox2.Text = Total.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}