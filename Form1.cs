using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace TestMyLib
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text+";";
            string CommandText = "select * from people";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: "+result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, razryad.razryad,razryad.zvanie, razryad.date_zvanie, razryad.sud_kval, razryad.date_sud_kval,razryad.tren_kat, razryad.date_tren_kat from people join razryad USING(e_id)";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, attestaciya.HC, attestaciya.CC, attestaciya.BC, attestaciya.reattest from people join attestaciya USING(e_id) where people.e_id = "+textBox15.Text;
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView3.Columns.Clear();
                dataGridView3.DataSource = result.ResultData.DefaultView;
                if (result.ResultData.Rows.Count > 0)
                {
                    MessageBox.Show("есть информация");
                    string dat = dataGridView3.Rows[0].Cells[7].Value.ToString();
                    DateTime date1 = new DateTime(Convert.ToInt32(dat.Substring(6, 4)), Convert.ToInt32(dat.Substring(3, 2)), Convert.ToInt32(dat.Substring(0, 2)), 0, 00, 0);
                    DateTime localTime = DateTime.Now;
                    
                    if (localTime.Year - date1.Year < 4)
                    {
                        System.Drawing.SolidBrush brush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                        Graphics gr = Graphics.FromImage(bitmap);
                        gr.FillEllipse(brush1, new System.Drawing.Rectangle(0, 0, 90, 90));
                        pictureBox1.Image = bitmap;
                        brush1.Dispose();
                        label20.Text = date1.ToString() + " В этом году переаттестация не требуется.";
                    }
                    else
                    {
                        System.Drawing.SolidBrush brush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                        Graphics gr = Graphics.FromImage(bitmap);
                        gr.FillEllipse(brush1, new System.Drawing.Rectangle(0, 0, 90, 90));
                        pictureBox1.Image = bitmap;
                        brush1.Dispose();
                        label20.Text = date1.ToString() + " \nВ этом году требуется переаттестация.\nСверьтесь с датой из таблицы для получения даты действия последней переаттестации.";
                    }
                    
                }
                else
                    MessageBox.Show("не найдено");
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, sorevnovaniya.date_sor, sorevnovaniya.name_sor, sorevnovaniya.mesto, sorevnovaniya.sud_dolgn from people join sorevnovaniya USING(e_id)";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, event_name, event_date from people join events USING(e_id)";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "insert into people (surname,fname,otch,birth,raion,town,street,home_index,phone,email,educ,work) values ('"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+maskedTextBox1.Text+"','"+comboBox1.Text +"','"+textBox7.Text+"','"+textBox8.Text+"',"+textBox9.Text+","+textBox10.Text+",'"+textBox11.Text+"','"+textBox12.Text+"','"+textBox13.Text+"')";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button1_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "delete FROM attestaciya where attestaciya.e_id = " + textBox14.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            CommandText = "delete FROM events where events.e_id = " + textBox14.Text + ";";
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            CommandText = "delete FROM razryad where razryad.e_id = " + textBox14.Text + ";";
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            CommandText = "delete FROM sorevnovaniya where sorevnovaniya.e_id = " + textBox14.Text + ";";
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            CommandText = "delete FROM people where people.e_id = " + textBox14.Text + ";";
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button1_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "update people set surname = '"+textBox4.Text+"', fname = '"+textBox5.Text+"', otch = '"+textBox6.Text+"', birth = '"+maskedTextBox1.Text+"', raion = '"+comboBox1.Text+"', town = '"+textBox7.Text+"', street = '"+textBox8.Text+"', home_index = "+textBox9.Text+", phone = "+textBox10.Text+", email = '"+textBox11.Text+"', educ = '"+textBox12.Text+"', work = '"+textBox13.Text+"' where people.e_id = "+textBox14.Text+";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button1_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select * from people where surname like '"+textBox3.Text+"';";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "insert into attestaciya (e_id,HC,CC,BC,reattest) values (" + textBox16.Text + ",'" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + maskedTextBox4.Text + "','" + maskedTextBox5.Text + "')";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "update attestaciya set e_id = '" + textBox16.Text + "', HC = '" + maskedTextBox2.Text + "', CC = '" + maskedTextBox3.Text + "', BC = '" + maskedTextBox4.Text + "', reattest = '" + maskedTextBox5.Text + "' where e_id = "+textBox16.Text+" ;";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "delete FROM attestaciya where attestaciya.e_id = " + textBox15.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button3_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "insert into razryad (e_id, razryad, zvanie, date_zvanie, sud_kval, date_sud_kval, tren_kat, date_tren_kat) values ("+textBox18.Text+", '"+comboBox2.Text+"', '"+textBox19.Text+"', '"+maskedTextBox6.Text+"', '"+comboBox3.Text+"', '"+maskedTextBox7.Text+"', '"+comboBox4.Text+"', '"+maskedTextBox8.Text+"')";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button2_Click(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "update razryad set e_id="+textBox18.Text+",razryad.razryad = '" + comboBox2.Text + "',zvanie='" + textBox19.Text + "',date_zvanie='" + maskedTextBox6.Text + "',sud_kval='" + comboBox3.Text + "',date_sud_kval='" + maskedTextBox7.Text + "',tren_kat='" + comboBox4.Text + "',date_tren_kat='" + maskedTextBox8.Text + "' where razryad.e_id = " + textBox18.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button2_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "delete FROM razryad where razryad.e_id = " + textBox17.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button2_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, razryad.razryad,razryad.zvanie, razryad.date_zvanie, razryad.sud_kval, razryad.date_sud_kval,razryad.tren_kat, razryad.date_tren_kat from people join razryad USING(e_id) where razryad.e_id="+textBox17.Text+";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, sorevnovaniya.date_sor, sorevnovaniya.name_sor, sorevnovaniya.mesto, sorevnovaniya.sud_dolgn from people join sorevnovaniya USING(e_id) where sorevnovaniya.e_id=" + textBox20.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView4.Columns.Clear();
                dataGridView4.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "delete FROM sorevnovaniya where sorevnovaniya.e_id = " + textBox20.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button4_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "insert into sorevnovaniya (e_id, date_sor, name_sor, mesto, sud_dolgn) values (" + textBox21.Text + ", '" + maskedTextBox9.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "')";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button4_Click(sender, e);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "update sorevnovaniya set e_id=" + textBox21.Text + ",date_sor = '" + maskedTextBox9.Text + "',name_sor='" + textBox22.Text + "',mesto='" + textBox23.Text + "',sud_dolgn='" + textBox24.Text + "' where sorevnovaniya.e_id = " + textBox21.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button4_Click(sender, e);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "select people.e_id, people.surname, people.fname, people.birth, event_name, event_date from people join events USING(e_id) where events.e_id = "+textBox25.Text;
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            if (result.HasError == false)
            {
                dataGridView5.Columns.Clear();
                dataGridView5.DataSource = result.ResultData.DefaultView;
                MessageBox.Show("найдено записей: " + result.ResultData.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "delete FROM events where events.e_id = " + textBox25.Text;
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button5_Click(sender, e);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "insert into events (e_id, event_name, event_date) values (" + textBox26.Text + ", '" + textBox27.Text + "', '" + maskedTextBox10.Text + "')";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button5_Click(sender, e);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string Connect = "Database=tourist;Data Source=localhost;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";
            string CommandText = "update events set e_id=" + textBox26.Text + ",event_name = '" + textBox27.Text + "',event_date='" + maskedTextBox10.Text + "' where events.e_id = " + textBox26.Text + ";";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(CommandText, Connect);
            MessageBox.Show("Выполнено");
            button5_Click(sender, e);
        }

    }
}
