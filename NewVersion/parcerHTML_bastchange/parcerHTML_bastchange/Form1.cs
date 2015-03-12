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


        

       
        private void button3_Click(object sender, EventArgs e)
        {
             
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
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void button24_Click(object sender, EventArgs e)
        {
            {
                InitializeComponent();
            

                WebClient w = new WebClient();
              string a = comboBox1.SelectedItem.ToString();
              string b = comboBox2.SelectedItem.ToString(); 
                string page = w.DownloadString("http://www.bestchange.ru/"+ a +"-to-"+ b +".html" );

                DataSet ds = new DataSet();
                ds.Tables.Add("my");

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





            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        
            
        }

        
    }

