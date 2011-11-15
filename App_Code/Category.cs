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
/// Summary description for Category
/// </summary>
public class Category
{
    private int category_id;
    private int cnum;
    private string ctext;
    private int survey_id;
    private int is_order;

    public int CategoryID
    {
        get { return category_id; }
        set { category_id = value; }
    }
    
    public int Cnum
    {
        get { return cnum; }
        set { cnum = value; }
    }

    public string Ctext
    {
        get { return ctext; }
        set { ctext = value; }
    }

    public int Survey_id
    {
        get { return survey_id; }
        set { survey_id = value; }
    }

    public int Is_order
    {
        get { return is_order; }
        set { is_order = value; }
    }
    
    
	public Category()
	{

	}

    public Category(int category_id, int cnum, string ctext, int survey_id, int is_order)
    {
        this.category_id = category_id;
        this.cnum = cnum;
        this.ctext = ctext;
        this.survey_id = survey_id;
        this.is_order = is_order;
    }
}
