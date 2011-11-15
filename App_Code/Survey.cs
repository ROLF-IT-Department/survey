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
/// Summary description for Survey
/// </summary>
public class Survey
{
    private int survey_id;
    private int survey_num;
    private string description;
    private int active;

    public int SurveyID
    {
        get { return survey_id; }
        set { survey_id = value; }
    }
    
    public int SurveyNum
    {
        get { return survey_num; }
        set { survey_num = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public int Active
    {
        get { return active; }
        set { active = value; }
    }
    
    public Survey()
	{
	
    }

    public Survey(int survey_id, int survey_num, string description, int active)
    {
        this.survey_id = survey_id;
        this.active = active;
        this.description = description;
        this.survey_num = survey_num;
    }

}
