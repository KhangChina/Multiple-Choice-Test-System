using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Module.DTO;
using Module1.DTO;

namespace Module
{
    public class mdTB_EXAM
    {
        public string Update(dto_Exam Exam)
        {
            try
            {
                string conStr = Provider.ConnectionString(); 
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_EXAMS SET Name = N'" + Exam.name + "',Descriptons = N'" + Exam.description + "',CreateAt = N'" + Exam.create_at 
                        + "',CreateBy = '" + Exam.create_by + "',ApproveBy = '" + Exam.approve_by 
                        + "',TimeLimit = '" + Exam.time_limit + "',Reliability = '" + Exam.Reliability +
                        "',LevelOfDificult = '" + Exam.level_of_dificult + "',ExamDate = '" + Exam.exam_date +
                        "',StartTime = '" + Exam.start_time + "',EndTime = '" + Exam.end_time + 
                        "',Statuss = N'" + Exam.statuss + "' WHERE Id = " + Exam.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Exam", "update", "Cập nhật dữ liệu Exam lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Exam", "update", e.Message);
            }
        }

        public string Insert(ref dto_Exam Exam)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_EXAMS(Name,Descriptions,CreateAt,CreateBy,ApproveBy,TimeLimit,Reliability,LevelOfDificult,ExamDate,StartTime,EndTime,Statuss)VALUES(N'"
                    + Exam.name + "',N'" + Exam.description + "',N'" + Exam.create_at + "','" + Exam.create_by 
                    + "','" + Exam.approve_by + "','" + Exam.time_limit + "','" + Exam.Reliability + "','" + Exam.level_of_dificult + 
                    "', N'"+ Exam.exam_date + "',N'" + Exam.start_time + "',N'" + Exam.end_time + "',N'" + Exam.statuss + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_EXAMS')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Exam.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_Exam", "insert", "Lấy mã Exam lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Exam", "insert", "Thêm dữ liệu Exam lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Exam", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtoExam)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_EXAMS";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtoExam);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Exam", "GetAll", e.Message);
            }
        }
        public string Delete(int id)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"DELETE FROM TB_EXAMS WHERE Id = " + id; //sql cấu hình sẵn xoá luôn những record ở table chứa khoá ngoại của bảng này
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Exam", "Delete", "Xoá dữ liệu Exam lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Exam", "delete", e.Message);
            }
        }
    }
}
