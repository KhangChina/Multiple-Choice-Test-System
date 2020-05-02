using Module;
using Module1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class mdTB_GROUP_TYPE_QUESTIONS
    {
        public string Update(dto_group_type_question group_Type_Question)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_GROUP_TYPE_QUESTIONS SET Name = N'" + group_Type_Question.name + "',Descriptons = N'" + group_Type_Question.description + "',Images = N'" + group_Type_Question.image + "',Statuss = N'" + group_Type_Question.statuss + "',IdTypeQuestion = '" + group_Type_Question.id_type_question + "' WHERE Id = " + group_Type_Question.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Group_Type_Questions", "update", "Cập nhật dữ liệu group type question lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Group_Type_Questions", "update", e.Message);
            }
        }

        public string Insert(ref dto_group_type_question group_Type_Question)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_GROUP_TYPE_QUESTIONS(Name,Descriptions,Images,Statuss,IdTypeQuestion)VALUES(N'" + group_Type_Question.name + "',N'" + group_Type_Question.description + "',N'" + group_Type_Question.image + "',N'" + group_Type_Question.statuss + "','" + group_Type_Question.id_type_question + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_GROUP_TYPE_QUESTIONS')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    group_Type_Question.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "insert", "Lấy mã group type question lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "insert", "Thêm dữ liệu group type question lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtoPart)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_GROUP_TYPE_QUESTIONS";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtoPart);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "GetAll", e.Message);
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

                string query = @"UPDATE TB_GROUP_TYPE_QUESTIONS SET Statuss ='inactive' WHERE Id = " + id;
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "Delete", "Xoá dữ liệu group type question lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_GROUP_TYPE_QUESTIONS", "delete", e.Message);
            }
        }
    }
}
