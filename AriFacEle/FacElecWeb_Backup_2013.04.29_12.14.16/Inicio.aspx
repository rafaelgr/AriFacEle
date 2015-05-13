<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="login">
        <table bgcolor="White">
            <tr>
                <td>
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/alzicoopLogo.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLogin" runat="server" Text="Usuario:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" Text="Entrar"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblErr" CssClass="textoRojo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>

