using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace parcerHTML_bastchange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Web"].Value);
                string b = a.Trim();
                    

                System.Diagnostics.Process.Start(b);
             }
            
        }

      private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
            WebClient w = new WebClient();
            string page = w.DownloadString("http://www.bestchange.ru/list.html");

            DataSet ds = new DataSet();
            ds.Tables.Add("my");

            string[] col = { "Обменник", "Резервы", "Курсов", "Статус","Web" };


            foreach (string nameCol in col)
            {
                ds.Tables[0].Columns.Add(nameCol);

            }



            string srcData = "<td class=\"bj\"><div class=\"pa\"><a rel=\"nofollow\" target=\"_blank\" href=\"(.*?)\" (.*?)"
                         + "<div class=\"ca\">(.*?)</div></div></div></td>"
                         + "<td class=\"ar arp\">(.*?)</small></td>\n"
                        + "<td class=\"ar arp\">(.*?)</small></td>\n"
                        + "<td class=\"bj bp\">(.*?)</td>\n"
                     ;


            string row = null;
            string[] rvalue = null;
            foreach (Match match in Regex.Matches(page, srcData))
            {

                row = match.Groups[3].Value + " | "
                                      + match.Groups[4].Value + " | "
                                      + match.Groups[5].Value + " | "
                                      + match.Groups[6].Value + " | "
                                     + match.Groups[1].Value  ;
               


                rvalue = row.Split(new Char[] { '|' });
                
                ds.Tables[0].Rows.Add(rvalue);
               
                
                dataGridView1.DataSource = ds.Tables[0];
                
               
                row = null;
                rvalue = null;
                
               
                    
                dataGridView1.Columns[4].Visible = false;
            }
            string s = " &ndash;&nbsp; ";
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    if (s == dataGridView1[j, i].Value.ToString())
                    {
                        dataGridView1[j, i].Value = "Недоступно"; 
                 
                    }
                    
                }
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void button24_Click(object sender, EventArgs e)
        {
            
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
            {   
                WebClient w = new WebClient();
              string a = comboBox1.SelectedItem.ToString();
              string b = comboBox2.SelectedItem.ToString(); 
                string page = w.DownloadString("http://www.bestchange.ru/"+ a +"-to-"+ b +".html" );
                
                DataSet ds = new DataSet();
               
                ds.Tables.Add("my");
                dataGridView1.Columns.Clear();
                
                
               

                string[] col = { "Обменник", "Отдаете", "Получаете", "Резерв", "Web" };


                foreach (string nameCol in col)
                {
                   
                    ds.Tables[0].Columns.Add(nameCol);

                }



                string srcData = "<td class=\"bj\"><div class=\"pa\"><a rel=\"nofollow\" target=\"_blank\" href=\"(.*?)\" (.*?)"
   + "<div class=\"ca\">(.*?)</div></div></div></td>"
   + "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
   + "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
   + "<td class=\"ar arp\" (.*?)>(.*?)</td>\n"
   + "<td class=\"rw\" (.*?)<a href=\"(.*?)\" class=";
                

                string row = null;
                string[] rvalue = null;
                foreach (Match match in Regex.Matches(page, srcData))
                {

                    row = match.Groups[3].Value + " | "
  + match.Groups[4].Value
  + match.Groups[5].Value + " | "
  + match.Groups[6].Value
  + match.Groups[7].Value + " | "
  + match.Groups[9].Value + " | "
  + match.Groups[1].Value;
                    
                    rvalue = row.Split(new Char[] { '|' });
                    
                    ds.Tables[0].Rows.Add(rvalue);
                    
                    dataGridView1.DataSource = ds.Tables[0];
                    
                    row = null;
                    rvalue = null;
                    
                    
                    dataGridView1.Columns[4].Visible = false;
                }


                try { string s = dataGridView1.Rows[0].Cells[0].Value.ToString(); }

                catch
                {
                    MessageBox.Show("Выбранный курс обмена недоступен или не существует");
                }


            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
       
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Massage NMessage = new Massage();
            NMessage.Show();

        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            BCFinderHelp NewBCFinderHelp = new BCFinderHelp();
            NewBCFinderHelp.Show();
        }

        private void WhatFromBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void WhatToBtn_TextChanged(object sender, EventArgs e)
        {
            WebClient w = new WebClient();
            string a = comboBox1.SelectedItem.ToString();
            string b = comboBox2.SelectedItem.ToString();
            string page = w.DownloadString("http://www.bestchange.ru/" + a + "-to-" + b + ".html");

            DataSet ds = new DataSet();

            ds.Tables.Add("my");
            dataGridView1.Columns.Clear();




            string[] col = { "Обменник", "Отдаете", "Отдаете.", "Получаете", "Резерв", "Web" };


            foreach (string nameCol in col)
            {

                ds.Tables[0].Columns.Add(nameCol);

            }



            string srcData = "<td class=\"bj\"><div class=\"pa\"><a rel=\"nofollow\" target=\"_blank\" href=\"(.*?)\" (.*?)"
+ "<div class=\"ca\">(.*?)</div></div></div></td>"
+ "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
+ "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
+ "<td class=\"ar arp\" (.*?)>(.*?)</td>\n"
+ "<td class=\"rw\" (.*?)<a href=\"(.*?)\" class=";


            string row = null;
            string[] rvalue = null;
            foreach (Match match in Regex.Matches(page, srcData))
            {
                if (WhatToBtn.Text != String.Empty)
                {
                    row = match.Groups[3].Value + " | "
                      + match.Groups[4].Value
                      + match.Groups[5].Value + " | "
                      + +Math.Round(((Decimal.Parse(match.Groups[4].Value.Replace('.', ',')) / (Decimal.Parse(match.Groups[6].Value.Replace('.', ','))) * Decimal.Parse(WhatToBtn.Text))), 2) + " "
                      + match.Groups[5].Value + " | "
                      + WhatToBtn.Text + " "
                      + match.Groups[7].Value + " | "
                      + match.Groups[9].Value + " | "
                      + match.Groups[1].Value;
                    ;
                    rvalue = row.Split(new Char[] { '|' });

                    ds.Tables[0].Rows.Add(rvalue);

                    dataGridView1.DataSource = ds.Tables[0];

                    row = null;
                    rvalue = null;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }







                else
                {
                    dataGridView1.Columns.Clear();




                }
            }
      }


        private void WhatToBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void WhatFromBtn_TextChanged(object sender, EventArgs e)
        {
            {

                WebClient w = new WebClient();
                string a = comboBox1.SelectedItem.ToString();
                string b = comboBox2.SelectedItem.ToString();
                string page = w.DownloadString("http://www.bestchange.ru/" + a + "-to-" + b + ".html");

                DataSet ds = new DataSet();

                ds.Tables.Add("my");
                dataGridView1.Columns.Clear();




                string[] col = { "Обменник", "Отдаете", "Отдаете.", "Получаете", "Резерв", "Web" };


                foreach (string nameCol in col)
                {

                    ds.Tables[0].Columns.Add(nameCol);

                }



                string srcData = "<td class=\"bj\"><div class=\"pa\"><a rel=\"nofollow\" target=\"_blank\" href=\"(.*?)\" (.*?)"
    + "<div class=\"ca\">(.*?)</div></div></div></td>"
    + "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
    + "<td class=\"bi\">(.*?)<small>(.*?)</small></td>\n"
    + "<td class=\"ar arp\" (.*?)>(.*?)</td>\n"
    + "<td class=\"rw\" (.*?)<a href=\"(.*?)\" class=";


                string row = null;
                string[] rvalue = null;
                foreach (Match match in Regex.Matches(page, srcData))
                {

                    if (WhatFromBtn.Text != String.Empty)
                    {
                        row = match.Groups[3].Value + " | "
                          + match.Groups[4].Value
                          + match.Groups[5].Value + " | "
                          + WhatFromBtn.Text + " "
                          + match.Groups[5].Value + " | "
                          + Math.Round(((Decimal.Parse(match.Groups[6].Value.Replace('.', ',')) / (Decimal.Parse(match.Groups[4].Value.Replace('.', ','))) * Decimal.Parse(WhatFromBtn.Text))), 2) 
                          + match.Groups[7].Value + " | "
                          + match.Groups[9].Value + " | "
                          + match.Groups[1].Value;
                        ;
                        rvalue = row.Split(new Char[] { '|' });

                        ds.Tables[0].Rows.Add(rvalue);

                        dataGridView1.DataSource = ds.Tables[0];

                        row = null;
                        rvalue = null;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                    }







                    else
                    {
                        dataGridView1.Columns.Clear();




                    }

                }



            }
        }

        private void WhatFromBtn_Click(object sender, EventArgs e)
        {
            WhatToBtn.Text = null;
        }

        private void WhatToBtn_Click(object sender, EventArgs e)
        {
            WhatFromBtn.Text = null;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            WhatToBtn.Text = null;
            WhatFromBtn.Text = null;
        }

       
        
            
        }

        
    }

