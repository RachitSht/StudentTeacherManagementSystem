<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Teacher.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Teacher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inputHolder">
    <asp:TextBox ID="txtID" runat="server" Visible ="false"></asp:TextBox>
    <asp:TextBox ID="TeacherName" runat="server" CssClass="input" placeholder="Teacher Name"></asp:TextBox>
    <asp:TextBox ID="TeacherEmail" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>

    <asp:DropDownList ID="ModuleDD" runat="server" DataSourceID="ModuleDataSource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE" CssClass="input">
    </asp:DropDownList>
    <asp:SqlDataSource ID="ModuleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>

    <asp:DropDownList ID="AddressDD" runat="server" DataSourceID="AddressDataSource" DataTextField="ADDRESS" DataValueField="ADDRESS_ID" CssClass="input">
    </asp:DropDownList>

    <asp:SqlDataSource ID="AddressDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;ADDRESS_ID&quot;, &quot;ADDRESS&quot; FROM &quot;ADDRESS&quot;"></asp:SqlDataSource>

</div>

<div class="gridviewHolder">
    <asp:GridView ID="teacherGV" runat="server" DataKeyNames="TEACHER_ID,TEACHER_NAME,EMAIL" Width="100%" 
        OnSelectedIndexChanging="OnSelectedIndexChanging" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing"
        OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="View" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" Font-Bold="True" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:Button ID="btnSubmit" runat="server" Text="Button" onClick="btnSubmit_Click" CssClass="button"/>
</div>
    
</asp:Content>

