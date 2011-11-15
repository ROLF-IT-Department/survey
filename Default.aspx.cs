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


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // когда опрос завершен, перебрасываем пользователя на информационную страницу
        SurveyDB db = new SurveyDB();
        if (db.getCurrentSurvey() == null) 
            Response.Redirect("Survey_End.aspx");

        Page.SetFocus(login);
        Label1.Text = "";
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        EmployeeDB db = new EmployeeDB();
        Employee emp = db.getEmployee(login.Text, password.Text);
        Label1.Text = "";
        //if ((login.Text == "test") && (password.Text == "test"))
        //{
            if (emp != null)
            {
                Session.Timeout = 60;
                Session["employee"] = emp;
                LogonDB logondb = new LogonDB();
                logondb.insertRecord(Session.SessionID, emp.AutoCard, DateTime.Now, Request.UserHostAddress, Request.UserAgent);
                if (emp.Status == 1) Response.Redirect("End.aspx");
                Response.Redirect("About.aspx");
            }
            else
                Label1.Text = "<script type='text/javascript'>alert('Неправильный логин или пароль!')</script>";
        /*}
        else
            Label1.Text = "<script type='text/javascript'>alert('Проявите терпение! Опрос пока не стартовал!')</script>";
        */
    }
}
