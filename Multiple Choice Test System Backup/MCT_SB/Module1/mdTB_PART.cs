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
    public class mdTB_PART
    {
        public string Update(dto_Part Part)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_PART SET Name = N'" + Part.name + "',IdGroup = '" + Part.idgroup + "',Descriptons = N'" + Part.description + "',Statuss = N'" + Part.statuss + "' WHERE Id = " + Part.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module","mdTB_Part","update", "Cập nhật dữ liệu Part lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Part", "update", e.Message);
            }
        }

        public string Insert(ref dto_Part Part)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_PART(Name,IdGroup,Descriptions,Statuss)VALUES(N'" + Part.name + "','" + Part.idgroup + "','" + Part.description + "',N'" + Part.statuss + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_PART')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Part.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_Part", "insert", "Lấy mã Part lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Part", "insert", "Thêm dữ liệu Part lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Part", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtoPart)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_PART";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtoPart);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Part", "GetAll", e.Message);
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

                string query = @"UPDATE TB_PART SET Statuss ='inactive' WHERE Id = " + id;
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Part", "Delete", "Xoá dữ liệu Part lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Part", "delete", e.Message);
            }
        }
    }
}
