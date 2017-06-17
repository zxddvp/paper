using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Teacher
/// </summary>
public class Teacher
{
    #region Protected Members
       protected int Id;
       protected int tea_No;
       protected string tea_Name;
       protected string tea_zhicheng;
       protected int role_No;
       protected string tea_psw;
       protected string tea_xueli;
       protected string tea_xuewei;
       protected string tea_TelNo;
       protected string tea_Sex;
       protected string tea_School;
       protected string tea_Speciality;
       protected string tea_Arrow;
       protected string tea_Course;
       protected string tea_JiaoGai;
       protected string tea_Keyan;
       protected string tea_Xingqu;
       protected int tea_AllowNum;
       #endregion

        #region Public Methods
       public Teacher()
       {
           //
           // TODO: Add constructor logic here
           //
       }
        #endregion

        #region Public Properties
       public int ID
		{
            get { return Id; }
            set { Id = value; }
		}

       public int Tea_No
		{
            get { return tea_No; }
            set { tea_No = value; }
		}

       public string Tea_Name
		{
            get { return tea_Name; }
            set { tea_Name = value; }
		}

       public string Tea_zhicheng
		{
            get { return tea_zhicheng; }
            set { tea_zhicheng = value; }
		}

       public int Role_No
		{
            get { return role_No; }
            set { role_No = value; }
		}

       public string Tea_psw
		{
            get { return tea_psw; }
            set { tea_psw = value; }
		}

       public string Tea_xueli
		{
            get { return tea_xueli; }
            set { tea_xueli = value; }
		}
       public string Tea_xuewei
       {
           get { return tea_xuewei; }
           set { tea_xuewei = value; }
       }
       public string Tea_TelNo
       {
           get { return tea_TelNo; }
           set { tea_TelNo = value; }
       }
       public string Tea_Sex
       {
           get { return tea_Sex; }
           set { tea_Sex = value; }
       }
       public string Tea_School
       {
           get { return tea_School; }
           set { tea_School = value; }
       }
       public string Tea_Speciality
       {
           get { return tea_Speciality; }
           set { tea_Speciality = value; }
       }
       public string Tea_Arrow
       {
           get { return tea_Arrow; }
           set { tea_Arrow = value; }
       }
       public string Tea_Course
       {
           get { return tea_Course; }
           set { tea_Course = value; }
       }
       public string Tea_JiaoGai
       {
           get { return tea_JiaoGai; }
           set { tea_JiaoGai = value; }
       }
       public string Tea_Keyan
       {
           get { return tea_Keyan; }
           set { tea_Keyan = value; }
       }
       public string Tea_Xingqu
       {
           get { return tea_Xingqu; }
           set { tea_Xingqu = value; }
       }
       public int Tea_AllowNum
       {
           get { return tea_AllowNum; }
           set { tea_AllowNum = value; }
       }
		#endregion	
	
}
