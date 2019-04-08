<%@ Page Title="View Message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Decryption.aspx.cs" Inherits="Cryptography3DES.Decryption" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1> ALL MESSAGE</h1>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Message">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Message") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        <div>

        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Choose Message ID" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 40px">
                    <asp:Label ID="Label2" runat="server" Text="Message " Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="115px" Width="264px" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" Height="128px" Width="261px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="VIEW MESSAGE" OnClick="Button2_Click" Font-Bold="True" />
                    <asp:Button ID="Button3" runat="server" Font-Bold="True" OnClick="Button3_Click" Text="Decrypt" />
                    <asp:Button ID="Button4" runat="server" Font-Bold="True" OnClick="Button4_Click" Text="Clear" />
                    <asp:Button ID="Button5" runat="server" Font-Bold="True" OnClick="Button5_Click" Text="Logout" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>

        </table>


    </asp:Content>