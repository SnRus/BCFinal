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
    public partial class Popularity : Form
    {
        public Popularity()
        {
            InitializeComponent();
        }

        private void Popularity_Load(object sender, EventArgs e)
        {
            
            WebClient w = new WebClient();
            string page = w.DownloadString("http://www.bestchange.ru/list.html");

            DataSet ds = new DataSet();
            ds.Tables.Add("my");

            string[] col = { "Направление обмена", "1день", "Сегмент"};


            foreach (string nameCol in col)
            {
                ds.Tables[0].Columns.Add(nameCol);

            }



            string srcData = "title=\"Курсы обмена (.*?)\"(.*?)"
                             + "title=\"Рейтинг обмена: (.*?) за сутки\"><span class=\"(.*?)\"></span>(.*?)</span></a>";
             

            string row = null;
            string[] rvalue = null;
            foreach (Match match in Regex.Matches(page, srcData))
            {

                row = match.Groups[1].Value + " | "
                                      + match.Groups[3].Value + " | "
                                      + match.Groups[5].Value;
                                     



                rvalue = row.Split(new Char[] { '|' });

                ds.Tables[0].Rows.Add(rvalue);


                dataGridView1.DataSource = ds.Tables[0];


                row = null;
                rvalue = null;

               
                
            }
            
            
        }
    }
}
