using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class End : System.Web.UI.Page
{
    public int count;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee"] == null) Response.Redirect("Default.aspx");
        Employee emp = (Employee)Session["employee"];

        if (Request.QueryString["end"] != null)
        {
            EmployeeDB db = new EmployeeDB();
            AnswerDB ans = new AnswerDB();
            DataSet ds = ans.getAnswers(emp.AutoCard);
            count = ds.Tables["answers"].Rows.Count;
            this.DataBind();
            if (count >= 5)
                db.updateStatus(emp.ID);
        }
        
    }
}
