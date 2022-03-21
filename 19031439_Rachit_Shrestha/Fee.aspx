<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Fee.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Fee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inputHolder">
        <asp:DropDownList ID="StudentDD" runat="server" DataSourceID="StudentDataSource" DataTextField="STUDENT_NAME" DataValueField="STUDENT_ID" CssClass="input">
        </asp:DropDownList>
        <asp:DropDownList ID="DepartmentDD" runat="server" DataSourceID="DepartmentDataSource" DataTextField="DEPARTMENT_NAME" DataValueField="DEPARTMENT_ID" CssClass="input">
        </asp:DropDownList>
        <asp:DropDownList ID="FeeStatusDD" runat="server" CssClass="input">
            <asp:ListItem>Paid</asp:ListItem>
            <asp:ListItem>Unpaid</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="Button1" runat="server" Text="Submit" onClick="AddFee" CssClass="button"/>

        <asp:SqlDataSource ID="StudentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;STUDENT_ID&quot;, &quot;STUDENT_NAME&quot; FROM &quot;STUDENT&quot;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="DepartmentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT &quot;DEPARTMENT_ID&quot;, &quot;DEPARTMENT_NAME&quot; FROM &quot;DEPARTMENT&quot;"></asp:SqlDataSource>
    </div>

    <div class="gridviewHolder">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="JoinDataSource" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="STUDENT_ID" HeaderText="STUDENT_ID" SortExpression="STUDENT_ID" />
                <asp:BoundField DataField="STUDENT_NAME" HeaderText="STUDENT_NAME" SortExpression="STUDENT_NAME" />
                <asp:BoundField DataField="FEE_STATUS" HeaderText="FEE_STATUS" SortExpression="FEE_STATUS" />
                <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT_NAME" SortExpression="DEPARTMENT_NAME" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" Font-Bold="True" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:SqlDataSource ID="JoinDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT BERKELEY_COLLEGE.STUDENT.STUDENT_ID, BERKELEY_COLLEGE.STUDENT.STUDENT_NAME, BERKELEY_COLLEGE.FEE.FEE_STATUS, BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_NAME FROM BERKELEY_COLLEGE.STUDENT INNER JOIN BERKELEY_COLLEGE.FEE ON BERKELEY_COLLEGE.STUDENT.STUDENT_ID = BERKELEY_COLLEGE.FEE.STUDENT_ID INNER JOIN BERKELEY_COLLEGE.DEPARTMENT ON BERKELEY_COLLEGE.FEE.DEPARTMENT_ID = BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_ID"></asp:SqlDataSource>

    </div>
</asp:Content>
