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


public partial class JysShenhe : System.Web.UI.Page
{
    protected string jysadmin;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected string jysnostr;
    protected DataView dv;
    protected void Page_Load(object sender, EventArgs e)
    {
        InitCook();
        if (!IsPostBack)
        {
            
            if (this.JysShen.Attributes["SortExpression"] == null)
            {
                this.JysShen.Attributes["SortExpression"] = "Tea_Name,TL_Name,TT_Name,ZA_Name,JiaoyanshiFirst";

                this.JysShen.Attributes["SortDirection"] = "ASC";
            }
            dv = JysTeaTimuBind();
            this.JysShen.DataSource = dv;
            JysShen.DataBind();
        }

    }
    public void InitCook()
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string jysadmin1 = cookie.Values["jysadmin"].ToString();
            jysadmin = HttpUtility.UrlDecode(jysadmin1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();
            jysnostr = cookie.Values["jysno"].ToString();
        }
        
    }
    public DataView JysTeaTimuBind()
    {
        string SortExpression = this.JysShen.Attributes["SortExpression"];
        string SortDirection = this.JysShen.Attributes["SortDirection"];
        DataView dv1 = new DataView();
        int jysno = ds2.ChangeToInt(jysnostr);
        string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,p.JiaoyanshiFirst,p.XiShenhe,p.ShenbaoTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za where  "
                     + "  p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and  p.Jys_No = " + jysno + " order by p.JiaoyanshiFirst ASC";
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "Jiaoyanshi");
            dv1 = ds.Tables[0].DefaultView;
            dv1.Sort = SortExpression + " " + SortDirection;//指定视图的排序方式
            return dv1;

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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void JysShen_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        JysShen.CurrentPageIndex = e.NewPageIndex;
        JysShen.DataSource = JysTeaTimuBind();
        JysShen.DataBind();
    }
    protected void JysShen_EditCommand(object source, DataGridCommandEventArgs e)
    {
        JysShen.EditItemIndex = e.Item.ItemIndex;
        JysShen.DataSource = JysTeaTimuBind();
        JysShen.DataBind();
    }
    protected void JysShen_UpdateCommand(object source, DataGridCommandEventArgs e)
    {

            string timuid = this.JysShen.DataKeys[e.Item.ItemIndex].ToString();
            string drlvalue = ((DropDownList)e.Item.FindControl("ddl")).SelectedValue.ToString();
        
            string stime = DateTime.Now.ToString();
            int id = ds2.ChangeToInt(timuid);//被选择的论文题目的ID号


            string str = "update PaperShengbao set JiaoyanshiFirst = '" + drlvalue + "',JiaoTime='" + stime + "' where ID = " + id;
                try
                {
                    ds2.DBopen();
                 
                    int result = ds2.ExecuteSql(str);
                    if (result > 0)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('审核成功！');</script>");
                    }
                    else
                    {

                        ds2.alert("审核不成功！", "JysShenhe.aspx");
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
    protected void JysShen_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        JysShen.EditItemIndex = -1;
        JysShen.DataSource = JysTeaTimuBind();
        JysShen.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("JysAdminPSW.aspx");
    }
    protected void JysShen_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {
            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(JysShen.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail.aspx?id=" + Id1.ToString());
            }
        }

    }
    protected void JysShen_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == JysShen.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (JysShen.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        JysShen.Attributes["SortExpression"] = SortExpression;
        JysShen.Attributes["SortDirection"] = SortDirection;
        JysShen.DataSource = JysTeaTimuBind();
        JysShen.DataBind();
    }
}
