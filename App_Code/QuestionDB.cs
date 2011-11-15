using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for QuestionDB
/// </summary>
public class QuestionDB
{
	private string ConnectionString;

    public QuestionDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString; 
	}

    public List<Question> getOrderQuestion(int category_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT * FROM user_survey_questions WHERE (is_order IS NOT NULL) AND (category_id = @category_id) ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        List<Question> questions = new List<Question>();
        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Question q = new Question((int)reader["id"], (string)reader["qnum"], (string)reader["qtext"], (int)reader["category_id"], (int)reader["is_text"], (int)reader["is_order"]);
                questions.Add(q);
            }
            reader.Close();

            return questions;
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

    public int getNumberOfOrderQuestion(int category_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT COUNT(*) as Count FROM user_survey_questions WHERE (is_order = 1) AND (category_id = @category_id) ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        int num = 0;
        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                num = (int)reader["Count"];
            }
            reader.Close();

            return num;
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

    public DataSet getListOfQuestions(int categ_id)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);

        string sql = "SELECT * FROM user_survey_questions WHERE (category_id = " + categ_id + ") ORDER BY id ASC";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();

        try
        {
            da.Fill(ds, "questions");
            return ds;
        }
        catch (Exception exc)
        {
            throw new Exception(exc.Message);
        }

    }


    public DataSet getIDOfQuestions(int categ_id)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);

        string sql = "SELECT id FROM user_survey_questions WHERE (category_id = " + categ_id + ") ORDER BY qnum ASC";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();

        try
        {
            da.Fill(ds, "questionsid");
            return ds;
        }
        catch (Exception exc)
        {
            throw new Exception(exc.Message);
        }

    }


}
