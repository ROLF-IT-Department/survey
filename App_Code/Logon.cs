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
/// Summary description for Logon
/// </summary>
public class Logon
{
    private string sessionid;
    private int autocard;
    private DateTime datelogon;
    private string ip;
    private string version;

    public string SessionID
    {
        get { return sessionid; }
        set { sessionid = value; }
    }

    public int AutoCard
    {
        get { return autocard; }
        set { autocard = value; }
    }

    public DateTime DateLogon
    {
        get { return datelogon; }
        set { datelogon = value; }
    }

    public string IP
    {
        get { return ip; }
        set { ip = value; }
    }

    public string Version
    {
        get { return version; }
        set { version = value; }
    }

    public Logon(string sessionid, int autocard, DateTime datelogon, string ip, string version)
	{
        this.sessionid = sessionid;
        this.autocard = autocard;
        this.datelogon = datelogon;
        this.ip = ip;
        this.version = version;
	}
}
