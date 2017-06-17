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
using System.Data.OleDb;
using System.Windows.Forms;
public partial class SystemAdminPSW : System.Web.UI.Page
{
    public paper.Conn ds2 = new paper.Conn();
    public string supname;
    protected OleDbDataReader rd;
   
    protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string supname1 = cookie.Values["supname"].ToString();
            supname = HttpUtility.UrlDecode(supname1);
        }
        
        if (!IsPostBack)
        {
            IniWeb();
        }


    }
    public void IniWeb()
    {
      
        this.CurrentPassword.Focus();
        this.CurrentPassword.Text = "";
        this.NewPassword.Text = "";
        this.ConfirmNewPassword.Text = "";
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string cpsw = this.CurrentPassword.Text.ToString();
        string npsw = this.NewPassword.Text.ToString();
        string cnpsw = this.ConfirmNewPassword.Text.ToString();
        Check(cpsw, npsw);

    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        IniWeb();

    }
    private void Check(string t2, string npsw)
    {
        string PassWord = t2;
        string NewPassWord = npsw;
        try
        {

            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader("select * from SuperUser  where Sup_Name='" + supname + "' and Sup_psw='" + PassWord + "'");
            if (rd.Read() == true)
            {
                string str = "update SuperUser set Sup_psw = '" + NewPassWord + "' where Sup_Name = '" + supname + "'";
                int eql = ds2.ExecuteSql(str);
                if (eql == 1)
                {
                    IniWeb();
                     ds2.alert("密码更改成功！", "SystemAdminPSW.aspx");
                }
                else
                {
                    IniWeb();
                    ds2.alert("密码更改不成功！", "SystemAdminPSW.aspx");
                }
            }
            else
            {

                IniWeb();
                ds2.alert("教工号或密码错误！", "SystemAdminPSW.aspx");

            }
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {
            ds2.DBclose();
        }
    }


   
}
