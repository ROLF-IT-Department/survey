using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Security.Principal;

public partial class QuestionOrder : System.Web.UI.Page, ICallbackEventHandler 
{
    private Employee emp;
    protected int number_of_questions = 0;
    protected int category_num = 0;

    // входной параметр в ajax функции
    private string eventArgument;
    public void RaiseCallbackEvent(string eventArgument)
    {
        this.eventArgument = eventArgument;
    }

    // процедура обработки ajax вызова - формирование списка сотрудников
    public string GetCallbackResult()
    {
        string argum = eventArgument;
        string html = "";

        AnswerDB adb = new AnswerDB();

        string[] data = argum.Split(';');

        if (adb.isAnswerCategoryExist(emp.AutoCard, emp.SurveyID, returnValidID()))
        {
            // если в базе есть записи с вопросами выставления порядка
            foreach (string rec in data)
            {
                if (String.IsNullOrEmpty(rec)) continue;
                string[] order = rec.Split('|');
                int question_id = Convert.ToInt32(order[0]);
                int rating = Convert.ToInt32(order[1]);

                Answer ans = adb.getAnswerOrderByID(emp.AutoCard, emp.SurveyID, question_id);

                if (rating != ans.Rating)
                    adb.updateRating(ans.AnswerID, rating, DateTime.Now);
            }
        }
        else
        {
            // если в базе НЕТ записей с вопросами выставления порядка
            foreach (string rec in data)
            {
                string[] order = rec.Split('|');
                int question_id = Convert.ToInt32(order[0]);
                int rating = Convert.ToInt32(order[1]);

                adb.insertOrderQuestion(question_id, emp.AutoCard, rating, emp.SurveyID, returnValidID(), DateTime.Now);
            }
        }
        //SaveEnd();

        return html;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee"] == null) Response.Redirect("Default.aspx");
        emp = (Employee)Session["employee"];

        if (Request.QueryString["cid"] != null) category_num = Convert.ToInt32(Request.QueryString["cid"]);
        
        CategoryDB cat = new CategoryDB();
        int valid = cat.getValidID(category_num);

        QuestionDB qdb = new QuestionDB();
        number_of_questions = qdb.getNumberOfOrderQuestion(valid);
        if (number_of_questions > 0)
        {
            Header.Text = cat.getCategoryTitle(valid);
            Page.Title = cat.getCategoryTitle(valid);
            //if (!IsCallback)
            //{
                Comment.Text = "Пожалуйста, проставьте в нужном порядке высказывания. Наибольший вес равен 1.";
            //}
            //else
            //{
            //    Comment.Text = "";
            //}
            

            AnswerDB adb = new AnswerDB();
            List<Question> questions = qdb.getOrderQuestion(valid);

            string html = "";

            html = "<table class='table_order' >";
            if (adb.isAnswerCategoryExist(emp.AutoCard, emp.SurveyID, returnValidID()))
            {
                for (int i = 1; i <= number_of_questions; i++)
                {
                    int quest_id = adb.getAnswerOrderByRating(emp.AutoCard, emp.SurveyID, i, returnValidID());
                    html += "<tr><td width='40px' style='background-color: #F7F6F3; border: solid 1px #DCDCDC'><div class='rank'>" + i.ToString() + "</div></td>";
                    html += "<td style='border: solid 1px #DCDCDC'>" + fillCompletedQuestionsOrder(questions, i, quest_id) + "</td></tr>";
                }
            }
            else
            {
                for (int i = 1; i <= number_of_questions; i++)
                {
                    html += "<tr><td width='40px' style='background-color: #F7F6F3; border: solid 1px #DCDCDC'><div class='rank'>" + i.ToString() + "</div></td>";
                    html += "<td style='border: solid 1px #DCDCDC'>" + fillQuestionsOrder(questions, i) + "</td></tr>";
                }
            }

            html += "</table>";
            
            lbTable.Text += html;
            
            lbSave.Text = "<img src='App_Resources/save.gif' onclick='onSaveButtonClick()' style='cursor: pointer; cursor: hand;'>&nbsp;<span onclick='onSaveButtonClick()' class='order_save' >Сохранить</span>";

            // ajax 
            string cbReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "ClientRefreshCallback", "context");
            string func_name = "SaveCallback";
            string cbScript = "function " + func_name + "(arg, context)" + "{" + cbReference + ";" + "}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), func_name, cbScript, true);
        }
        else
        {
            lbTable.Text = "Нет вопросов для отображения!";
        }

    }

    private string fillQuestionsOrder(List<Question> questions, int num)
    {
        string id = "sel_" + num.ToString();

        string html = "<select name='" + id + "' class='select_order' onchange='onSelectQuestions(\"" + num.ToString() + "\")'>";

        html += "<option value='0' selected></option>";

        List<int> arr = randomIndexes(this.number_of_questions);

        foreach (int index in arr)
        {
            html += "<option value='" + questions[index].QuestionID.ToString() + "' >" + questions[index].Qtext + "</option>";
        
        }
        /*

            foreach (Question quest in questions)
            {
                html += "<option value='" + quest.QuestionID.ToString() + "' >" + quest.Qtext + "</option>";
            }
        */
        html += "</select>";

        return html;
    }

    private string fillCompletedQuestionsOrder(List<Question> questions, int num, int quest_id)
    {
        string id = "sel_" + num.ToString();

        string html = "<select name='" + id + "' class='select_order' onchange='onSelectQuestions(\"" + num.ToString() + "\")'>";

        html += "<option value='0'></option>";

        foreach (Question quest in questions)
        {
            if (quest_id == quest.QuestionID)
            {
                html += "<option value='" + quest.QuestionID.ToString() + "' selected>" + quest.Qtext + "</option>";
            }
        }

        html += "</select>";

        return html;
    }

    private List<int> randomIndexes(int num)
    {
        Random r = new Random();

        List<int> arr = new List<int>();
        bool is_exist = false;
        int chis = 0;
        while (arr.Count < num)
        {
            is_exist = true;
            chis = r.Next(0, num);
            if (arr.Contains(chis))
                is_exist = false;
            if (is_exist) 
                arr.Add(chis);
        }

        return arr;
    }

    // возвращаем корректный integer id
    private int returnValidID()
    {
        try
        {

            int id = Convert.ToInt32(Request.QueryString["cid"]);
            Session["cid"] = id;
            CategoryDB cat = new CategoryDB();
            int valid = cat.getValidID(id);
            Header.Text = cat.getCategoryTitle(valid);
            Page.Title = cat.getCategoryTitle(valid);
            if (valid > 0)
                return valid;
            else
                return 0;
        }
        catch
        {
            //Response.Redirect("List.aspx");
        }
        return 0;
    }
    private void SaveEnd()
    {
        //CategoryDB db1 = new CategoryDB();
        //List<Category> categories = db1.getListOfCategories();
        //int cid = (int)Session["cid"];
        //if (cid == categories.Count) Response.Redirect("List.aspx");
        //Comment.Visible = false;
        //lSave.Visible = true;
        String cstext1 = "<script type=\"text/javascript\">" +
            "alert('Hello World');</" + "script>";
        RegisterStartupScript("mess", cstext1);


    }
}
