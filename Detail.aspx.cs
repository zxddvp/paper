using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class Detail : System.Web.UI.Page
{
    string timuidstr;
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected DataTable dt;
    protected string roleno;
    int timuid; 
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        timuidstr = Request.QueryString["id"].ToString();
        if (Request.Cookies["UserInfo"] == null)
        {
           Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
           // string teaname1 = cookie.Values["teaname"].ToString();
          //  teaname = HttpUtility.UrlDecode(teaname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();            
        }
        dt = TeaTimuBind();
        this.teaNameLbl.Text = dt.Rows[0]["Tea_Name"].ToString();
         this.TimuLbl.Text = dt.Rows[0]["TimuName"].ToString();
         this.timulaiyuanLbl.Text = dt.Rows[0]["TL_Name"].ToString();
         this.timuJianjieLbl.Text = dt.Rows[0]["TimuJianjie"].ToString();
         this.zaLbl.Text = dt.Rows[0]["ZA_Name"].ToString();
         this.ttLbl.Text = dt.Rows[0]["TT_Name"].ToString();
         this.LblJys.Text = dt.Rows[0]["Jys_Name"].ToString();
         this.timuTiaojianLbl.Text = dt.Rows[0]["TimuTiaojian"].ToString();
         legend.InnerText = "题目详细信息";

       
    }
    public DataTable TeaTimuBind()
    {
        timuid = ds2.ChangeToInt(timuidstr);
        string str = "select p.Tea_Name, p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,j.Jys_Name,p.JiaoyanshiFirst,p.XiShenhe,p.JiaoTime,p.XiTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za,Jiaoyanshi as j where "
                   + "  p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.Jys_No = j.Jys_No and p.ID= " + timuid;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "PaperShengbao");
            return dt = ds.Tables["PaperShengbao"];
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

    protected void ReturnBT_Click(object sender, EventArgs e)
    {
        Response.Write("<script> history.go(-2); </script>"); 

    }
}
