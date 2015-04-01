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
    public partial class GoogleSearch : Form
    {
        public GoogleSearch()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string SearchValue = null;
            SearchValue = SearcTxt.Text;
            string[] SearchDrop = null;
            SearchDrop = SearchValue.Split(new Char[] { ' ' });
            try { webBrowser1.Navigate("https://www.google.com/finance/converter?a=" + SearchDrop[0] + "&from=" + SearchDrop[1] + "&to=" + SearchDrop[3] + "&meta=ei%3D3FDXVJGzCYSSwwOG-YDICQ"); }
            catch { MessageBox.Show("Не найдено:( Пример запроса 1 USD to UAH"); };
           
            
            
            }

        

        private void GoogleSearch_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/finance/converter");
        }
           
        
      

      
        
    }
}
