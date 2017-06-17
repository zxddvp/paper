using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

public partial class XLTeaBMSuggest : System.Web.UI.Page
{
    public paper.Conn ds2 = new paper.Conn();
    string teaName;
    protected OleDbDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        teaName = Request.QueryString["id"].ToString();
        if(!IsPostBack)
        {

        this.TBoxSuggest.Text = "";
        }
    }

    protected void BTSuggest_Click(object sender, EventArgs e)
    {
        try
        {
            string shhresult = this.DDLShhTeaBMess.SelectedItem.Text.ToString();
            string suggest = this.TBoxSuggest.Text.ToString();
            if (shhresult == "— —请选择— —")
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('请选择审核结果！');</script>");
            }
            else
            {
                string str = "update Teacher set Tea_Shenhe = '" + shhresult + "',Tea_Suggest = '" + suggest + "' where Tea_Name = '" + teaName + "'";

                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('审核成功！');</script>");
                }
                else
                {

                    ds2.alert("审核不成功！", "XiLeader.aspx");
                }
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
