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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try {
                    int graf = comboBox1.SelectedIndex; 
                    int time = comboBox2.SelectedIndex;
                    int from = comboBox3.SelectedIndex + 1;
                    int to = comboBox4.SelectedIndex + 1;
                 
                int[] before={4,5,6,7,8,9,10,11};
                int[] after = { 20,18,19,43,96,63,56,6};
                for (int i = 0; i <= 7; i++)
                {
                    if (from == before[i]) { from = after[i]; }
                    if (to == before[i]) { to = after[i]; }
                }
                WebClient w = new WebClient();
                string a = comboBox1.SelectedItem.ToString();
                string b = comboBox2.SelectedItem.ToString();
                string page = w.DownloadString("http://www.bestchange.ru/list.html");
                string timepattern = "var session_params = '(.*?)';";
                string session = null;


                foreach (Match match in Regex.Matches(page, timepattern))
                {

                    session = match.Groups[1].Value;
                    session.Trim();


                }

                System.Diagnostics.Process.Start("http://www.bestchange.ru/chart.php?type=7&ci=0&rnd=0.8501143546309322&session=kjuiguags699j9slt3b3rkmkl0"
                    );
            }

            catch { }
           
        }

       

       
    }
}
