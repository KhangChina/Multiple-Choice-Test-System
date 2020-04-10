using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MCTKN
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            CreateDataTable();
        }
        DataTable dt;
       void CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("s");
            dt.Columns.Add("l");
            dt.Columns.Add("r");
            dt.Columns.Add("e");

        }
        int TongN()
        {
            return int.Parse(sA.EditValue.ToString()) + int.Parse(sA1.EditValue.ToString()) + int.Parse(sB.EditValue.ToString()) + int.Parse(sB1.EditValue.ToString()) + int.Parse(sC.EditValue.ToString()) + int.Parse(sC1.EditValue.ToString()) + int.Parse(sD.EditValue.ToString()) + int.Parse(sD1.EditValue.ToString());
        }
        int TongD()
        {
            if(rgp.EditValue.ToString() == "A")
            {
                return int.Parse(sA.EditValue.ToString()) + int.Parse(sA1.EditValue.ToString());
            }
            if (rgp.EditValue.ToString() == "B")
            {
                return int.Parse(sB.EditValue.ToString()) + int.Parse(sB1.EditValue.ToString());
            }
            if (rgp.EditValue.ToString() == "C")
            {
                return int.Parse(sC.EditValue.ToString()) + int.Parse(sC1.EditValue.ToString());
            }
            if (rgp.EditValue.ToString() == "D")
            {
                return int.Parse(sD.EditValue.ToString()) + int.Parse(sD1.EditValue.ToString());
            }
            return 0;

        }
        int HieuD()
        {
            if (rgp.EditValue.ToString() == "A")
            {
                return Math.Abs(int.Parse(sA.EditValue.ToString()) - int.Parse(sA1.EditValue.ToString()));
            }
            if (rgp.EditValue.ToString() == "B")
            {
                return Math.Abs(int.Parse(sB.EditValue.ToString()) - int.Parse(sB1.EditValue.ToString()));
            }
            if (rgp.EditValue.ToString() == "C")
            {
                return Math.Abs(int.Parse(sC.EditValue.ToString()) - int.Parse(sC1.EditValue.ToString()));
            }
            if (rgp.EditValue.ToString() == "D")
            {
                return Math.Abs(int.Parse(sD.EditValue.ToString()) - int.Parse(sD1.EditValue.ToString()));
            }
            return 0;
        }
        double TinhChiSoKhoP(int dung,int tong)
        {
            return dung*1.0 / tong*1.0;
        }
        double TinhChiSoPhanBietD(int D,int TongD)    
        {
            return D*1.0 / TongD*1.0;
        }
        string ketquaDoKho(double kq)
        {
            if (kq < 0.25)
                return "Câu hỏi quá khó, cần loại bỏ";
            else if (0.25 <= kq && kq <= 0.75)
                return "Độ khó đạt chuẩn";
            else
                return "Câu hỏi quá dễ, cần loại bỏ";
        }
        private void btnADD_Click(object sender, System.EventArgs e)
        {

          
            double chisokho = TinhChiSoKhoP(TongD(), TongN());
            double chisophanbiet = TinhChiSoPhanBietD(HieuD(), TongD());
            int dem = 0;
            
            dt.Rows.Add(dem++, chisokho, chisophanbiet, ketquaDoKho(chisokho));
            grc.DataSource = dt;


        }
    }
}
