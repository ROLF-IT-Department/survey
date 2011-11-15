using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Работа с БД и классом Employee
/// </summary>
public class EmployeeDB
{
    private string ConnectionString;

    public EmployeeDB()
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString;
    }

    public Employee getEmployee(string username, string password)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "SELECT * FROM user_survey_employees WHERE (login = @login) and (password = @password)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 50));
        cmd.Parameters["@login"].Value = username;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20));
        cmd.Parameters["@password"].Value = password;
        Employee emp = null;
        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

               
                emp = new Employee((int)reader["id"], Convert.ToInt32(reader["auto_card"]), (string)reader["company"], (string)reader["rank"], (string)reader["sex"], (string)reader["emp_group"], (string)reader["age"], (string)reader["standing"], (string)reader["login"], (string)reader["password"], Convert.ToInt32(reader["survey_id"]), (object)reader["status"]);
            }
            reader.Close();
            conn.Close();
            return emp;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conn.Close();
        }

    }

    public void updateStatus(int id)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "UPDATE user_survey_employees SET status = 1 WHERE id = @id";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4));
        cmd.Parameters["@id"].Value = id;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            throw new Exception();
        }
        finally
        {
            conn.Close();
        }
    }
}
