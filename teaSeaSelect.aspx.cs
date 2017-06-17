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

public partial class teaSeaSelect : System.Web.UI.Page
{
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    string isallowed;
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
            if (!IsPostBack)
            {
                ds = StuTimuBind();
                this.DgTeaStu.DataSource = ds;
                DgTeaStu.DataBind();
                legend.InnerText = "选题情况";
            }
    }

    public DataSet StuTimuBind()
    {

        string str = "select p.TimuName, s.Stu_No,s.Stu_Name,s.Stu_Class,s.Stu_Tel,s.Stu_Istongyi,s.Zhehe_Zong from PaperShengbao as p,Student as s  where p.Tea_Name = "
                    + "'" + teaname + "'" + " and p.ID = s.PSB_Id and s.IsSelected = 1";
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
    protected void DgTeaStu_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DgTeaStu.CurrentPageIndex = e.NewPageIndex;
        DgTeaStu.DataSource = StuTimuBind();
        DgTeaStu.DataBind();
    }


    protected void DgTeaStu_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {
            string cmd = e.CommandName;//获取命令名称
            Int64 Id1 = Convert.ToInt64(DgTeaStu.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail_StuBase.aspx?id=" + Id1.ToString());
            }
        }
    }
    protected void DgTeaStu_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DgTeaStu.EditItemIndex = e.Item.ItemIndex;
        DgTeaStu.DataSource = StuTimuBind();
        DgTeaStu.DataBind();
    }
    protected void DgTeaStu_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        DgTeaStu.EditItemIndex = -1;
        DgTeaStu.DataSource = StuTimuBind();
        DgTeaStu.DataBind();
    }

    #region 读取教师题目允许被选的数目
    public string TeaAllowNum(string teano)
    {
        string allownum = "10";
        string teaNo = teano;
        Int32 tea_no = ds2.ChangeToInt(teaNo);
        string str = "select Tea_AllowNum from Teacher where Tea_No = " + tea_no;
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                allownum = rd["Tea_AllowNum"].ToString();

                rd.Close();
            }
            return allownum;

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
    #endregion

    //public int TeaTimuSelCount(string teano)//教师题目被选的数目
    //{
    //    string teaNo = teano;
    //    Int32 tea_no = ds2.ChangeToInt(teaNo);
    //    string str = "select Tea_StuNum from Teacher where  Tea_No = " + tea_no;
    //    try
    //    {
    //        ds2.DBopen();
    //        ds = ds2.CreateDataSet(str, "TeaTmSel");
    //        string numstr = ds.Tables["TeaTmSel"].Rows.Count.ToString();
    //        int num = ds2.ChangeToInt(numstr);

    //        return num;
    //    }
    //    catch (System.Data.OleDb.OleDbException ex)
    //    {
    //        Response.Write(ex.ToString());
    //        return -1;
    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }
    //}

    protected void DgTeaStu_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string stunostr = this.DgTeaStu.DataKeys[e.Item.ItemIndex].ToString();
        string allowed = StuAllowed(stunostr);//查看学生是否被教师同意通过
        if (allowed == "同意")
        {
            ds2.alert("您已经同意了指导该同学，不能再更改！", "teaSeaSelect.aspx");
        }
        else
        {
            string drlvalue = ((DropDownList)e.Item.FindControl("ddl")).SelectedValue.ToString();
            if (drlvalue == "同意")
            {
                string allownumstr = TeaAllowNum(teano);
                int allownum = ds2.ChangeToInt(allownumstr);//获取教师被允许的数目

                int selcount = TeaSelCount(teano);//获取教师目前被选择的数目


                //使用DateTime对象的静态属性Now，获取一个表示当前时间的实例：
                //DateTime dt = DateTime.Now;

                //如果需要像23:46 2007-1-26这样的时间格式的话，自己用以下两个方法拼一下就可以了：
                //dt.ToShortTimeString()
                //dt.ToShortDateString()

                if (selcount >= allownum)
                {
                    ds2.alert("您同意的学生数已经超过您的上限，请将其他学生审核为不同意，以便学生可以尽早的选择其他教师！", "teaSeaSelect.aspx");
                }
                else
                {
                string stime = DateTime.Now.ToString();
                Int64 stuno = Int64.Parse(stunostr);//被选择的学生的学号


                string str = "update Student set Stu_Istongyi = '" + drlvalue + "'" + "where Stu_No = " + stuno;

                try
                {
                    ds2.DBopen();

                    int result = ds2.ExecuteSql(str);
                    if (result > 0)
                    {
                        Int32 teano1 = ds2.ChangeToInt(teano);
                        TeaSeledAdd(teano1);
                        //System.Web.HttpContext.Current.Response.Write("<script>alert('审核成功！');</script>");

                        ds2.alert("审核成功！", "teaSeaSelect.aspx");
                    }
                    else
                    {

                        ds2.alert("审核不成功！", "teaSeaSelect.aspx");
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
            else
            {
                Int64 stuno = Int64.Parse(stunostr);//被选择的学生的学号

                string str = "update Student set IsSelected = 0, Stu_Istongyi = '" + drlvalue + "'" + "where Stu_No = " + stuno;
                Int32 id = Stu_PSBID(stuno);
                string SQL = "update PaperShengbao set IsSel = false where ID = " + id;
                try
                {
                    ds2.DBopen();
                    int result = ds2.ExecuteSql(SQL);
                    int result2 = ds2.ExecuteSql(str);                 
                    if ((result > 0)&&(result2 > 0))
                    {
                        //System.Web.HttpContext.Current.Response.Write("<script>alert('审核成功！');</script>");

                        ds2.alert("审核成功！", "teaSeaSelect.aspx");
                    }
                    else
                    {

                        ds2.alert("审核不成功！", "teaSeaSelect.aspx");
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
    }
    #region 教师被选数目加1
    public void TeaSeledAdd(int teano)
    {
        string SQL = "update Teacher set  Tea_StuNum = Tea_StuNum + 1 where Tea_No =" + teano;
        try
        {
            ds2.DBopen();

            int result = ds2.ExecuteSql(SQL);

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

    //#region 读取教师题目允许被选的数目
    //public string TeaAllowNum(int teano)
    //{
    //    string allownum = "7";

    //    string str = "select Tea_AllowNum from Teacher where Tea_No = " + teano + "";
    //    try
    //    {
    //        ds2.DBopen();

    //        rd = ds2.ExecuteOleDbDataReader(str);
    //        if (rd.HasRows)
    //        {
    //            rd.Read();
    //            allownum = rd["Tea_AllowNum"].ToString();

    //            rd.Close();
    //        }
    //        return allownum;

    //    }
    //    catch (System.Data.OleDb.OleDbException e)
    //    {
    //        Response.Write(e.ToString());
    //        return null;

    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }
    //}
    //#endregion

    #region 教师目前被选的数目
    public int TeaSelCount(string teano)
    {
        Int32 teano1 = ds2.ChangeToInt(teano);
        string str = "select Tea_StuNum from Teacher where Tea_No = " + teano1 + "";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {

                rd.Read();
                string teaselnumstr = rd["Tea_StuNum"].ToString();
                rd.Close();
                ds2.DBclose();
                int teaselnum = ds2.ChangeToInt(teaselnumstr);
                return teaselnum;
            }
            else return -1;
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            return -1;
        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion

    #region 查看学生是否被教师同意通过
    public string StuAllowed(string stunostr)
    {
        Int64 stuno = Int64.Parse(stunostr);
        string str = "select Stu_Istongyi from Student where Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                isallowed = rd["Stu_Istongyi"].ToString();

                rd.Close();
            }
            return isallowed;

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
    #endregion

    #region 通过学号查找学生选择的论文题目ID
    public Int32 Stu_PSBID(Int64 stuno)
    {
        string str = "select PSB_Id from Student  where Stu_No = " + stuno ;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "PSB_Id");
            string psbidstr = ds.Tables[0].Rows[0]["PSB_Id"].ToString();
            Int32 psbid = ds2.ChangeToInt(psbidstr);
            return psbid;

        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return -1;

        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion
}
