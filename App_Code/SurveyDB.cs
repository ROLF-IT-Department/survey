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
/// Summary description for SurveyDB
/// </summary>
public class SurveyDB
{
    private string ConnectionString;

	public SurveyDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString; 
	}

    public Survey getCurrentSurvey()
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "SELECT * FROM user_survey_polls WHERE active = 1";
        SqlCommand cmd = new SqlCommand(sql, conn);
        Survey survey = null;
        try
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                survey = new Survey((int)reader["id"], (int)reader["survey_num"], (string)reader["description"], (int)reader["active"]);
            reader.Close();
            return survey;
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
