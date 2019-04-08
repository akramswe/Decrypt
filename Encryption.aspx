<%@ Page Title="Send Message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encryption.aspx.cs" Inherits="Cryptography3DES.Encryption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Message List </h1>

    <div>

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

 </div>
    <br />
    <table>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text="Message Box" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="107px" Width="329px" TextMode="MultiLine"></asp:TextBox> 
            </td>
        </tr>

         <tr>
            <td>
                 <asp:Button ID="Button1" runat="server" Text="SEND MESSAGE" OnClick="Button1_Click" Font-Bold="True" />
                 <asp:Button ID="Button2" runat="server" Text="Decrypt" Font-Bold="True" OnClick="Button2_Click" />
                 <asp:Button ID="Button3" runat="server" Font-Bold="True" OnClick="Button3_Click" Text="Clear" />
                 <asp:Button ID="Button4" runat="server" Font-Bold="True" OnClick="Button4_Click" Text="Home" />
            </td>
        </tr>

      
    </table>
     <div>

         <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Choose ID"></asp:Label>
         <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        </div>

         <asp:TextBox ID="TextBox3" runat="server" Height="112px" TextMode="MultiLine" Width="333px"></asp:TextBox>

        <br />
</asp:Content>
