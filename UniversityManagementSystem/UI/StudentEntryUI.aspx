<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEntryUI.aspx.cs" Inherits="UniversityManagementSystem.UI.StudentEntryUI" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="studentIdHidden" Value="0"/>
    <div>
        <table>
            <tr>
                <td>Department</td>
                <td><asp:DropDownList runat="server" ID="departmentDropDown" Width="100%" /></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Address</td>
                <td><asp:TextBox runat="server" ID="addressTextBox" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Reg No</td>
                <td><asp:TextBox runat="server" ID="regNoTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone No.</td>
                <td><asp:TextBox runat="server" ID="phoneNumberTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" ID="saveButton" OnClick="saveButton_Click" Text="Save"></asp:Button>
                    <asp:Button ID="showAllButton" runat="server" Text="Show All" OnClick="showAllButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:Label runat="server" ID="messageLabel"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
        <div>
            <asp:GridView ID="studentsGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="idHiddenField" Value='<%#Eval("Id")%>'/>
                        <asp:Label runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Registration Number">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("RegNo")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("PhoneNo")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" Text="Update" NavigateUrl='<%# String.Concat("~/UI/StudentEntryUI.aspx?id=", Eval("Id")) %>' ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Delete" ID="deleteButton" OnClick="deleteButton_OnClick"  ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        </div>
    </form>
</body>
</html>
