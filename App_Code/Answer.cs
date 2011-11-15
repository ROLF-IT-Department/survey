using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Answer
/// </summary>
public class Answer
{
	private int id;
    private int question_id;
    private int auto_card;
    private int rating;
    private string text;
    private int survey_id;
    private int category_id;
    private DateTime date_answer;
    private int is_text;
    private int is_order;

    public int AnswerID
    {
        get { return id; }
        set { id = value; }
    }

    public int QuestionID
    {
        get { return question_id; }
        set { question_id = value; }
    }

    public int AutoCard
    {
        get { return auto_card; }
        set { auto_card = value; }
    }

    public int Rating
    {
        get { return rating; }
        set { rating = value; }
    }

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public int SurveyID
    {
        get { return survey_id; }
        set { survey_id = value; }
    }

    public int CategoryID
    {
        get { return category_id; }
        set { category_id = value; }
    }

    public DateTime DateAnswer
    {
        get { return date_answer; }
        set { date_answer = value; }
    }

    public int IsText
    {
        get { return is_text; }
        set { is_text = value; }
    }

    public int IsOrder
    {
        get { return is_order; }
        set { is_order = value; }
    }

    public Answer()
    {

    }

    public Answer(int id, int question_id, int auto_card, int rating, string text, int survey_id, int category_id, DateTime date_answer, int is_text, int is_order)
	{
        this.auto_card = auto_card;
        this.date_answer = date_answer;
        this.id = id;
        this.is_text = is_text;
        this.question_id = question_id;
        this.rating = rating;
        this.survey_id = survey_id;
        this.category_id = category_id;
        this.text = text;
        this.is_order = is_order;
	}
}
