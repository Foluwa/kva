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
    public partial class Form3 : Form
    {
        MySqlConnection connect = new MySqlConnection("SERVER=localhost; USERID=root; PASSWORD=nuel; DATABASE=energy_db;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        int k;
        public Form3()
        {
            InitializeComponent();
        }
        void getData()
        {
            try
            {
                connect.Open();
                String id;
                cmd.Connection = connect;
                cmd.CommandText = "SELECT * FROM gadget_tb ";
                da.SelectCommand = cmd;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (myReader.Read())
                {
                    id = myReader.GetValue(0).ToString();
                    dataGridView1.Rows.Add(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString(), myReader.GetValue(2).ToString(), myReader.GetValue(3).ToString());
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //DISPLAY FULLSCREEN
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "INSERT INTO gadget_tb(Gadget_name,Power_rating,Gadget_type)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
                    k = cmd.ExecuteNonQuery();
                    if (k > 0)
                    {
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " successfully saved");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connect.Close();
                }
                getData();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //UPDATE
            try
            {
                connect.Open();
                int i;
                String ID = textBox4.Text;
                cmd.Connection = connect;
                cmd.CommandText = "UPDATE gadget_tb SET Gadget_name='" + textBox1.Text + "',Power_rating='" + textBox2.Text + "',Gadget_type='" + comboBox1.Text + "' WHERE ID=" + ID;
                i = cmd.ExecuteNonQuery();
                try
                {
                    if (i > 0)
                    {
                        MessageBox.Show(textBox1.Text + " " + textBox2.Text + " has been updated successfully ");
                    }
                    else 
                    {
                        MessageBox.Show("An Error occured, your Gadget was not added");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connect.Close();
                getData();
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                //comboBox1.Items.Clear();
                //comboBox1.Text.();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowno;
                rowno = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[rowno].Cells["Column2"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[rowno].Cells["Column3"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[rowno].Cells["Column1"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[rowno].Cells["Column4"].Value.ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //SORT APLHABETICALLY
            try
            {
                connect.Open();
                String id;
                cmd.Connection = connect; 
                cmd.CommandText = "SELECT ID,Gadget_name,Power_rating,Gadget_type FROM gadget_tb ORDER BY Gadget_name";
                da.SelectCommand = cmd;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (myReader.Read())
                {
                    id = myReader.GetValue(0).ToString();
                    dataGridView1.Rows.Add(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString(), myReader.GetValue(2).ToString(), myReader.GetValue(3).ToString());
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //SORT BY POWERRATING
            try
            {
                connect.Open();
                String id;
                cmd.Connection = connect;
                cmd.CommandText = "SELECT ID,Gadget_name,Power_rating,Gadget_type FROM gadget_tb ORDER BY Power_rating";
                da.SelectCommand = cmd;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (myReader.Read())
                {
                    id = myReader.GetValue(0).ToString();
                    dataGridView1.Rows.Add(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString(), myReader.GetValue(2).ToString(), myReader.GetValue(3).ToString());
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
            }
        }
    }
}
