<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="LoginEmployeePage.aspx.cs" Inherits="HolidayBookingOnlineSystem.LoginEmployeePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style28 {
            width: 100%;
        }
        .auto-style20 {
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            background-color: black;
            text-align: center;
            height: 50px;
        }
        .auto-style23 {
            width: 150px;
            height: 35px;
        }
        .auto-style26 {
            width: 149px;
            height: 80px;
        }
        .auto-style27 {
            width: 150px;
            height: 80px;
        }
        .auto-style24 {
            width: 149px;
            height: 80px;
            text-align: center;
        }
        .auto-style13 {
            text-align: center;
        }
        .auto-style29 {
            width: 3159px;
        }
        .auto-style30 {
            width: 1052px;
        }
        .auto-style32 {
            width: 1053px;
        }
        .auto-style34 {
            width: 1053px;
            height: 230px;
        }
        .auto-style35 {
            width: 149px;
            height: 35px;
        }
        .auto-style39 {
        width: 1052px;
        height: 230px;
    }
        .auto-style40 {
            width: 450px;
        }
        .auto-style41 {
            width: 628px;
            height: 230px;
        }
        .auto-style42 {
            width: 628px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="auto-style28">
        <tr>
            <td>
                <table class="auto-style29">
                    <tr>
                        <td class="auto-style41"></td>
                        <td class="auto-style39"></td>
                        <td class="auto-style34"></td>
                    </tr>
                    <tr>
                        <td class="auto-style42">&nbsp;</td>
                        <td class="auto-style30">
                            <asp:UpdatePanel ID="updtpnlLogin" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlLogin" runat="server" CssClass="LoginPanel">
                                        <table class="auto-style40">
                                            <tr>
                                                <td class="auto-style20" colspan="3">
                                                    <asp:Label ID="lblLogin" runat="server" CssClass="Label2" Font-Size="X-Large" Text="Login"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style35"></td>
                                                <td class="auto-style35"></td>
                                                <td class="auto-style23"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style26"></td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="lblUsername" runat="server" CssClass="Label" Text="Username"></asp:Label>
                            <br />
                                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox"></asp:TextBox>
                                                </td>
                                                <td class="auto-style27"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style26"></td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="lblPassword" runat="server" CssClass="Label" Text="Password"></asp:Label>
                            <br />
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                                </td>
                                                <td class="auto-style27"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style26"></td>
                                                <td class="auto-style24">
                                                    <asp:Button ID="btnLogin" runat="server" CssClass="Button" OnClick="btnLogin_Click" Text="Login" />
                                                </td>
                                                <td class="auto-style27"></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style13" colspan="3">
                                                    <asp:Label ID="lblvalidation" runat="server" CssClass="ValidationLabel"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style32">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style42">&nbsp;</td>
                        <td class="auto-style30">&nbsp;</td>
                        <td class="auto-style32">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <link href="Theme.css" rel="stylesheet" type="text/css" />
    </asp:Content>
