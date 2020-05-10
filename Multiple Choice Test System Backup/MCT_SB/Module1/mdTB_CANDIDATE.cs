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
    public class mdTB_CANDIDATE
    {
        public string Update(dto_candidate Candidate)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_CANDIDATES SET Name = N'" + Candidate.name + "',DateOfBirth = N'" + Candidate.date_of_birth + "',Phone = N'" + Candidate.phone + "',Address = N'" + Candidate.address + "',Email = N'" + Candidate.email + "',Image = N'" + Candidate.image + "' WHERE Id = " + Candidate.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Candidate", "update", "Cập nhật dữ liệu Candidate lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Candidate", "update", e.Message);
            }
        }

        public string Insert(ref dto_candidate Candidate)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_CANDIDATES(Name,DateOfBirth,Phone,Address,Email,Image)VALUES(N'" + Candidate.name + "','" + Candidate.date_of_birth + "','" + Candidate.phone + "',N'" + Candidate.address + "','" + Candidate.email + "','" + Candidate.image + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_CANDIDATES')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Candidate.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_Candidate", "insert", "Lấy mã Candidate lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Candidate", "insert", "Thêm dữ liệu Candidate lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Candidate", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtoCandidate)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_CANDIDATES";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtoCandidate);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Candidate", "GetAll", e.Message);
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

                string query = @"DELETE FROM TB_CANDIDATES WHERE Id = " + id;//sql cấu hình sẵn xoá luôn những record ở table chứa khoá ngoại của bảng này
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Candidate", "Delete", "Xoá dữ liệu Candidate lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Candidate", "delete", e.Message);
            }
        }
    }
}
