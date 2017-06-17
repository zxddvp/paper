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

public partial class XLTimuSuggest : System.Web.UI.Page
{
    public paper.Conn ds2 = new paper.Conn();
    string timustr;
    Int32 timu;
    protected OleDbDataReader rd;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        timustr = Request.QueryString["id"].ToString();
        timu = ds2.ChangeToInt(timustr); 
        if (!IsPostBack)
        {
            dt = XLOldSuggest();
            this.TBoxSuggest.Text = "";
            this.TBoxSuggest.Text = dt.Rows[0]["XiSuggest"].ToString();
        }
    }
    public DataTable XLOldSuggest()
    {

        string str = "select XiShenhe,XiSuggest from PaperShengbao  where ID = " + timu + "";

        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "XLSuggest");
            return dt = ds.Tables["XLSuggest"];
            //TextBox.databindings.add("text", Dt, "列"); 


        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return null;

        }
        finally
        {
            ds2.DBclose();
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
                string str = "update PaperShengbao set XiShenhe = '" + shhresult + "',XiSuggest = '" + suggest + "' where ID = " + timu + "";

                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('审核成功！');</script>");
                }
                else
                {

                    ds2.alert("审核不成功！", "XLTimuSuggest.aspx");
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
