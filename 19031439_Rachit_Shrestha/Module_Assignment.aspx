<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Module_Assignment.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Module_Assignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inputHolder">
        <asp:TextBox ID="assignmentTB" runat="server" CssClass="input" placeholder="Grade" Visible="false"></asp:TextBox>
        <asp:TextBox ID="studentTB" runat="server" CssClass="input" placeholder="Grade" Visible="false"></asp:TextBox>
        <asp:TextBox ID="moduleTB" runat="server" CssClass="input" placeholder="Grade" Visible="false"></asp:TextBox>

        <asp:DropDownList ID="AssignmentDD" runat="server" DataSourceID="AssignmentDS" DataTextField="ASSIGNMENT_TYPE" DataValueField="ASSIGNMENT_ID">
        </asp:DropDownList>
        <asp:DropDownList ID="StudentDD" runat="server" DataSourceID="SqlDataSource1" DataTextField="STUDENT_NAME" DataValueField="STUDENT_ID">
        </asp:DropDownList>
        <asp:DropDownList ID="ModuleDD" runat="server" DataSourceID="ModuleDs" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
        </asp:DropDownList>
        <asp:DropDownList ID="GradeDD" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>E</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>

        <asp:SqlDataSource ID="AssignmentDS" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;ASSIGNMENT_ID&quot;, &quot;ASSIGNMENT_TYPE&quot; FROM &quot;ASSIGNMENT&quot;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;STUDENT_ID&quot;, &quot;STUDENT_NAME&quot; FROM &quot;STUDENT&quot;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ModuleDs" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
    </div>

    <div class="gridviewHolder">
       

        <asp:GridView ID="ModuleAssignmentGV" runat="server" 
            DataKeyNames="STUDENT_ID,STUDENT_NAME,MODULE_CODE,MODULE_NAME,ASSIGNMENT_ID,ASSIGNMENT_TYPE,GRADE,STATUS" 
            Width="100%" OnRowDataBound="OnRowDataBound" 
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

        <asp:SqlDataSource ID="ModuleAssigmentDS" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT * FROM &quot;MODULE_ASSIGNMENT&quot;"></asp:SqlDataSource>
        <asp:Button ID="btnSubmit" runat="server" Text="Button" onClick="btnSubmit_Click" CssClass="button"/>
    </div>
</asp:Content>
