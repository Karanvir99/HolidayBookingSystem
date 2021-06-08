<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="HolidayRequestPage.aspx.cs" Inherits="HolidayBookingOnlineSystem.HolidayRequestPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style47 {
            width: 100%;
        }
        .auto-style20 {
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            background-color: black;
            text-align: center;
            height: 50px;
        }
        .auto-style37 {
            width: 161px;
            height: 50px;
        }
        .auto-style23 {
            width: 162px;
            height: 50px;
        }
        .auto-style21 {
            width: 161px;
            height: 80px;
        }
        .auto-style42 {
            width: 162px;
            height: 80px;
        }
        .auto-style13 {
            text-align: center;
        }
        .auto-style48 {
            width: 3159px;
        }
        .auto-style52 {
            width: 1052px;
        }
        .auto-style53 {
            width: 1053px;
        }
        .auto-style54 {
            width: 1053px;
            text-align: center;
        }
        .auto-style56 {
            width: 161px;
            height: 80px;
            text-align: center;
        }
        .auto-style57 {
            width: 161px;
            height: 250px;
        }
        .auto-style58 {
            width: 161px;
            height: 250px;
            text-align: center;
        }
        .auto-style59 {
            width: 162px;
            height: 250px;
        }
        .auto-style61 {
            width: 161px;
            height: 150px;
        }
        .auto-style63 {
            width: 162px;
            height: 150px;
        }
        .auto-style64 {
            width: 161px;
            height: 150px;
            text-align: center;
        }
        .auto-style65 {
            width: 1052px;
            text-align: center;
        }
        .auto-style66 {
            width: 650px;
        }
        .auto-style67 {
            width: 510px;
        }
        .auto-style68 {
            width: 510px;
            height: 1261px;
        }
        .auto-style69 {
            width: 1052px;
            height: 1261px;
        }
        .auto-style70 {
            width: 1053px;
            text-align: center;
            height: 1261px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="auto-style47">
        <tr>
            <td>
                <table class="auto-style48">
                    <tr>
                        <td class="auto-style67">&nbsp;</td>
                        <td class="auto-style52">&nbsp;</td>
                        <td class="auto-style53">
                            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" CssClass="Button" Font-Names="Verdana" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style68"></td>
                        <td class="auto-style69">
            <asp:Panel ID="pnlHolidayRequest" runat="server" CssClass="HolidayRequestPanel">
                <table class="auto-style66">
                    <tr>
                        <td class="auto-style20" colspan="3">
                            <asp:Label ID="lblLogin" runat="server" Font-Names="Verdana" Font-Size="X-Large" Text="Holiday Request" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style37">
                        </td>
                        <td class="auto-style37">
                        </td>
                        <td class="auto-style23"></td>
                    </tr>
                    <tr>
                        <td class="auto-style21"></td>
                        <td class="auto-style56">
                            <asp:Label ID="lblName" runat="server" Font-Names="Verdana" Text="Employee Name" CssClass="Label"></asp:Label>
                            <br />
                            <asp:Label ID="lblEmployeeName" runat="server" Font-Bold="True" Font-Names="Verdana" Text="Label" CssClass="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style56">
                            <asp:Label ID="lblAddress" runat="server" CssClass="Label" Font-Names="Verdana" Text="Address"></asp:Label>
                            <br />
                            <asp:Label ID="lblEmployeeAddress" runat="server" CssClass="Label" Font-Bold="False" Font-Names="Verdana" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style56">
                            <asp:Label ID="lblPhoneNumber" runat="server" CssClass="Label" Font-Names="Verdana" Text="Phone Number"></asp:Label>
                            <br />
                            <asp:Label ID="lblEmployeePhoneNumber" runat="server" CssClass="Label" Font-Bold="False" Font-Names="Verdana" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">
                        </td>
                        <td class="auto-style56">
                            <asp:Label ID="lblOutstandingHolidays" runat="server" Text="Outstanding Holidays" Font-Names="Verdana" CssClass="Label"></asp:Label>
                            <br />
                            <asp:Label ID="lblPendingHolidays" runat="server" Font-Names="Verdana" Text="Label" CssClass="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style56">
                            <asp:Label ID="lblHolidaysApproved" runat="server" CssClass="Label" Font-Names="Verdana" Text="Holidays Approved"></asp:Label>
                            <br />
                            <asp:Label ID="lblApproved" runat="server" Font-Names="Verdana" Text="Label" CssClass="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style56">
                            <asp:Label ID="lblHolidaysRejected" runat="server" CssClass="Label" Font-Names="Verdana" Text="Holidays Rejected"></asp:Label>
                            <br />
                            <asp:Label ID="lblRejected" runat="server" CssClass="Label" Font-Names="Verdana" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style57"></td>
                        <td class="auto-style58">
                            <asp:Label ID="lblStartDate" runat="server" Font-Names="Verdana" Text="Start Date " CssClass="Label"></asp:Label>
                            <br />
                            <asp:UpdatePanel ID="pnlStartDate" runat="server">
                                <ContentTemplate>
                                    <asp:Calendar ID="cdrStartDate" runat="server" Font-Names="Verdana">
                                        <SelectedDayStyle BackColor="Black" />
                                        <WeekendDayStyle BackColor="Silver" />
                                    </asp:Calendar>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </td>
                        <td class="auto-style59"></td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td class="auto-style56">
                            <asp:Label ID="lblEndDate" runat="server" Font-Names="Verdana" Text="End Date" CssClass="Label"></asp:Label>
                            <asp:UpdatePanel ID="pnlEndDate" runat="server">
                                <ContentTemplate>
                                    <asp:Calendar ID="cdrEndDate" runat="server" Font-Names="Verdana">
                                        <SelectedDayStyle BackColor="Black" />
                                        <WeekendDayStyle BackColor="Silver" />
                                    </asp:Calendar>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style42">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style61">
                            </td>
                        <td class="auto-style64">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="Button" Font-Names="Verdana" OnClick="btnSubmit_Click" Text="Submit Request" />
                        </td>
                        <td class="auto-style63"></td>
                    </tr>
                    <tr>
                        <td class="auto-style13" colspan="3">
                            <asp:Label ID="lblValidation" runat="server" Font-Names="Verdana" CssClass="ValidationLabel"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
                        </td>
                        <td class="auto-style70">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style67">&nbsp;</td>
                        <td class="auto-style52">
                            &nbsp;</td>
                        <td class="auto-style54">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style67">&nbsp;</td>
                        <td class="auto-style65">
                            <asp:GridView ID="dgvHolidayRequests" runat="server" CellPadding="10" Font-Names="Verdana" GridLines="Horizontal" Width="650px">
                                <HeaderStyle BackColor="Black" ForeColor="White" />
                            </asp:GridView>
                        </td>
                        <td class="auto-style53">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <link href="Theme.css" rel="stylesheet" type="text/css" />
    </asp:Content>
