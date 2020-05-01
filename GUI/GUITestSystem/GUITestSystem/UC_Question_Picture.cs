using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUITestSystem
{
    public partial class UC_Question_Picture : UserControl
    {
        public UC_Question_Picture()
        {
            InitializeComponent();
        }
        [Category("Data"), Description("Pictures")]
        public string Pictures
        {
            get { return this.pictureEdit1.Text; }
            set { this.pictureEdit1.Image = Image.FromFile(value); }
        }
        [Category("Data"), Description("Question")]
        public string Question
        {
            get { return this.lb_question.Text; }
            set { this.lb_question.Text = value; }
        }
        [Category("Data"), Description("Answer")]
        public string Answer
        {
            get { return this.lb_question.Text; }
            set { this.lb_question.Text = value; }
        }
        public void Add_Answer(List<string> list)
        {
            var stt = 65;
            int y = 17;
            foreach (var item in list)
            {
                RadioButton dapan = new RadioButton();
                dapan.Name = item.Split(':')[0];
                dapan.Text = (char)stt + ". " + item.Split(':')[1];
                dapan.Location = new Point(0, y);

                pn_answer.Controls.Add(dapan);
                y += 43;
                stt++;
            }
        }
    }
}
