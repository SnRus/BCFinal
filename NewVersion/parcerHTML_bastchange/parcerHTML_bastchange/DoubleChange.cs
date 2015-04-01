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
    public partial class DoubleChange : Form
    {
        public DoubleChange()
        {
            InitializeComponent();
        }

        private void DoubleChange_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int from = comboBox1.SelectedIndex + 1;
            int to = comboBox2.SelectedIndex + 1;

            int[] before = { 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] after = { 20, 18, 19, 43, 96, 63, 56, 6 };
            for (int i = 0; i <= 7; i++)
            {
                if (from == before[i]) { from = after[i]; }
                if (to == before[i]) { to = after[i]; }
            }
            WebClient w = new WebClient();
            string page = w.DownloadString("http://www.bestchange.ru/index.php?mt=twostep&from=" + from + "&to=" + to + "&sort=from&range=asc");

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            ds.Tables.Add("my");
            ds1.Tables.Add("my");
            ds2.Tables.Add("my");


            string[] col = { "Cайт" };
            string[] col1 = { "Первый обмен", "Второй обмен", "Курс", "Резерв" };

            foreach (string nameCol in col1)
            {
                ds.Tables[0].Columns.Add(nameCol);


            }
            foreach (string nameCol in col)
            {
                ds1.Tables[0].Columns.Add(nameCol);
                ds2.Tables[0].Columns.Add(nameCol);

            }

            string srcData = "<td class=\"ir bi\">(.*?) <small>(.*?)</small> <span class=\"font13px\">&rarr;</span> (.*?) <small>(.*?)</small> <span class=\"font13px\">&rarr;</span> (.*?) <small>(.*?)</small></td>\n"
                + "<td class=\"bj bp\">(.*?)</td>\n"
                + "<td class=\"ar rwa\"><table class=\"ts\"><tr><td>(.*?)</td>";
            string srcData1 = "class=\"gray\">на сайте</span> (.*?) href=\"(.*?)\">(.*?)</a>(.*?)"
                + "<a id=\"eb(.*?)_1\"(.*?)\n";
            string srcData2 = "class=\"gray\">на сайте</span> (.*?) href=\"(.*?)\">(.*?)</a>(.*?)"
               + "<a id=\"eb(.*?)_2\"(.*?)\n";



            string row = null;
            string[] rvalue = null;
            foreach (Match match in Regex.Matches(page, srcData))
            {

                row = match.Groups[1].Value + " " + match.Groups[2].Value + "-->"
                    + match.Groups[3].Value + " " + match.Groups[4].Value + " | "
                    + match.Groups[3].Value + " " + match.Groups[4].Value + "-->"
                    + match.Groups[5].Value + " " + match.Groups[6].Value + " | "
                    + match.Groups[7].Value + " | " + match.Groups[8].Value;
                rvalue = row.Split(new Char[] { '|' });

                ds.Tables[0].Rows.Add(rvalue);


                dataGridViewMain.DataSource = ds.Tables[0];


                row = null;
                rvalue = null;



            }
            foreach (Match match in Regex.Matches(page, srcData1))
            {

                row = match.Groups[2].Value;



                rvalue = row.Split(new Char[] { '|' });

                ds1.Tables[0].Rows.Add(rvalue);


                dataGridViewFirst.DataSource = ds1.Tables[0];


                row = null;
                rvalue = null;



            }
            foreach (Match match in Regex.Matches(page, srcData2))
            {

                row = match.Groups[2].Value;



                rvalue = row.Split(new Char[] { '|' });

                ds2.Tables[0].Rows.Add(rvalue);


                dataGridViewSecond.DataSource = ds2.Tables[0];


                row = null;
                rvalue = null;



            }
        }

        private void dataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMain.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridViewMain.SelectedCells[0].RowIndex;


                string a = Convert.ToString(dataGridViewFirst.Rows[selectedrowindex].Cells[0].Value.ToString());
                string b = Convert.ToString(dataGridViewSecond.Rows[selectedrowindex].Cells[0].Value.ToString());
                string a1 = a.Trim();
                string b1 = b.Trim();

                System.Diagnostics.Process.Start(a1);
                System.Diagnostics.Process.Start(b1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InfoDoubleChange NInfoDoubleChange = new InfoDoubleChange();
            NInfoDoubleChange.Show();
        }
           
    }
}
