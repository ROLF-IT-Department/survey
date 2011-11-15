<%@ Page Language="C#" AutoEventWireup="true" CodeFile="End.aspx.cs" Inherits="End" Title="Опрос завершен" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Опрос сотрудников 2008</title>
    <link type="text/css" href="MastePage.css" rel="Stylesheet" />
    <script type="text/javascript">
        var kol = <%# count %>;
        if (kol < 5)
        { 
            alert("Ваше мнение очень важно для нас. Пожалуйста, заполните анкету!");
            window.location = "List.aspx";
        }
    </script>
</head>
<body>
<table cellpadding="0" cellspacing="0" width="100%" height="100%"><tr><td valign="middle" align="center"> 
<table class="end_table" cellpadding="0" cellspacing="0" width="1250px" style="height: 880px">
    <tr><td>&nbsp;</td></tr>
</table>
</td></tr></table> 
</body>
</html>
