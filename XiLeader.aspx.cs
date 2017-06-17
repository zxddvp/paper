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


public partial class XiLeader : System.Web.UI.Page
{
    protected string xlname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected DataView dv;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        InitCook();
        //Implement Client Side JavaScript code
        string jsScript = "<script language=JavaScript> \n"
                        + "<!--\n" 
                        + "function confirmDelete (frm) {\n\n" 
                        + " // loop through all elements\n" 
                        + " for (i=0; i<frm.length; i++) {\n\n" 
                        + " // Look for our checkboxes only\n" 
                        + " if (frm.elements[i].name.indexOf (´DeleteThis´) !=-1) {\n" 
                        + " // If any are checked then confirm alert, otherwise nothing happens\n" 
                        + " if(frm.elements[i].checked) {\n" 
                        + " return confirm (´Are you sure you want to delete your selection(s)?´)\n" 
                        + " }\n"
                        + " }\n" 
                        + " }\n" 
                        + "}\n\n\n"
                        + "function select_deselectAll (chkVal, idVal) {\n"
                        + "var frm = document.forms[0];\n"
                        + "// loop through all elements\n" 
                        + " for (i=0; i<frm.length; i++) {\n" 
                        + " // // Look for our Header Template´s Checkbox\n" 
                        + " if (idVal.indexOf (´CheckAll´) != -1) {\n"
                        + " // Check if main checkbox is checked, then select or deselect datagrid checkboxes \n" 
                        + " if(chkVal == true) {\n"
                        + " frm.elements[i].checked = true;\n" 
                        + " } else {\n" 
                        + " frm.elements[i].checked = false;\n" 
                        + " }\n" 
                        + " // Work here with the Item Template´s multiple checkboxes\n" 
                        + " } else if (idVal.indexOf(´DeleteThis´) != -1) {\n" 
                        + " // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox\n"
                        + " if(frm.elements[i].checked == false) {\n" 
                        + " frm.elements[1].checked = false; // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox\n" 
                        + " }\n"
                        + " }\n" 
                        + " }\n" 
                        + "}" 
                        + "//--> \n" 
                        + "</script>";


        //Allows our .NET page to add client-side script blocks when page loads, instead of the conventional HTML JS tags.
        RegisterClientScriptBlock("clientScript", jsScript);

        WebControl button = (WebControl)Page.FindControl("Confirm");
        button.Attributes.Add("onclick", "return confirmDelete (this.form);");

        if (!IsPostBack)
        {
            if (this.XiShen.Attributes["SortExpression"] == null)
            {
                this.XiShen.Attributes["SortExpression"] = "Tea_Name,TL_Name,TT_Name,ZA_Name,XiShenhe";

                this.XiShen.Attributes["SortDirection"] = "ASC";
            }
            dv = AllTimuBind();
            this.XiShen.DataSource = dv;
            XiShen.DataBind();
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
            string xlname1 = cookie.Values["xlname"].ToString();
            xlname = HttpUtility.UrlDecode(xlname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();
           
        }

    }

