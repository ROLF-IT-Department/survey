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
using System.Text;

public partial class Main : System.Web.UI.Page
{
    private Employee emp;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee"] == null) Response.Redirect("Default.aspx");
        emp = (Employee)Session["employee"];
        AnswerDB adb = new AnswerDB();
        CategoryDB db = new CategoryDB();
        List<Category> categories = db.getListOfCategories();

        StringBuilder htmlStr = new StringBuilder(""); 
        htmlStr.Append("<br/>");
        

        foreach (Category cat in categories)
        {
            if (cat.Is_order == 1)
            {
                if (adb.isAnswerCategoryExist(emp.AutoCard, emp.SurveyID, cat.CategoryID))
                    htmlStr.Append("<br/><a href='QuestionOrder.aspx?cid=" + cat.Cnum + "' class='category'>" + cat.Cnum + ") " + cat.Ctext + "</a>&nbsp;<img alt=\"\" src=\"App_Resources/completed.jpg\"><br/>");
                else
                    htmlStr.Append("<br/><a href='QuestionOrder.aspx?cid=" + cat.Cnum + "' class='category'>" + cat.Cnum + ") " + cat.Ctext + "</a><br/>");
            }
            else
            {
                if (categoryIsCompleted(cat.CategoryID))
                    htmlStr.Append("<br/><a href='Questions.aspx?cid=" + cat.Cnum + "' class='category'>" + cat.Cnum + ") " + cat.Ctext + "</a>&nbsp;<img alt=\"\" src=\"App_Resources/completed.jpg\"><br/>");
                else
                    htmlStr.Append("<br/><a href='Questions.aspx?cid=" + cat.Cnum + "' class='category'>" + cat.Cnum + ") " + cat.Ctext + "</a><br/>");
            }
        }
        Label lb = new Label();
        lb.Text = htmlStr.ToString();
        Panel1.Controls.Add(lb);
    }

    private bool categoryIsCompleted(int category_id)
    {
        AnswerDB adb = new AnswerDB();
        QuestionDB db = new QuestionDB();
        DataSet ds = db.getIDOfQuestions(category_id);
        if (ds.Tables["questionsid"].Rows.Count == 0) return false;

        foreach (DataRow rows in ds.Tables["questionsid"].Rows)
        {
            int id = (int)rows.ItemArray.GetValue(0);

            if (!adb.isAnswerExist(emp.AutoCard, emp.SurveyID, id))
                return false;
        }

        return true;
    }



}
