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
        string ketquaDoTinCay(double kq)
        {
            if (kq < 0.5)
                return "Độ tin cậy không đáp ứng";
            else if (0.5 <= kq && kq <= 0.6)
                return "Độ tin cậy yếu, phải xem xét lại";
            else if (0.6 < kq && kq <= 0.7)
                return "Độ tin cậy hơi yếu, phải xem xét lại";
            else if (0.7 < kq && kq <= 0.8)
                return "Độ tin cậy tốt, nhưng cần cải thiện";
            else if (0.8 < kq && kq <= 0.9)
                return "Độ tin cậy khá tốt";
            else
                return "Độ tin cậy rất tốt";
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
        string ketquaDoPhanBiet(double kq)
        {
            if (kq < 0.15)
                return "Độ phân biệt kém, cần loại bỏ";
            else if (0.15 <= kq && kq < 0.25)
                return "Độ phân biệt tạm được";
            else if (0.25 <= kq && kq < 0.35)
                return "Độ phân biệt khá tốt";
            else
                return "Độ phân biệt rất tốt";
        }
        double TinhPhuongSai(List<int> arr)
        {
            int sumArr = 0;
            foreach (int i in arr)
            {
                sumArr += i;
            }    
            int _x = sumArr / arr.Count;
            int _xxi = 0;
            foreach (int xi in arr)
            {
                _xxi += (xi - _x) * (xi - _x);
            }
            return _xxi / (arr.Count - 1);
        }
        double SumTyLeDungSai(List<double> arr)
        {
            double sum = 0;
            foreach (double xi in arr)
            {
                sum += xi * (1 - xi);
            }
            return sum;
        }
        double tinhDoTinCay_K_R20(int tongN, List<int> arr_diem, List<double> arr_DoKho)
        {
            double phuongsai = TinhPhuongSai(arr_diem);
            //MessageBox.Show(phuongsai.ToString());
            double tyledungsai = SumTyLeDungSai(arr_DoKho);
            return (tongN / (tongN - 1) * (1 - (tyledungsai / phuongsai)));
        }
        string tinhDoKhoDeThi (double DTB, int SoCau)
        {
            return "ĐTB của các thí sinh là : " + DTB + "So với ĐTB Lý tưởng là : " + (SoCau + SoCau * 0.25) / 2;
        }
        private void btnADD_Click(object sender, System.EventArgs e)
        {
          
            double chisokho = TinhChiSoKhoP(TongD(), TongN());
            double chisophanbiet = TinhChiSoPhanBietD(HieuD(), TongD());
            //double chisophanbiet = TinhChiSoPhanBietD(HieuD() * 2, TongN());
            int dem = 0;
 
            dt.Rows.Add(dem++, chisokho, chisophanbiet, ketquaDoKho(chisokho) + "|" + ketquaDoPhanBiet(chisophanbiet));
            grc.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }
        List<int> randomDiem (int n)
        {
            List<int> arr_diem = new List<int>();
            Random rd = new Random();
            do
            {
                arr_diem.Add(rd.Next(5, 10));
                n--;
            } while (n > 0);
            return arr_diem;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int tongN = dt.Rows.Count;
            List<double> arr_dokho = new List<double>();
            foreach (DataRow i in dt.Rows)
            {
                arr_dokho.Add(double.Parse(i.ItemArray[1].ToString()));
            }   
            double kq = tinhDoTinCay_K_R20(tongN, randomDiem(20), arr_dokho);
            MessageBox.Show("Đề thi được đánh giá có "+ ketquaDoTinCay(kq)+ " với độ tin cậy là : " + kq);
        }
    }
}
