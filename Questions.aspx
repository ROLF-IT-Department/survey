<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">


function Count(text,long) 


{


	var maxlength = new Number(long); // Change number to your max length.


	if (text.value.length > maxlength){


		text.value = text.value.substring(0,maxlength);


		alert("Максимальный размер ответа на вопрос " + long + " символов");


	}


}
</script>

<center>
<div class="headercss"><asp:Label ID="Header" runat="server" Text=""></asp:Label></div>
<span style="font-weight:bolder; font-size:20px;"><asp:Literal ID="lSave" runat="server" Text="Спасибо, Ваши ответы сохранены" Visible="false"></asp:Literal></span>
<div class="commentcss"><asp:Label ID="Comment" runat="server" Text=""></asp:Label></div>
<asp:Label ID="lbQuestionText" runat="server" Text=""></asp:Label>
<asp:TextBox ID="TextAnswer" Width="100%" Height="300px" TextMode="MultiLine"  Visible="false" runat="server" onKeyUp="Count(this,3052)" onChange="Count(this,3052)" ></asp:TextBox>   
 
    <asp:GridView ID="GridView1"  OnLoad="GridView1_Load" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Vertical" BorderColor="Gainsboro" BorderStyle="Solid" Font-Size="Medium" Font-Names="Trebuchet MS" >
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" BorderColor="Transparent" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="50px" BorderColor="Transparent" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" BorderColor="Transparent" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderColor="Transparent" />
        <HeaderStyle BackColor="Firebrick" Font-Bold="True" ForeColor="White" BorderColor="Transparent" Font-Size="Large" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" BorderColor="Transparent" />
        <Columns>
            <asp:BoundField DataField="id" Visible="False" />
            <asp:BoundField DataField="qnum" HeaderText="№" >
                <ItemStyle Width="30px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="qtext" HeaderText="Утверждение" >
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="category_id" Visible="False" />
            <asp:BoundField DataField="is_text" Visible="False" /> 
            <asp:TemplateField HeaderText="1&lt;br/&gt; --">
                <ItemTemplate>              
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="2&lt;br/&gt; -">
                <ItemTemplate>                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="3&lt;br/&gt; +">
                <ItemTemplate>                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="4&lt;br/&gt; ++">
                <ItemTemplate>                   
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" BorderColor="Transparent" />
        <EmptyDataRowStyle BorderColor="Transparent" />
    </asp:GridView>

<br/>
    <asp:ImageButton ID="ImageButton1"  ImageUrl="~/App_Resources/save.gif" runat="server" OnClick="ImageButton1_Click" />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Names="Trebuchet MS" Font-Size="Large" >Сохранить</asp:LinkButton>
<br/><br/>
</center>
</asp:Content>