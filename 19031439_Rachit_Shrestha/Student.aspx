<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Student.aspx.cs" Inherits="_19031439_Rachit_Shrestha.Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="inputHolder">
    <asp:TextBox ID="txtID" runat="server" Visible ="false" CssClass="input" ></asp:TextBox>
    <asp:TextBox ID="StudentName" runat="server" CssClass="input" placeholder="Student Name"></asp:TextBox>
    <asp:TextBox ID="StudentAddress" runat="server" CssClass="input" placeholder="Address"></asp:TextBox>
    <asp:TextBox ID="StudentAttendance" runat="server" CssClass="input" placeholder="Attendance"></asp:TextBox>

</div>

     <div class="gridviewHolder">
            <asp:GridView ID="studentGV" runat="server" DataKeyNames="STUDENT_ID,STUDENT_NAME,STUDENT_ADDRESS,ATTENDANCE,EXAM_STATUS" 
                Width="100%" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" 
                OnSelectedIndexChanging="OnSelectedIndexChanging" OnRowCancelingEdit ="OnRowCancelingEdit"  
                OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
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
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BerkeleyCollege %>" ProviderName="<%$ ConnectionStrings:BerkeleyCollege.ProviderName %>" SelectCommand="SELECT * FROM &quot;STUDENT&quot;"></asp:SqlDataSource>
        <asp:Button ID="btnSubmit" runat="server" Text="Button" onClick="btnSubmit_Click" CssClass="button"/>
    </div>
</asp:Content>
