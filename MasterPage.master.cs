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
using System.Collections.Generic;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee"] == null) Response.Redirect("Default.aspx");
        Employee emp = (Employee)Session["employee"];
        if (emp.Status == 1) Response.Redirect("End.aspx");

        if (Session["cid"] == null) Session["cid"] = 0;
    
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        CategoryDB db = new CategoryDB();
        int cid = (int)Session["cid"];
        if (cid > 1) --cid;
        else cid = 1;
        Session["cid"] = cid;
        if (db.isOrderedCategory(cid))
            Response.Redirect("QuestionOrder.aspx?cid=" + cid.ToString());
        else
            Response.Redirect("Questions.aspx?cid=" + cid.ToString());
    }
    protected void Forward_Click(object sender, EventArgs e)
    {
        CategoryDB db = new CategoryDB();
        List<Category> categories = db.getListOfCategories();
        int cid = (int)Session["cid"];
        if (cid < categories.Count) ++cid;
        else cid = categories.Count;
        Session["cid"] = cid;
        if (db.isOrderedCategory(cid))
            Response.Redirect("QuestionOrder.aspx?cid=" + cid.ToString());
        else
            Response.Redirect("Questions.aspx?cid=" + cid.ToString());
    }

}
