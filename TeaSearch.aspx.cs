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

public partial class TeaSearch : System.Web.UI.Page
{
    protected string Id;
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;



    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string teaname1 = cookie.Values["teaname"].ToString();
            teaname = HttpUtility.UrlDecode(teaname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();
        }
        ds = TeaTimuBind();
        this.GridView2.DataSource = ds;
        GridView2.DataBind();
        legend.InnerText = "所有上传题目";
    }
    public DataSet TeaTimuBind()
    {

        string str = "select p.ID,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,j.Jys_Name,p.JiaoyanshiFirst,p.XiShenhe,p.XiSuggest,p.JiaoTime,p.XiTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za,Jiaoyanshi as j where p.Tea_Name = "
                    + "'" + teaname + "'" + " and p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.Jys_No=j.Jys_No ";
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "PaperShengbao");
            return ds;

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

    //protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //string a1 = "";
    ////string a2 = "";
    ////string a3 = "";

    //a1 = this.GridView2.DataKeys[e.Item.ItemIndex].ToString();
    //    //a2 = this.myGrid.Items[i].Cells[1].Text;
    //    //a3 = this.myGrid.Items[i].Cells[2].Text;
    //    this.myGrid.Items[i].Attributes.Add("onclick", "window.open('xxx.aspx?a1=" + a1 + "&a2=" + a2 + "&a3=" + a3 + "','','');");
    //    Id = GridView2.SelectedItem.Cells[0].Text.ToString(); 

    //}

    #region 删除题目
    protected void GridView2_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            ds2.DBopen();

            Id = GridView2.DataKeys[e.Item.ItemIndex].ToString();
            int id = ds2.ChangeToInt(Id);

            string strSel = "select IsSel from PaperShengbao where ID = " + id + "";
            string strAllty = " select JiaoyanshiFirst,XiShenhe from PaperShengbao where ID = " + id + "";//查看该题目是否审批通过

            rd = ds2.ExecuteOleDbDataReader(strSel);
            ds = ds2.CreateDataSet(strAllty, "IfAllTy");
            string JysTy = ds.Tables["IfAllTy"].Rows[0]["JiaoyanshiFirst"].ToString();
            string XiTy = ds.Tables["IfAllTy"].Rows[0]["XiShenhe"].ToString();
            if (rd.HasRows)
            {
                rd.Read();
                string isselec = rd["IsSel"].ToString().ToLower();
                rd.Close();
                if (isselec == "true")
                {
                    ds2.alert("已经有学生选了这个论文题目，不能被删除了！", "TeaSearch.aspx");

                }
                else if ((JysTy == "同意") || (XiTy == "同意"))
                {
                    ds2.alert("已经通过教研室或领导审批，不能被删除了！", "TeaSearch.aspx");
                }
                else
                {

                    string SqlDelNews = "delete from PaperShengbao WHERE ID = " + id + "";


                    int re = ds2.ExecuteSql(SqlDelNews);

                    if (re > 0)
                    {

                        string lf = "" + teaname + "进行了删除题目的操作。";
                        ds2.WriteLogfile(lf);
                        ds2.alert("删除成功", "TeaSearch.aspx");

                    }
                    else
                    {

                        ds2.alert("删除失败", "TeaSearch.aspx");

                    }

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
    #endregion

    
    protected void GridView2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        GridView2.CurrentPageIndex = e.NewPageIndex;
        GridView2.DataSource = TeaTimuBind();
        //this.GridView2.DataKeyField = new string[]{"ID"}
        GridView2.DataBind();
    }
    
    protected void GridView2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //GridView2.DataKeyField = new string[]("ID" );
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {



            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(GridView2.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail.aspx?id=" + Id1.ToString());
                // Response.Write("<script>window.open('Detail.aspx?id=" + Id1.ToString() + ")</script>");

            }
            else if (cmd == "Edit")
            {
                string strSel = "select IsSel from PaperShengbao where ID = " + Id1 + "";
                string strAllty = " select JiaoyanshiFirst,XiShenhe from PaperShengbao where ID = " + Id1 + "";//查看该题目是否审批通过
                try
                {
                    ds2.DBopen();
                    rd = ds2.ExecuteOleDbDataReader(strSel);
                    ds = ds2.CreateDataSet(strAllty, "IfAllTy");
                    string JysTy = ds.Tables["IfAllTy"].Rows[0]["JiaoyanshiFirst"].ToString();
                    string XiTy = ds.Tables["IfAllTy"].Rows[0]["XiShenhe"].ToString();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        string isselec = rd["IsSel"].ToString().ToLower();
                        rd.Close();
                        if (isselec == "true")
                        {
                            ds2.alert("已经有学生选了这个论文题目，不能再修改了！", "TeaSearch.aspx");

                        }
                        else if (((JysTy == "同意") && (XiTy == "同意")) || ((JysTy == "同意") && (XiTy == "未审核")))
                        {
                            ds2.alert("已经通过教研室或领导审批，不能再修改了！", "TeaSearch.aspx");
                        }
                        else
                        {
                            Page.Server.Transfer("EditTeaTimu.aspx?id=" + Id1.ToString());
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

            // Id = GridView2.SelectedItem.Cells[0].Text.ToString(); 

        }
    }
}