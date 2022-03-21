<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_Student_Module.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Add_Student_Module" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inputHolder">
        <asp:DropDownList ID="StudentDD" runat="server" DataSourceID="StudentDataSource" DataTextField="STUDENT_NAME" DataValueField="STUDENT_ID" CssClass="input">
        </asp:DropDownList>
        <asp:SqlDataSource ID="StudentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;STUDENT_ID&quot;, &quot;STUDENT_NAME&quot; FROM &quot;STUDENT&quot;"></asp:SqlDataSource>
        <asp:DropDownList ID="ModuleDD" runat="server" DataSourceID="ModuleDataSource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE" CssClass="input">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Add Module" onClick="addModule" CssClass="button"/>
        <asp:SqlDataSource ID="ModuleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
    </div>

    <div class="gridviewHolder">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="STUDENT_ID,STUDENT_NAME,MODULE_CODE,MODULE_NAME,CREDIT_HOUR" Width="100%" OnRowDataBound="OnRowDataBound"
              OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
                <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
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
    </div>
</asp:Content>