    #region 绑定该领导要审批的论文题目
    public DataView AllTimuBind()
    {
        string SortExpression = this.XiShen.Attributes["SortExpression"];
        string SortDirection = this.XiShen.Attributes["SortDirection"];
        DataView dv1 = new DataView();
        string str;
        if (teano == "207004")
       {
           str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,p.JiaoyanshiFirst,p.XiShenhe,p.ShenbaoTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za where  "
                     + " p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.JiaoyanshiFirst ='同意'"
                     + " and (Jys_No = 1 or Jys_No = 11)"; 
            //in (select Jys_No from Jiaoyanshi where Jys_Name = '基础数学教研室' or Jys_Name = '学科教学法教研室')";
       }
        else if (teano == "207001")
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,p.JiaoyanshiFirst,p.XiShenhe,p.ShenbaoTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za where  "
                      + " p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.JiaoyanshiFirst ='同意'"
                      + " and Jys_No = 9";
        }
        else
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name,p.JiaoyanshiFirst,p.XiShenhe,p.ShenbaoTime from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za where  "
                      + " p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.JiaoyanshiFirst ='同意'"
                      + " and Jys_No = 10";
        }
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "PaperShengbao");
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
    #endregion
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void XiShen_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        XiShen.CurrentPageIndex = e.NewPageIndex;
        XiShen.DataSource = AllTimuBind();
        XiShen.DataBind();
    }

    #region 进行审核单个题目操作
    protected void XiShen_EditCommand(object source, DataGridCommandEventArgs e)
    {
        XiShen.EditItemIndex = e.Item.ItemIndex;
        XiShen.DataSource = AllTimuBind();
        XiShen.DataBind();
    }
    protected void XiShen_UpdateCommand(object source, DataGridCommandEventArgs e)
    {

        string timuid = this.XiShen.DataKeys[e.Item.ItemIndex].ToString();
        string drlvalue = ((DropDownList)e.Item.FindControl("ddl")).SelectedValue.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(timuid);//被选择的论文题目的ID号


        string str = "update PaperShengbao set XiShenhe = '" + drlvalue + "',XiTime = '" + stime + "' where ID = " + id;
        try
        {
            ds2.DBopen();

            int result = ds2.ExecuteSql(str);
            if (result > 0)
            {
                ds2.alert("审核成功！", "XiLeader.aspx");
            }
            else
            {

                ds2.alert("审核不成功！", "XiLeader.aspx");
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


    protected void XiShen_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        XiShen.EditItemIndex = -1;
        XiShen.DataSource = AllTimuBind();
        XiShen.DataBind();

    }
    #endregion

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("XiLeaderPSW.aspx");
    }

    #region 读取题目详细信息
    protected void XiShen_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {
            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(XiShen.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail.aspx?id=" + Id1.ToString());
            }

            else if (cmd == "Shenhe")
            {  //Response.Redirect("StuSelTeaMess.aspx");
                Page.Server.Transfer("XLTimuSuggest.aspx?id=" + Id1.ToString());
            }
        }
    }
    #endregion

    #region 同意审批所有论文题目
    protected void allowAllTimuBT_Click(object sender, EventArgs e)
    {
        string stime = DateTime.Now.ToString();

        string str;
        if (teano == "207004")
        {
            str = "update PaperShengbao set XiShenhe = '同意',XiTime = '" + stime + "' where JiaoyanshiFirst = '同意' and XiShenhe = '未审核' and Jys_No in (select Jys_No from Jiaoyanshi where Jys_Name = '基础数学教研室' or Jys_Name = '学科教学法教研室')";
        }
        else if (teano == "207001")
        {
            str = "update PaperShengbao set XiShenhe = '同意',XiTime = '" + stime + "' where JiaoyanshiFirst = '同意' and XiShenhe = '未审核' and Jys_No = 9";
        }
        else
        {
            str = "update PaperShengbao set XiShenhe = '同意',XiTime = '" + stime + "' where JiaoyanshiFirst = '同意' and XiShenhe = '未审核' and Jys_No = 10";
        }
       
        try
        {
            ds2.DBopen();

            int result = ds2.ExecuteSql(str);
            if (result > 0)
            {
                ds2.alert("审核成功！", "XiLeader.aspx");
            }
            else
            {

                ds2.alert("审核不成功！", "XiLeader.aspx");
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

    


        //public void Page_Load(Object Sender, EventArgs E)
        //{

            

        //    if (!IsPostBack)
        //    {

        //        BindData();

        //    }


        //}


         protected void ShenheAllSel(object sender, EventArgs e)
        {


            string dgIDs = "";
            bool BxsChkd = false;

            foreach (DataGridItem i in XiShen.Items)
            {

                CheckBox deleteChkBxItem = (CheckBox)i.FindControl("DeleteThis");

                if (deleteChkBxItem.Checked)
                {

                    BxsChkd = true;

                    // Concatenate DataGrid item with comma for SQL Delete
                    dgIDs += ((Label)i.FindControl("ID")).Text.ToString() + ",";

                }

            }
            string stime = DateTime.Now.ToString();
                         

            // Set up SQL Delete statement, using LastIndexOf to remove tail comma from string.
            
            
            if (BxsChkd == true)
            { // Execute SQL Query only if checkboxes are checked, otherwise error occurs with initial null string
                string deleteSQL = "update PaperShengbao set XiShenhe = '同意',XiTime = '" + stime + "' WHERE ID IN (" + dgIDs.Substring(0, dgIDs.LastIndexOf(",")) + ")";
                try
                {
                    ds2.DBopen();
                    ds2.ExecuteSql(deleteSQL);

                    //SqlHelper.ExecuteNonQuery(objConnect, CommandType.Text, deleteSQL);
                    OutputMsg.InnerHtml += "<font size=4><b> Information has been updated.</b></font>";
                    OutputMsg.Style["color"] = "green";

                }
                catch (System.Data.OleDb.OleDbException err)
                {

                    OutputMsg.InnerHtml += err.Message.ToString(); //"<font size=4><b>An error occurred and the record could not be deleted</b></font>";
                    OutputMsg.Style["color"] = "red";

                }

                //Refresh data
                //BindData();
                dv = AllTimuBind();
                this.XiShen.DataSource = dv;
                XiShen.DataBind();

            }

        }


        //public void BindData()
        //{

        //    String sqlQuery = "Select stor_id As Id, stor_name As Store, City, State, Zip from Stores";

        //    MyDataGrid.DataSource = SqlHelper.ExecuteDataset(objConnect, CommandType.Text, sqlQuery);
        //    MyDataGrid.DataBind();

        //    objConnect.Close();
        //    objConnect = null;

        //}

         protected void XiShen_SortCommand(object source, DataGridSortCommandEventArgs e)
         {
             string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
             string SortDirection = "ASC"; //为排序方向变量赋初值
             if (SortExpression == XiShen.Attributes["SortExpression"])  //如果为当前排序列
             {
                 SortDirection = (XiShen.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

             }
             XiShen.Attributes["SortExpression"] = SortExpression;
             XiShen.Attributes["SortDirection"] = SortDirection;
             XiShen.DataSource = AllTimuBind();
             XiShen.DataBind();
         }
}
