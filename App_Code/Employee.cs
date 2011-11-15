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
/// Объект сотрудника
/// </summary>
public class Employee
{
    private int id;
    private int autocard;
    private string company;
    private string rank;
    private string sex;
    private string emp_group;
    private string age;
    private string standing;
    private string login;
    private string password;
    private int surveyid;
    private int status;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int AutoCard
    {
        get { return autocard; }
        set { autocard = value; }
    }

    public string Company
    {
        get { return company; }
        set { company = value; }
    }

    public string Rank
    {
        get { return rank; }
        set { rank = value; }
    }

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }

    public string EmpGroup
    {
        get { return emp_group; }
        set { emp_group = value; }
    }

    public string Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Standing
    {
        get { return standing; }
        set { standing = value; }
    }

    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public int SurveyID
    {
        get { return surveyid; }
        set { surveyid = value; }
    }

    public int Status
    {
        get { return status; }
        set { status = value; }
    }

    public Employee()
    {

    }

    public Employee(int id, int autocard, string company, string rank, string sex, string emp_group, string age, string standing, string login, string password, int surveyid, object status)
	{
        this.id = id;
        this.autocard = autocard;
        this.company = company;
        this.rank = rank;
        this.sex = sex;
        this.emp_group = emp_group;
        this.age = age;
        this.standing = standing;
        this.login = login;
        this.password = password;
        this.surveyid = surveyid;
        if (!Convert.IsDBNull(status)) this.status = Convert.ToInt16(status);
	}
}
