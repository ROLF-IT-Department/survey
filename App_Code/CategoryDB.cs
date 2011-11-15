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
/// Summary description for CategoryDB
/// </summary>
public class CategoryDB
{
	private string ConnectionString;

    public CategoryDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString; 
	}

    public List<Category> getListOfCategories()
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        
        SurveyDB db = new SurveyDB();
        Survey survey = db.getCurrentSurvey();
        
        string sql = "SELECT * FROM user_survey_category WHERE (survey_id = @surveyid) ORDER BY cnum ASC";
        
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@surveyid", SqlDbType.Int, 4));
        cmd.Parameters["@surveyid"].Value = survey.SurveyID;

        List<Category> categories = new List<Category>();

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category cat = new Category((int)reader["id"], (int)reader["cnum"], (string)reader["ctext"], (int)reader["survey_id"], (int)reader["is_order"]);
                categories.Add(cat);
            }
            reader.Close();
            return categories;
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            conn.Close();
        }
        
    }


    public int getValidID(int category_num)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);

        SurveyDB db = new SurveyDB();
        Survey survey = db.getCurrentSurvey();

        string sql = "SELECT id FROM user_survey_category WHERE (survey_id = @surveyid) and (cnum = @cnum)";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@surveyid", SqlDbType.Int, 4));
        cmd.Parameters["@surveyid"].Value = survey.SurveyID;
        cmd.Parameters.Add(new SqlParameter("@cnum", SqlDbType.Int, 4));
        cmd.Parameters["@cnum"].Value = category_num;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int valid_id = -1;
            while (reader.Read())
                valid_id = (int)reader["id"];
            reader.Close();
            return valid_id;
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

    public bool isOrderedCategory(int category_num)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);

        SurveyDB db = new SurveyDB();
        Survey survey = db.getCurrentSurvey();

        string sql = "SELECT cnum FROM user_survey_category WHERE (is_order = 1) and (survey_id = @surveyid) and (cnum = @cnum)";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@surveyid", SqlDbType.Int, 4));
        cmd.Parameters["@surveyid"].Value = survey.SurveyID;
        cmd.Parameters.Add(new SqlParameter("@cnum", SqlDbType.Int, 4));
        cmd.Parameters["@cnum"].Value = category_num;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            bool is_order = false;
            if (reader.Read())
                is_order = true;
            reader.Close();
            return is_order;
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

    public string getCategoryTitle(int category_id)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);

        SurveyDB db = new SurveyDB();
        Survey survey = db.getCurrentSurvey();

        string sql = "SELECT ctext FROM user_survey_category WHERE id = @id";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4));
        cmd.Parameters["@id"].Value = category_id;

        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string name = "";
            while (reader.Read())
                name = (string)reader["ctext"];
            reader.Close();
            return name;
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
