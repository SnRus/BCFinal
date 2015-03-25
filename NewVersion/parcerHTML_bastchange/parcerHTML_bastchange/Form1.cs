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
           
            cwmz.Checked = Properties.Settings.Default.cwmz ;
            cyandex.Checked = Properties.Settings.Default.cyandex  ;
            cwmr.Checked = Properties.Settings.Default.cwmr  ;
            cwmu.Checked = Properties.Settings.Default.cwmu ;
            cqiwi.Checked = Properties.Settings.Default.cqiwi  ;
            cwme.Checked = Properties.Settings.Default.cwme  ;
            cwmx.Checked = Properties.Settings.Default.cwmx  ;
            cwmb.Checked = Properties.Settings.Default.cwmb ;
            cwmy.Checked = Properties.Settings.Default.cwmy  ;
            cprivat24.Checked = Properties.Settings.Default.cprivat24 ;
            cwmg.Checked = Properties.Settings.Default.cwmg  ;
            call.Checked = Properties.Settings.Default.call;
            exchange.Checked = Properties.Settings.Default.exchange  ;
            settingscbfrom.SelectedItem= Properties.Settings.Default.settingscbfrom ;
            settingscbto.SelectedItem = Properties.Settings.Default.settingscbto ;
          if (call.Checked == true)  {
                WhatToBtn.Text = null;
                WhatFromBtn.Text = null;
                WebClient w = new WebClient();
                string page = w.DownloadString("http://www.bestchange.ru/list.html");

                DataSet ds = new DataSet();
                ds.Tables.Add("my");

                string[] col = { "Обменник", "Резервы", "Курсов", "Статус", "Web" };


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
                                         + match.Groups[1].Value;



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
          if (exchange.Checked == true) {
              {
                  try
                  {
                      WhatToBtn.Text = null;
                      WhatFromBtn.Text = null;
                      {
                          WebClient w = new WebClient();
                          
                          string page = w.DownloadString("http://www.bestchange.ru/" + settingscbfrom.SelectedItem.ToString() + "-to-" + settingscbto.SelectedItem.ToString() + ".html");

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
                  catch { MessageBox.Show("Пожалуйста, выберите валюты для обмена"); }
              }
          }
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

            try
            {
                
                WhatToBtn.Text = null;
                WhatFromBtn.Text = null;
                {
                    WebClient w = new WebClient();
                    string a = comboBox1.SelectedItem.ToString();
                    string b = comboBox2.SelectedItem.ToString();
                    string page = w.DownloadString("http://www.bestchange.ru/" + a + "-to-" + b + ".html");

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
                    string timepattern = "id=\"updatetime\">(.*)</dd>";
                    string time = null;
                     foreach (Match match in Regex.Matches(page, timepattern))
                    {

                        time = match.Groups[1].Value;
                        timeLbValue.Text = time;
                        time = null;
                    }
                     string exchangepattern = "<dd title=\"обменников/обменных сайтов\">(.*?)</dd>";
                     string exchange = null;
                     foreach (Match match in Regex.Matches(page, exchangepattern))
                     {

                         exchange = match.Groups[1].Value;
                         exchangeValue.Text = exchange;
                         exchange = null;
                     }
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
            catch { MessageBox.Show("Пожалуйста, выберите валюты для обмена"); }
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
            try
            {
                WebClient w = new WebClient();
                string a = comboBox1.SelectedItem.ToString();
                string b = comboBox2.SelectedItem.ToString();
                string page = w.DownloadString("http://www.bestchange.ru/" + a + "-to-" + b + ".html");

                DataSet ds = new DataSet();

                ds.Tables.Add("my");
                dataGridView1.Columns.Clear();

                string timepattern = "id=\"updatetime\">(.*)</dd>";
                string time = null;
                foreach (Match match in Regex.Matches(page, timepattern))
                {

                    time = match.Groups[1].Value;
                    timeLbValue.Text = time;
                    time = null;
                }
                string exchangepattern = "<dd title=\"обменников/обменных сайтов\">(.*?)</dd>";
                string exchange = null;
                foreach (Match match in Regex.Matches(page, exchangepattern))
                {

                    exchange = match.Groups[1].Value;
                    exchangeValue.Text = exchange;
                    exchange = null;
                }


                string[] col = { "Обменник", "Отдаете", "Отдаете ", "Получаете", "Резерв", "Web" };


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
                        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                        {
                            if (Decimal.Parse(WhatToBtn.Text)  > Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                            { this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red; }
                        }
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
            catch
            {
                MessageBox.Show("Пожалуйста, выберите валюты для обмена");
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
            try
            {
                {

                    WebClient w = new WebClient();
                    string a = comboBox1.SelectedItem.ToString();
                    string b = comboBox2.SelectedItem.ToString();
                    string page = w.DownloadString("http://www.bestchange.ru/" + a + "-to-" + b + ".html");

                    DataSet ds = new DataSet();

                    ds.Tables.Add("my");
                    dataGridView1.Columns.Clear();




                    string[] col = { "Обменник", "Отдаете", "Отдаете ", "Получаете", "Резерв", "Web" };


                    foreach (string nameCol in col)
                    {

                        ds.Tables[0].Columns.Add(nameCol);

                    }
                    string timepattern = "id=\"updatetime\">(.*)</dd>";
                    string time = null;
                    foreach (Match match in Regex.Matches(page, timepattern))
                    {

                        time = match.Groups[1].Value;
                        timeLbValue.Text = time;
                        time = null;
                    }
                    string exchangepattern = "<dd title=\"обменников/обменных сайтов\">(.*?)</dd>";
                    string exchange = null;
                    foreach (Match match in Regex.Matches(page, exchangepattern))
                    {

                        exchange = match.Groups[1].Value;
                        exchangeValue.Text = exchange;
                        exchange = null;
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
                            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                            {
                                if (Math.Round(((Decimal.Parse(match.Groups[6].Value.Replace('.', ',')) / (Decimal.Parse(match.Groups[4].Value.Replace('.', ','))) * Decimal.Parse(WhatFromBtn.Text))), 2) >= Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                                { this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red; }
                            }
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
            catch
            {
                MessageBox.Show("Пожалуйста, выберите валюты для обмена");
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

        private void cwmz_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmz.Checked == true)
            {
                comboBox1.Items.Add(cwmz.Text);
                comboBox2.Items.Add(cwmz.Text);
                
            };
            if (cwmz.Checked == false)
            {
                int index = comboBox1.FindString(cwmz.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
            };
        }

        private void cwmr_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmr.Checked == true)
            {
                comboBox1.Items.Add(cwmr.Text);
                comboBox2.Items.Add(cwmr.Text);
                
            };
            if (cwmr.Checked == false)
            {
                int index = comboBox1.FindString(cwmr.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        private void cwme_CheckedChanged(object sender, EventArgs e)
        {
            if (cwme.Checked == true)
            {
                comboBox1.Items.Add(cwme.Text);
                comboBox2.Items.Add(cwme.Text);
               
            };
            if (cwme.Checked == false)
            {
                int index = comboBox1.FindString(cwme.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
               
            };
        }

        private void cwmu_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmu.Checked == true)
            {
                comboBox1.Items.Add(cwmu.Text);
                comboBox2.Items.Add(cwmu.Text);
                
            };
            if (cwmu.Checked == false)
            {
                int index = comboBox1.FindString(cwmu.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        private void cwmb_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmb.Checked == true)
            {
                comboBox1.Items.Add(cwmb.Text);
                comboBox2.Items.Add(cwmb.Text);
                
            };
            if (cwmb.Checked == false)
            {
                int index = comboBox1.FindString(cwmb.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        private void cwmy_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmy.Checked == true)
            {
                comboBox1.Items.Add(cwmy.Text);
                comboBox2.Items.Add(cwmy.Text);
               
            };
            if (cwmy.Checked == false)
            {
                int index = comboBox1.FindString(cwmy.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        private void cwmg_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmg.Checked == true)
            {
                comboBox1.Items.Add(cwmg.Text);
                comboBox2.Items.Add(cwmg.Text);
                
               
            };
            if (cwmg.Checked == false)
            {
                int index = comboBox1.FindString(cwmg.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
                
            };
        }

        private void cwmx_CheckedChanged(object sender, EventArgs e)
        {
            if (cwmx.Checked == true)
            {
                comboBox1.Items.Add(cwmx.Text);
                comboBox2.Items.Add(cwmx.Text);
                
            };
            if (cwmx.Checked == false)
            {
                int index = comboBox1.FindString(cwmx.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                

            };
        }

        private void cqiwi_CheckedChanged(object sender, EventArgs e)
        {
            if (cqiwi.Checked == true)
            {
                comboBox1.Items.Add(cqiwi.Text);
                comboBox2.Items.Add(cqiwi.Text);
                
            };
            if (cqiwi.Checked == false)
            {
                int index = comboBox1.FindString(cqiwi.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
               
            };
        }

        private void cprivat24_CheckedChanged(object sender, EventArgs e)
        {
            if (cprivat24.Checked == true)
            {
                comboBox1.Items.Add(cprivat24.Text);
                comboBox2.Items.Add(cprivat24.Text);
                
            };
            if (cprivat24.Checked == false)
            {
                int index = comboBox1.FindString(cprivat24.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        private void cyandex_CheckedChanged(object sender, EventArgs e)
        {
            if (cyandex.Checked == true)
            {
                comboBox1.Items.Add(cyandex.Text);
                comboBox2.Items.Add(cyandex.Text);
               
            };
            if (cyandex.Checked == false)
            {
                int index = comboBox1.FindString(cyandex.Text);
                comboBox1.Items.Remove(comboBox1.Items[index]);
                comboBox2.Items.Remove(comboBox2.Items[index]);
                
            };
        }

        

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible   = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            label4.Visible = true;
            call.Visible = true;
            Save.Visible = true;
            cwmz.Visible = true;
            cyandex.Visible = true; ;
            cwmr.Visible = true; ;
            cwmu.Visible = true; ;
            cqiwi.Visible = true; ;
            cwme.Visible = true; ;
            cwmx.Visible = true; ;
            cwmb.Visible = true; ;
            cwmy.Visible = true; ;
            cprivat24.Visible = true; ;
            cwmg.Visible = true; ;
            label3.Visible = true;
            label5.Visible = true;
            settingscbfrom.Visible = true;
            settingscbto.Visible = true;
            exchange.Visible = true;
 


        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.cwmz = cwmz.Checked;
            Properties.Settings.Default.cyandex = cyandex.Checked;
            Properties.Settings.Default.cwmr = cwmr.Checked;
            Properties.Settings.Default.cwmu = cwmu.Checked;
            Properties.Settings.Default.cqiwi = cqiwi.Checked;
            Properties.Settings.Default.cwme = cwme.Checked;
            Properties.Settings.Default.cwmx = cwmx.Checked;
            Properties.Settings.Default.cwmb = cwmb.Checked;
            Properties.Settings.Default.cwmy = cwmy.Checked;
            Properties.Settings.Default.cprivat24 = cprivat24.Checked;
            Properties.Settings.Default.cwmg = cwmg.Checked;
            Properties.Settings.Default.call = call.Checked;
            Properties.Settings.Default.settingscbfrom = settingscbfrom.SelectedItem.ToString();
            Properties.Settings.Default.settingscbto = settingscbto.SelectedItem.ToString();
            Properties.Settings.Default.exchange = exchange.Checked;

            Properties.Settings.Default.Save();
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            Save.Visible = false;
            cwmz.Visible = false;
            cyandex.Visible = false;
            cwmr.Visible = false;
            cwmu.Visible = false;
            cqiwi.Visible = false;
            cwme.Visible = false;
            cwmx.Visible = false;
            cwmb.Visible = false;
            cwmy.Visible = false;
            cprivat24.Visible = false;
            cwmg.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            call.Visible = false;
            label5.Visible = false;
            settingscbfrom.Visible = false;
            settingscbto.Visible = false;
            exchange.Visible = false;
        }

        private void call_CheckedChanged(object sender, EventArgs e)
        {
            if (call.Checked==true) {exchange.Enabled=false;}
            else { exchange.Enabled = true; }
        }

        private void exchange_CheckedChanged(object sender, EventArgs e)
        {
            if (exchange.Checked == true) { call.Enabled = false; }
            else { call.Enabled = true; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Popularity NPopularity = new Popularity();
            NPopularity.Show();
        }

       
        
            
        }

        
    }

