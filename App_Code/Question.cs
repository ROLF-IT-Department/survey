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
/// Summary description for Question
/// </summary>
public class Question
{
	private int question_id;
    private string qnum;
    private string qtext;
    private int category_id;
    private int is_text;
    private int is_order;

    public int QuestionID
    {
        get { return question_id; }
        set { question_id = value; }
    }
    
    public string Qnum
    {
        get { return qnum; }
        set { qnum = value; }
    }

    public string Qtext
    {
        get { return qtext; }
        set { qtext = value; }
    }

    public int Category_id
    {
        get { return category_id; }
        set { category_id = value; }
    }

    public int Is_text
    {
        get { return is_text; }
        set { is_text = value; }
    }

    public int Is_order
    {
        get { return is_order; }
        set { is_order = value; }
    }
    
	public Question()
	{

	}

    public Question(int question_id, string qnum, string qtext, int category_id, int is_text, int is_order)
    {
        this.category_id = category_id;
        this.is_text = is_text;
        this.qnum = qnum;
        this.qtext = qtext;
        this.question_id = question_id;
        this.is_order = is_order;
    }
}
