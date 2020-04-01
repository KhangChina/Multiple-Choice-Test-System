using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEstSysyTem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool match = Regex.IsMatch(s1.Text, s2.Text);//So Sánh kí tự bất kì trong s2 có trong s1
            listBox1.Items.Add(match.ToString());
	        MessageBox.Show("ngocOc");
        }
        
    }
}
