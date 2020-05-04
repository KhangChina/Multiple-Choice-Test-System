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
    public class mdTB_QUESTIONS
    {
        public string Update(dto_questions Question)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE TB_QUESTIONS SET Descriptons = N'" + Question.description + "',LevelOfDificult = '" + Question.level_of_dificult + "',Distinctiveness = '" + Question.distinctiveness + "',Images = N'" + Question.image + "',IdPart = '" + Question.id_part + "',IdGroupTypeQuestions = '" + Question.id_group_type_question + "',Statuss = N'" + Question.statuss + "' WHERE Id = " + Question.id;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Question", "update", "Cập nhật dữ liệu Question lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Question", "update", e.Message);
            }
        }

        public string Insert(ref dto_questions Question)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO TB_QUESTIONS(Descriptions,LevelOfDificult,Distinctiveness,Images,IdPart,IdGroupTypeQuestions,Statuss)VALUES(N'" + Question.description + "','" + Question.level_of_dificult + "','" + Question.distinctiveness + "',N'" + Question.image + "','" + Question.id_part + "','" + Question.id_group_type_question + "',N'" + Question.statuss + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('TB_QUESTIONS')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Question.id = Convert.ToInt32(id);

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return Provider.ErroString("Module", "mdTB_Question", "insert", "Lấy mã Question lỗi");
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Question", "insert", "Thêm dữ liệu Question lỗi");
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Question", "insert", e.Message);
            }
        }

        public string GetAll(ref DataTable dtoQuestion)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM TB_QUESTIONS";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtoQuestion);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Question", "GetAll", e.Message);
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

                string query = @"DELETE TB_QUESTIONS WHERE Id = " + id;
                SqlCommand cmdDelete = new SqlCommand(query, con);
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Transaction = sqlTrans;
                int result = cmdDelete.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return Provider.ErroString("Module", "mdTB_Question", "Delete", "Xoá dữ liệu Question lỗi");
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return Provider.ErroString("Module", "mdTB_Question", "delete", e.Message);
            }
        }
    }
}
