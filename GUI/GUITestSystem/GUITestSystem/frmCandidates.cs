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
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;

namespace GUITestSystem
{
    public partial class frmCandidates : DevExpress.XtraEditors.XtraForm
    {
        public frmCandidates()
        {
            InitializeComponent();
           
           
        }
        DataTable Answer_Sheet;
        private void frmCandidates_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            List<string> li = new List<string>();
            li.Add("1:I'm Ngoc");
            li.Add("2:Her name is Khang");
            uC_Question_Picture1.Add_Answer(li);
            uC_Question_Picture1.Question = "Câu 1 : What's your name ?";
=======
>>>>>>> 6a77010480363dfbc8bc54c01821adf49d729ee5
            List<string> id = new List<string>();
            id.Add("id1");
            id.Add("id2");
            id.Add("id3");
            id.Add("id4");
            id.Add("id5");
            id.Add("id6");
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 
            id.Add("id6"); 

            AddGroup(id);

            frmTimer frm = new frmTimer();
            frm.ShowDialog();
        }
        void AddGroup(List<string> idQuestion)
        {
            int dem = 1;
            foreach (string item in idQuestion)
            {
                //Tạo Item
                RadioGroupItem radioA = new RadioGroupItem();
                radioA.Description = "A";
                RadioGroupItem radioB = new RadioGroupItem();
                radioB.Description = "B";
                RadioGroupItem radioC = new RadioGroupItem();
                radioC.Description = "C";
                RadioGroupItem radioD = new RadioGroupItem();
                radioD.Description = "D";
                //Add vào Group
                RadioGroup rd = new RadioGroup();
                rd.Name = item;
                rd.Properties.Columns = 4;
                rd.Properties.Items.Add(radioA);
                rd.Properties.Items.Add(radioB);
                rd.Properties.Items.Add(radioC);
                rd.Properties.Items.Add(radioD);

                LayoutControlItem item1 = layoutControlGroup2.AddItem();
                item1.Control = rd;
                item1.Text = "Question "+dem+":";          
                dem++;

            }
           
            EmptySpaceItem empty = new EmptySpaceItem();      
            layoutControlGroup2.AddItem(empty);



        }

       
        
    }
}