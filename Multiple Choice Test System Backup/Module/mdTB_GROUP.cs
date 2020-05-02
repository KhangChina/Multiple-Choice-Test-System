using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Module
{
    public class mdTB_GROUP
    {
        public string Update(dtoEmployee Employee)
        {
            try
            {
                string conStr = Provider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"UPDATE EMPLOYEE SET NAME = N'" + Employee.NAME + "',BIRTHDAY = '" + Employee.BIRTHDAY + "',GENDER = N'" + Employee.GENDER + "',ADDRESS = N'" + Employee.ADDRESS + "' WHERE ID = " + Employee.ID;
                SqlCommand cmdUpdate = new SqlCommand(query, con);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Transaction = sqlTrans;
                int result = cmdUpdate.ExecuteNonQuery();
                if (result != 1)
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return "Lỗi số 1(daoEmployee -> Update): Cập nhật dữ liệu nhân viên lỗi";
                }

                sqlTrans.Commit();
                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return "Lỗi ngoại lệ: daoEmployee -> Update: " + e.Message;
            }
        }

        public string Insert(ref dtoEmployee Employee)
        {
            try
            {
                string conStr = DataProvider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);

                con.Open();
                SqlTransaction sqlTrans = con.BeginTransaction();

                string query = @"INSERT INTO EMPLOYEE(NAME,BIRTHDAY,GENDER,ADDRESS)VALUES(N'" + Employee.NAME + "','" + Employee.BIRTHDAY + "',N'" + Employee.GENDER + "',N'" + Employee.ADDRESS + "')";
                SqlCommand cmdInsert = new SqlCommand(query, con);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Transaction = sqlTrans;
                int result = cmdInsert.ExecuteNonQuery();
                if (result == 1)
                {
                    query = "SELECT IDENT_CURRENT('EMPLOYEE')";
                    SqlCommand cmdGetID = new SqlCommand(query, con);
                    cmdGetID.CommandType = CommandType.Text;
                    cmdGetID.Transaction = sqlTrans;

                    object id = cmdGetID.ExecuteScalar();

                    Employee.ID = id.ToString();

                    if (result > 0)
                        sqlTrans.Commit();
                    else
                    {
                        sqlTrans.Rollback();
                        sqlTrans.Dispose();
                        con.Close();

                        return "Lỗi số 2(daoEmployee -> Insert): Lấy mã nhân viên lỗi";
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    sqlTrans.Dispose();
                    con.Close();

                    return "Lỗi số 1(daoEmployee -> Insert): Thêm dữ liệu nhân viên lỗi";
                }

                sqlTrans.Dispose();
                con.Close();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return "Lỗi ngoại lệ: daoEmployee -> Insert: " + e.Message;
            }
        }

        public string GetAll(ref DataTable dtEmployee)
        {
            try
            {
                string conStr = DataProvider.ConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "SELECT * FROM EMPLOYEE";
                SqlCommand cmdGetData = new SqlCommand(query, con);
                cmdGetData.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
                int result = da.Fill(dtEmployee);
                con.Close();

                return "SUCCESS";
            }
            catch (Exception e)
            {
                return "Lỗi ngoại lệ: daoEmployee -> GetAll: " + e.Message;
            }
        }
    }
}
