// JScript 文件


  function TodayDate()
  {
var date = new Date();
var days = new Array('星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六');
var temp = date.getFullYear() + "年" + ( date.getMonth() + 1) + "月" + date.getDate() + "日" + "　" + days[date.getDay()];
document.write(temp);
  }
  
  
  function checkSearchEmpty()
{
  var key = Form1.keyWord.value; 

  if(key=="")
  {
    alert("请输入查找内容！");
    return false;
  }
  else
  {
  
    return true;
  }
  
}

 function checkLoginEmpty()
{
 
  var userName=Form1.username.value;
  var passWord=Form1.password.value;

  if(userName=="")
  {
    alert("请输入用户名");
    return false;
  }
　 else if(userName.indexOf("'")>=0) 
 　{
   　alert("你输入带有非法字符符号");
    return false;  
   }
  
  else if(passWord=="")
  {
    alert("请输入密码");
    return false;
   
  }
  else
  {
  
    return true;
  }
  
}
