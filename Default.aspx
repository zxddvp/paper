<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html> 
<html lang="en"> 
<head> 
    <meta charset="utf-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1"> 
    <title>毕业论文管理系统</title> 
    <link href="pages/css/base.css" rel="stylesheet">
    <link href="pages/css/login/login.css" rel="stylesheet">

</head> 
<body>
	<div class="login-hd">
		<div class="left-bg"></div>
		<div class="right-bg"></div>
		<div class="hd-inner">
			<span class="logo"></span>
			<span class="split"></span>
			<span class="sys-name">&nbsp</span>
		</div>
	</div>
	<div class="login-bd">
		<div class="bd-inner">
			<div class="inner-wrap">
				<div class="lg-zone">
					<div class="lg-box">
						<div class="lg-label"><h4>用户登录</h4></div>
						<div class="alert alert-error" style="display:none;">
			              <i class="iconfont">&#xe62e;</i>
			              <span>请输入用户名</span>
			            </div>
						 <form id="form1" runat="server">
							<div class="lg-username input-item clearfix">
								<i class="iconfont">&#xe60d;</i>
                                <asp:TextBox ID="userIDtBox" runat="server" Width="250px" Height="40px" ></asp:TextBox>

								<!--<input type="text" placeholder="账号/邮箱">-->
							</div>
							<div class="lg-password input-item clearfix">
								<i class="iconfont">&#xe634;</i>
                                <asp:TextBox ID="pswtBox" runat="server" Width="250px" Height="40px" TextMode="Password" onkeydown="if(event.keyCode==13){document.all.enterBt.focus();}"></asp:TextBox>
								<!--<input type="password" placeholder="请输入密码">-->
							</div>
							<div class="lg-check clearfix">
                                <label style="margin-left:40px;">登录类型：</label>
								<asp:DropDownList runat="server" Width="200px" Height="40px" ID="userType"  
                                      DataSourceID="AccessDataSource1" DataTextField="Role_Name" 
                                      DataValueField="ID" Enabled="True" 
                                      onselectedindexchanged="userType_SelectedIndexChanged1"> 
                                      <asp:ListItem >— —请选择— —</asp:ListItem>
                                  </asp:DropDownList>
                               <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                                  DataFile="~/data/paper.mdb" 
                                  SelectCommand="SELECT [ID], [Role_Name] FROM [Role]" ></asp:AccessDataSource>
							</div>
							<!--<div class="tips clearfix">
								<label><input type="checkbox" checked="checked">记住用户名</label>
								<a href="javascript:;" class="register">立即注册</a>
								<a href="javascript:;" class="forget-pwd">忘记密码？</a>
							</div>-->
							<div class="enter" style="text-align:center;">
								<!--<a href="javascript:;" class="purchaser" onClick="javascript:window.location='main.html'">采购商登录</a>
								<a href="javascript:;" class="supplier" onClick="javascript:window.location='main.html'">供应商登录</a>-->

                               <asp:Button ID="enterBt"  runat="server" Text="登录"   OnClick="enterBt_Click"  CssClass="supplier" Width="120px" Height="40px" />
							</div>
						</form>
					</div>
				</div>
				<div class="lg-poster"></div>
			</div>
		</div>
	</div>
	<div class="login-ft">
		<div class="ft-inner">
			<div class="about-us">
				<a href="javascript:;">关于我们</a>
				<a href="javascript:;">法律声明</a>
				<a href="javascript:;">服务条款</a>
				<a href="javascript:;">联系方式</a>
			</div>
			<div class="address">地址：四川省&nbsp;邮编：610000&nbsp;&nbsp;Copyright&nbsp;©&nbsp;2015&nbsp;-&nbsp;2017&nbsp;&nbsp;版权所有</div>
			<div class="other-info">建议使用IE9及以上版本浏览器&nbsp;川ICP备&nbsp;00000000号&nbsp;E-mail：admin@admin.com</div>
		</div>
	</div>
</body> 
</html>











