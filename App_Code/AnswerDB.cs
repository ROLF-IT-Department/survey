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
using System.Collections.Generic;

/// <summary>
/// Summary description for AnswerDB
/// </summary>
public class AnswerDB
{
	private string ConnectionString;

    public AnswerDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString; 
	}

    public void insertResult(int question_id, int auto_card, int rating, int survey_id, int category_id, DateTime date_answer)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "INSERT INTO user_survey_answers (question_id, auto_card, rating, survey_id, category_id, date_answer) VALUES (@qid, @card, @rating, @sid, @category_id, @date_answer)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@qid", SqlDbType.Int, 4));
        cmd.Parameters["@qid"].Value = question_id;
        cmd.Parameters.Add(new SqlParameter("@card", SqlDbType.Int, 4));
        cmd.Parameters["@card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 4));
        cmd.Parameters["@rating"].Value = rating;
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int, 4));
        cmd.Parameters["@sid"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        cmd.Parameters.Add(new SqlParameter("@date_answer", SqlDbType.SmallDateTime, 4));
        cmd.Parameters["@date_answer"].Value = date_answer;
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

    public void insertText(int question_id, int auto_card, string text, int survey_id, int category_id, DateTime date_answer, int is_text)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "INSERT INTO user_survey_answers (question_id, auto_card, text, survey_id, category_id, date_answer, is_text) VALUES (@qid, @card, @text, @sid, @category_id, @date_answer, @is_text)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@qid", SqlDbType.Int, 4));
        cmd.Parameters["@qid"].Value = question_id;
        cmd.Parameters.Add(new SqlParameter("@card", SqlDbType.Int, 4));
        cmd.Parameters["@card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@text", SqlDbType.Text));
        cmd.Parameters["@text"].Value = text;
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int, 4));
        cmd.Parameters["@sid"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        cmd.Parameters.Add(new SqlParameter("@date_answer", SqlDbType.SmallDateTime, 4));
        cmd.Parameters["@date_answer"].Value = date_answer;
        cmd.Parameters.Add(new SqlParameter("@is_text", SqlDbType.Int, 4));
        cmd.Parameters["@is_text"].Value = 1;
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

    public void insertOrderQuestion(int question_id, int auto_card, int rating, int survey_id, int category_id, DateTime date_answer)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "INSERT INTO user_survey_answers (question_id, auto_card, rating, survey_id, category_id, date_answer, is_order) VALUES (@qid, @card, @rating, @sid, @category_id, @date_answer, @is_order)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@qid", SqlDbType.Int, 4));
        cmd.Parameters["@qid"].Value = question_id;
        cmd.Parameters.Add(new SqlParameter("@card", SqlDbType.Int, 4));
        cmd.Parameters["@card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 4));
        cmd.Parameters["@rating"].Value = rating;
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int, 4));
        cmd.Parameters["@sid"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        cmd.Parameters.Add(new SqlParameter("@date_answer", SqlDbType.SmallDateTime, 4));
        cmd.Parameters["@date_answer"].Value = date_answer;
        cmd.Parameters.Add(new SqlParameter("@is_order", SqlDbType.Int, 4));
        cmd.Parameters["@is_order"].Value = 1;
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

    public void updateText(int answer_id, string text, DateTime date_answer)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "UPDATE user_survey_answers SET text = @text, date_answer = @date_answer WHERE id = @aid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@text", SqlDbType.Text));
        cmd.Parameters["@text"].Value = text;
        cmd.Parameters.Add(new SqlParameter("@date_answer", SqlDbType.SmallDateTime, 4));
        cmd.Parameters["@date_answer"].Value = date_answer;
        cmd.Parameters.Add(new SqlParameter("@aid", SqlDbType.Int, 4));
        cmd.Parameters["@aid"].Value = answer_id;
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

    public void updateRating(int answer_id, int newrating, DateTime date_answer)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "UPDATE user_survey_answers SET rating = @rating, date_answer = @date_answer WHERE id = @aid";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 4));
        cmd.Parameters["@rating"].Value = newrating;
        cmd.Parameters.Add(new SqlParameter("@date_answer", SqlDbType.SmallDateTime, 4));
        cmd.Parameters["@date_answer"].Value = date_answer;
        cmd.Parameters.Add(new SqlParameter("@aid", SqlDbType.Int, 4));
        cmd.Parameters["@aid"].Value = answer_id;
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

    public DataSet getAnswers(int auto_card)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "SELECT * FROM user_survey_answers WHERE auto_card = " + auto_card;

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();

        try
        {
            da.Fill(ds, "answers");
            return ds;
        }
        catch (Exception exc)
        {
            throw new Exception(exc.Message);
        }
    }

    public DataSet getAnswersByID(int auto_card, int category_id)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "SELECT * FROM user_survey_answers WHERE (auto_card = " + auto_card + ") AND (category_id = " + category_id + ")";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();

        try
        {
            da.Fill(ds, "answers_categ");
            return ds;
        }
        catch (Exception exc)
        {
            throw new Exception(exc.Message);
        }
    }

    public Answer getAnswerOrderByID(int auto_card, int survey_id, int question_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT DISTINCT * FROM user_survey_answers WHERE (auto_card = @auto_card) AND (survey_id = @survey_id) AND (question_id = @question_id)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@auto_card", SqlDbType.Int, 4));
        cmd.Parameters["@auto_card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@survey_id", SqlDbType.Int, 4));
        cmd.Parameters["@survey_id"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@question_id", SqlDbType.Int, 4));
        cmd.Parameters["@question_id"].Value = question_id;

        Answer ans = null;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ans = new Answer((int)reader["id"], (int)reader["question_id"], (int)reader["auto_card"], (int)reader["rating"], "", (int)reader["survey_id"], (int)reader["category_id"], (DateTime)reader["date_answer"], (int)reader["is_text"], (int)reader["is_order"] );
            }
            reader.Close();
            return ans;
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

    public int getAnswerOrderByRating(int auto_card, int survey_id, int rating, int category_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT DISTINCT question_id FROM user_survey_answers WHERE (auto_card = @auto_card) AND (survey_id = @survey_id) AND (rating = @rating) AND (category_id = @category_id)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@auto_card", SqlDbType.Int, 4));
        cmd.Parameters["@auto_card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@survey_id", SqlDbType.Int, 4));
        cmd.Parameters["@survey_id"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@rating", SqlDbType.Int, 4));
        cmd.Parameters["@rating"].Value = rating;
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;

        int question_id = 0;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                question_id = (int)reader["question_id"];
            }
            reader.Close();
            return question_id;
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

    public bool isAnswerCategoryExist(int auto_card, int survey_id, int category_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT DISTINCT * FROM user_survey_answers WHERE (auto_card = @auto_card) AND (survey_id = @survey_id) AND (category_id = @category_id)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@auto_card", SqlDbType.Int, 4));
        cmd.Parameters["@auto_card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@survey_id", SqlDbType.Int, 4));
        cmd.Parameters["@survey_id"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@category_id", SqlDbType.Int, 4));
        cmd.Parameters["@category_id"].Value = category_id;
        
        bool is_exist = false;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                is_exist = true;
            }
            reader.Close();
            return is_exist;
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

    public bool isAnswerExist(int auto_card, int survey_id, int question_id)
    {
        SqlConnection conn = new SqlConnection(this.ConnectionString);
        string sql = "SELECT DISTINCT * FROM user_survey_answers WHERE (auto_card = @auto_card) AND (survey_id = @survey_id) AND (question_id = @question_id)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@auto_card", SqlDbType.Int, 4));
        cmd.Parameters["@auto_card"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@survey_id", SqlDbType.Int, 4));
        cmd.Parameters["@survey_id"].Value = survey_id;
        cmd.Parameters.Add(new SqlParameter("@question_id", SqlDbType.Int, 4));
        cmd.Parameters["@question_id"].Value = question_id;

        bool is_exist = false;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (((int)reader["is_text"] == 1) && ((string)reader["text"] == ""))
                    is_exist = false;
                else
                    is_exist = true;

            }
            reader.Close();
            return is_exist;
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
}
