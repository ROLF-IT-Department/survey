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

public partial class Questions : System.Web.UI.Page
{

    private DataSet ds;
    private DataSet ans;
    private Employee emp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["employee"] == null) Response.Redirect("Default.aspx");
        emp = (Employee)Session["employee"];

        QuestionDB db = new QuestionDB();
        ds = db.getListOfQuestions(returnValidID());

        AnswerDB ansdb = new AnswerDB();
        ans = ansdb.getAnswers(emp.AutoCard);



        if (!IsPostBack)
        {

            if (ds.Tables["questions"].Rows.Count > 0)      // смотрим есть ли в наборе данных вопросы
                if (ds.Tables["questions"].Rows[0].ItemArray[4].ToString() == "1")
                {
                    // если у нас текстовый вопрос
                    if (ds.Tables["questions"].Rows[0].ItemArray[2].ToString() == " ")
                        Comment.Text = "ќставьте, пожалуйста, в этом поле свое мнение по данному вопросу";
                    else
                        Comment.Text = ds.Tables["questions"].Rows[0].ItemArray[2].ToString();
                    TextAnswer.Visible = true;
                    TextAnswer.Text = getTextAnswer((int)ds.Tables["questions"].Rows[0].ItemArray.GetValue(0), emp.AutoCard, emp.SurveyID);
                }
                else
                {

                    GridView1.DataSource = ds;
                    GridView1.DataMember = "questions";
                    GridView1.DataBind();
                    if (returnValidID() == 26)
                        Comment.Text = "ѕожалуйста, оцените \"”довлетворенность\" только по тем льготам, которые вы получаете:<br/> <b>1</b> = абсолютно не согласен (--), <b>2</b> = скорее не согласен (-), <b>3</b> = скорее согласен (+), <b>4</b> = полностью согласен (++)";
                    else
                        Comment.Text = "ѕожалуйста, отметьте, согласны ли ¬ы со следующими утверждени€ми, в соответствии со шкалой:<br/> <b>1</b> = абсолютно не согласен (--), <b>2</b> = скорее не согласен (-), <b>3</b> = скорее согласен (+), <b>4</b> = полностью согласен (++)";
                }

        }
    }

    // при загрузке грида вычисл€ем рейтинги
    protected void GridView1_Load(object sender, EventArgs e)
    {

        int len = GridView1.Columns.Count;
        int count = GridView1.Rows.Count;
        int rating;
        for (int j = 0; j < count; j++)
        {
            rating = getRating((int)ds.Tables["questions"].Rows[j].ItemArray.GetValue(0), emp.AutoCard, emp.SurveyID);
            for (int i = 1; i < 5; i++)
            {
                RadioButton rb = new RadioButton();
                rb.GroupName = GridView1.Rows[j].Cells[1].Text;
                rb.ID = GridView1.Rows[j].Cells[1].Text + i.ToString();
                if (rating == i) rb.Checked = true;
                GridView1.Rows[j].Cells[len - 5 + i].Controls.Add(rb);
            }
        }

    }

    // получаем текст ответа из Ѕƒ, если нет ответа в таблице answers возвращаем -1
    private string getTextAnswer(int question_id, int auto_card, int survey_id)
    {

        foreach (DataRow rows in ans.Tables["answers"].Rows)
        {
            if (((int)rows.ItemArray.GetValue(1) == question_id) && ((int)rows.ItemArray.GetValue(2) == auto_card) && ((int)rows.ItemArray.GetValue(5) == survey_id))
                return (string)rows.ItemArray.GetValue(4);

        }
        return "";
    }

    // получаем рейтинг вопроса, если нет рейтинга в таблице answers возвращаем -1
    private int getRating(int question_id, int auto_card, int survey_id)
    {

        foreach (DataRow rows in ans.Tables["answers"].Rows)
        {
            if (((int)rows.ItemArray.GetValue(1) == question_id) && ((int)rows.ItemArray.GetValue(2) == auto_card) && ((int)rows.ItemArray.GetValue(5) == survey_id))
                return (int)rows.ItemArray.GetValue(3);

        }
        return -1;
    }

    // получаем ID ответа, если нет ответа в таблице answers возвращаем -1
    private int getAnswerID(int question_id, int auto_card, int survey_id)
    {

        foreach (DataRow rows in ans.Tables["answers"].Rows)
        {
            if (((int)rows.ItemArray.GetValue(1) == question_id) && ((int)rows.ItemArray.GetValue(2) == auto_card) && ((int)rows.ItemArray.GetValue(5) == survey_id))
                return (int)rows.ItemArray.GetValue(0);

        }
        return -1;
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        actionSave();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        actionSave();
    }

    // сохранение и обновление данных в таблице
    private void actionSave()
    {
        int len = GridView1.Columns.Count;
        int count = GridView1.Rows.Count;
        int rating;

        if (ds.Tables["questions"].Rows.Count > 0)      // смотрим есть ли в наборе данных вопросы
            if (ds.Tables["questions"].Rows[0].ItemArray[4].ToString() == "1") // есть ли текстовое поле
            {
                AnswerDB db = new AnswerDB();
                int question_id = (int)ds.Tables["questions"].Rows[0].ItemArray.GetValue(0);
                int autocard = emp.AutoCard;
                int survey_id = emp.SurveyID;
                string text = TextAnswer.Text;

                if (getTextAnswer(question_id, emp.AutoCard, emp.SurveyID) == text)
                {
                    CategoryDB db2 = new CategoryDB();
                    SaveEnd();
                    return;
                }
                if ((getAnswerID(question_id, emp.AutoCard, emp.SurveyID) > 0) && (getTextAnswer(question_id, emp.AutoCard, emp.SurveyID) != text))
                {
                    db.updateText(getAnswerID(question_id, emp.AutoCard, emp.SurveyID), text, DateTime.Now);
                    //Response.Write("Update Text");
                    SaveEnd();
                    return;
                }

                db.insertText(question_id, autocard, text, survey_id, returnValidID(), DateTime.Now, 1);
                //Response.Write("Insert Text");
                SaveEnd();
                return;
            }

        for (int j = 0; j < count; j++)
        {
            rating = getRating((int)ds.Tables["questions"].Rows[j].ItemArray.GetValue(0), emp.AutoCard, emp.SurveyID);
            for (int i = 1; i < 5; i++)
            {

                string id = GridView1.Rows[j].Cells[1].Text + i.ToString();
                RadioButton rb = (RadioButton)GridView1.Rows[j].Cells[len - 5 + i].FindControl(id);
                if (rb.Checked)
                {
                    AnswerDB db = new AnswerDB();
                    int question_id = (int)ds.Tables["questions"].Rows[j].ItemArray.GetValue(0);
                    int autocard = emp.AutoCard;
                    int survey_id = emp.SurveyID;
                    if (rating == i) break;  // если рейтинг из базы такой же как проставленный, переходим к другому вопросу

                    if (rating != -1)   // если есть запись ответа в Ѕƒ, но проставленный рейтинг и рейтинг из базы не совпадают, то обновл€ем запись в Ѕƒ
                    {
                        db.updateRating(getAnswerID(question_id, autocard, survey_id), i, DateTime.Now);
                        //Response.Write("Update Ratings");
                        break;
                    }

                    // вставл€ем новую запись в Ѕƒ с рейтингом

                    int rate = i;

                    db.insertResult(question_id, autocard, rate, survey_id, returnValidID(), DateTime.Now);
                    //Response.Write("Insert Ratings");
                }

            }
        }

        SaveEnd();

    }

    private void SaveEnd()
    {
        CategoryDB db1 = new CategoryDB();
        List<Category> categories = db1.getListOfCategories();
        int cid = (int)Session["cid"];
        if (cid == categories.Count) Response.Redirect("List.aspx");
        Comment.Visible = false;
        lSave.Visible = true;
    }
}
