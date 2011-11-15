<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Title="Опрос сотрудников 2010" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Вход в систему опроса</title>
     <link type="text/css" href="Default.css" rel="Stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" height="100%"><tr><td valign="middle" align="center"> 

    

        <asp:Table ID="Table1" CssClass="main_table" CellPadding="0" CellSpacing="0" Width="1250px" Height="880px" runat="server">
            <asp:TableRow>
                <asp:TableCell ><!--<img alt="" src="App_Resources/login.jpg" class="background" />-->
                 <center>
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%">
                        <tr >
                            <td style="width: 100%; height: 430px" colspan="2" align="center" valign="top">&nbsp;<!--<span class="warning" >Внимание! Для корректного отображения сайта рекомендуется разрешение экрана 1280x1024 пикселей</span>--></td>
                        </tr>
                        <tr >
                            <td style="width: 50%; height: 430px">&nbsp;</td>
                            <td style="width: 50%; height: 430px" align="left" valign="top">
                                <div class="main_div">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="col_size">
                                        <td align="right"><span class="text">Логин:</span>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="login" CssClass="tb_size" TextMode="SingleLine" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr class="col_size">
                                        <td align="right"><span class="text">Пароль:</span>&nbsp;</td>
                                        <td align="left"><asp:TextBox ID="password" CssClass="tb_size" TextMode="Password" runat="server" ></asp:TextBox></td>
                                    </tr>
                                    <tr class="col_size">
                                        <td colspan="2" align="center"><asp:Button ID="submit" runat="server" Text="Войти" OnClick="submit_Click" /> </td>
                                        
                                    </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                  </center>  
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>

   

</td></tr></table>  

 </form>
</body>
</html>
