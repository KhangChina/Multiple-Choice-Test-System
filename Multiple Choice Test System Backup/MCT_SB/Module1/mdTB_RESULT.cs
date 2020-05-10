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
    public class mdTB_RESULT
    {
        public string Update(dto_Result Result)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_RESULT SET TotalScore = '" + Result.total_score + "',IdExamCode = '" + Result.id_exam_code + "',IdCandidate = '" + Result.id_candidate + "' WHERE Id = " + Result.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module","mdTB_RESULT","update", "Cập nhật dữ liệu result lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_RESULT", "update", e.Message);
            }
        }

        public string Insert(ref dto_Result Result)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_RESULT(TotalScore,IdExamCode,IdCandidate)VALUES('" + Result.total_score + "','" + Result.id_exam_code + "','" + Result.id_candidate + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_RESULT')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Result.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_RESULT", "insert", "Lấy mã result lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_RESULT", "insert", "Thêm dữ liệu result lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_RESULT", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtogroup)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_RESULT";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtogroup);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_RESULT", "GetAll", e.Message);
            }
        }
        public string Delete(int id)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string query = @"DELETE TB_RESULT WHERE Id = " + id; //sql cấu hình sẵn xoá luôn những record ở table chứa khoá ngoại của bảng này
                SqlTransaction sqlTrans = con.BeginTransaction();
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_RESULT", "Delete", "Xoá dữ liệu result lỗi");
                }
                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_RESULT", "delete", e.Message);
            }
        }
    }
}
