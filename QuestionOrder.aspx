<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuestionOrder.aspx.cs" Inherits="QuestionOrder" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>

<div class="headercss"><asp:Label ID="Header" runat="server" Text=""></asp:Label></div>
<span style="font-weight:bolder; font-size:20px;" id="sSave"></span>
<div class="commentcss"><asp:Label ID="Comment" runat="server" Text=""></asp:Label></div>
<input type="hidden" id='quest_num' value="<% =number_of_questions %>">
<input type="hidden" id='categ_num' value="<% =category_num %>">
    <asp:Label ID="lbTable" runat="server" Text=""></asp:Label>

<br/>
<asp:Label ID="lbSave" runat="server" Text=""></asp:Label>

<br/><br/>
</center>
</asp:Content>

