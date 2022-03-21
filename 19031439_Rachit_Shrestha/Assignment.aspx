<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Assignment.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Assignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inputHolder">
        <asp:TextBox ID="txtID" runat="server" Visible ="false" CssClass="input"></asp:TextBox>

        <asp:TextBox ID="AssignmentTypeTB" runat="server" CssClass="input"></asp:TextBox>

        <asp:DropDownList ID="DepartmentDD" runat="server" DataSourceID="DepartmentDataSource" DataTextField="DEPARTMENT_NAME" DataValueField="DEPARTMENT_ID" CssClass="input">
        </asp:DropDownList>
        <asp:SqlDataSource ID="DepartmentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;DEPARTMENT_ID&quot;, &quot;DEPARTMENT_NAME&quot; FROM &quot;DEPARTMENT&quot;"></asp:SqlDataSource>

    </div>
    
    <div class="gridviewHolder">
            <asp:GridView ID="AssignmentGV" runat="server" DataKeyNames="Assignment_ID,Assignment_TYPE,DEPARTMENT_ID,DEPARTMENT_NAME" Width="100%" 
                OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  
                OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" 
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
                <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
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
         <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:Button ID="btnSubmit" runat="server" Text="Button" onClick="btnSubmit_Click" CssClass="button"/>
    </div>

</asp:Content>
