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

/// <summary>
/// Summary description for LogonDB
/// </summary>
public class LogonDB
{
    private string ConnectionString;

	public LogonDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["Survey"].ConnectionString; 
	}

    public void insertRecord(string session_id, int auto_card, DateTime date_logon, string ip, string version)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        string sql = "INSERT INTO user_survey_logon (session_id, auto_card, date_logon, ip, version) VALUES (@sid, @emp, @date, @ip, @version)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@sid", SqlDbType.VarChar, 255));
        cmd.Parameters["@sid"].Value = session_id;
        cmd.Parameters.Add(new SqlParameter("@emp", SqlDbType.Int, 4));
        cmd.Parameters["@emp"].Value = auto_card;
        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime, 8));
        cmd.Parameters["@date"].Value = date_logon;
        cmd.Parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar, 255));
        cmd.Parameters["@ip"].Value = ip;
        cmd.Parameters.Add(new SqlParameter("@version", SqlDbType.VarChar, 255));
        cmd.Parameters["@version"].Value = version;
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
