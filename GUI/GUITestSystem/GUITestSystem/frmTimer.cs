using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUITestSystem
{
    public partial class frmTimer : DevExpress.XtraEditors.XtraForm
    {
        public frmTimer()
        {
            InitializeComponent();
           
        }
        TimeSpan diff;
        int dem = 0;
        bool Start (string timeStart,ref TimeSpan diff2)
        {
            //string time1 = DateTime.Parse("1:30 PM").ToString("t");
            string time1 = DateTime.Parse(timeStart).ToString("t");
            string time2 = DateTime.Now.ToString("t");
            if (DateTime.Compare(DateTime.Parse(time1), DateTime.Parse(time2)) < 0)
            {
                return true;
            }
            else
            {
                diff2 = DateTime.Parse(time1) - DateTime.Parse(time2);
                //lbTime.Text = "Will start in " + diff2.ToString() + "s";
                return false;
            }
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {
            dem = 0;       
            if (Start("8:23 PM", ref diff))
            {
                this.Close();
            }
            timer1.Start();
            dem = int.Parse(diff.TotalSeconds.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dem--;
            lbTime.Text = "Will start in "+dem+"s";
            if(dem ==0)
            {
                this.Close();
            }
        }
    }
}