using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_project
{
    public partial class Form1 : Form
    {
        private int AutoId = 1;
        BindingList<Car> CarRecord = new BindingList<Car>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CarRecord;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Customize Button Code
            if(checkBox1.Checked)
            {
                dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                dataGridView1.Columns[0].Visible = false;
            }
            if(checkBox2.Checked)
            {
                dataGridView1.Columns[1].Visible = true;
            }
            else
            {
                dataGridView1.Columns[1].Visible = false;
            }
            if(checkBox3.Checked)
            {
                dataGridView1.Columns[2].Visible = true;
            }
            else
            {
                dataGridView1.Columns[2].Visible = false;
            }
            if(checkBox4.Checked)
            {
                dataGridView1.Columns[3].Visible = true;
            }
            else
            {
                dataGridView1.Columns[3].Visible = false;
            }
            if(checkBox5.Checked)
            {
                dataGridView1.Columns[4].Visible = true;
            }
            else
            {
                dataGridView1.Columns[4].Visible = false;
            }
            if(checkBox6.Checked)
            {
                dataGridView1.Columns[5].Visible = true;
            }
            else
            {
                dataGridView1.Columns[5].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Add a New Car
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                for (int i = 0; i < CarRecord.Count; i++)
                    if (textBox2.Text == CarRecord[i].Model && textBox3.Text == CarRecord[i].Year && textBox4.Text == CarRecord[i].GearBox && textBox5.Text == CarRecord[i].Color && textBox6.Text == CarRecord[i].MaxSpeed)
                    {
                        MessageBox.Show("This car Already Exist", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                CarRecord.Add(new Car { Id = AutoId, Model = textBox2.Text, Year = textBox3.Text, GearBox = textBox4.Text, Color = textBox5.Text, MaxSpeed = textBox6.Text });
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();
                AutoId++;
            }
            else
            {
                MessageBox.Show("Please Fill in all the Text Boxes", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (textBox2.Text == "")
                    errorProvider1.SetError(textBox2, "Input the car Model first");
                else
                    errorProvider1.Clear();

                if (textBox3.Text == "")
                    errorProvider2.SetError(textBox3, "Input the production Year first");
                else
                    errorProvider2.Clear();

                if (textBox4.Text == "")
                    errorProvider3.SetError(textBox4, "Input the car Gear Box first");
                else
                    errorProvider3.Clear();
                if(textBox5.Text == "")
                    errorProvider4.SetError(textBox5, "Input the car colour first");
                else
                    errorProvider4.Clear();
                if (textBox6.Text == "")
                    errorProvider5.SetError(textBox6, "input the speed first");
                else
                    errorProvider5.Clear();
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Remove the Selected Car Button
            try
            {
                int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString()) - 1;
                CarRecord.RemoveAt(index);
                for (int i = index; i < CarRecord.Count; i++)
                    CarRecord[i].Id--;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
           catch
            {
                MessageBox.Show("You must add a car first", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Find the number of Automatic or Manual Cars
                if(CarRecord.Count!=0)
                {
                    for (int i = 0; i < CarRecord.Count; i++)
                    {
                        if (radioButton1.Checked)
                        {
                            int mcount = 0;
                            for (int m = 0; m < CarRecord.Count; m++)
                            {
                                if (CarRecord[m].GearBox == "Manual" || CarRecord[m].GearBox == "manual")
                                {
                                    mcount++;
                                }
                            }
                            MessageBox.Show("Number of Manual Cars is/are:" + mcount, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        if (radioButton2.Checked)
                        {
                            int acount=0;
                            for (int a = 0; a < CarRecord.Count; a++)
                            {
                                if (CarRecord[a].GearBox == "Automatic" || CarRecord[a].GearBox == "automatic")
                                {
                                acount++;
                                }
                            }
                            MessageBox.Show("Number of Automatic Cars is/are:" + acount, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Please Checke one of the Radio Buttons", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Please enter car details first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
        }
            private void button5_Click(object sender, EventArgs e)
            {
            //find the fastest Car
            try
            {
                int fastest = int.Parse(CarRecord[0].MaxSpeed);
                int i, fastest_car;
                fastest_car = 0;
                for (i = 1; i < CarRecord.Count; i++)
                {
                    if (int.Parse(CarRecord[i].MaxSpeed) > fastest)
                    {
                        fastest = int.Parse(CarRecord[i].MaxSpeed);
                        fastest_car = i;
                    }
                }
                MessageBox.Show("The Fastest Car amongst them is: " + "Id: " +
                                CarRecord[fastest_car].Id + " MODEL: " +
                                CarRecord[fastest_car].Model + " YEAR: " +
                                CarRecord[fastest_car].Year + "  GEAR BOX: " +
                                CarRecord[fastest_car].GearBox + "  COLOR: " +
                                CarRecord[fastest_car].Color + "  MAX SPEED: " +
                                CarRecord[fastest_car].MaxSpeed);
            }
            catch
            {
                MessageBox.Show("The form is Empty", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Visit the car company website
            try
            {
                    if (comboBox1.SelectedItem.ToString() == " Volkswagen")
                {
                    System.Diagnostics.Process.Start("https://www.vw.com.cy/en.html");
                }
                else if (comboBox1.SelectedItem.ToString() == "Toyota")
                {
                    System.Diagnostics.Process.Start("https://global.toyota/");
                }
                else if (comboBox1.SelectedItem.ToString() == "Mercedes")
                {
                    System.Diagnostics.Process.Start("https://www.mercedes-benz.com/en/");
                }
                else if (comboBox1.SelectedItem.ToString() == "Ford")
                {
                    System.Diagnostics.Process.Start("https://www.ford.com/");
                }
                else if (comboBox1.SelectedItem.ToString() == "Tesla")
                {
                    System.Diagnostics.Process.Start("https://www.tesla.com/en_eu");
                }

            }

            catch
            {
                MessageBox.Show("Please Select the company website you want to go to");
            }
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedCells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedCells[5].Value.ToString();
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();
            }
           catch
            {
                MessageBox.Show("Add a car");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !(int.TryParse(e.KeyChar.ToString(), out isNumber) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !(int.TryParse(e.KeyChar.ToString(), out isNumber) || e.KeyChar == (char)Keys.Back);
        }
    }
}
