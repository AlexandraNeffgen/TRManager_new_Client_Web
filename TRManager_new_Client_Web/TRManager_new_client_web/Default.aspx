<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TRManager_new_client_web._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Students</h2>
    <Table ID="tb_Geruest">
        <td valign="top">
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="187px" AutoPostBack="True">
                </asp:DropDownList>

            </p>
            <p>
                <asp:Table ID="Students" runat="server" Width="205px">
                </asp:Table>
            </p>
        </td>
        <td valign="top">

            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>

        </td>
        <td style="width: 73px">
            <!--- BEGIN MODAL POPUP DIALOG PANEL --->
            <asp:Button ID="btn_add_incident" runat="server" OnClick="addIncident" Text="Button" />
            <ajaxtoolkit:modalpopupextender id="addIncidentModal" runat="server"
                cancelcontrolid="btnCancel" okcontrolid="btnOkay"
                targetcontrolid="btn_add_incident" popupcontrolid="panel_add_incident"
                popupdraghandlecontrolid="PopupHeader" drag="true"
                backgroundcssclass="ModalPopupBG"></ajaxtoolkit:modalpopupextender>

            <asp:Panel ID="panel_add_incident" style="display: none; border: 1px solid #000" runat="server">
                <div class="HelloWorldPopup">
                    <div class="PopupHeader" id="PopupHeader">Incident anlegen</div>
                    <div class="PopupBody">
                        <table>
                            <tr>
                                <td>
                        <p>Schüler:</p>
                                </td>
                                <td>
                                    <ajaxToolkit:ComboBox ID="student_cb" runat="server"></ajaxToolkit:ComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Kommentar:
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_comment" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Controls">
                        <asp:Button ID="btnOkay" runat="server" Text="Incident anlegen" />
                        <asp:Button ID="btnCancel" runat="server" Text="Abbrechen" />    
                    </div>
                </div>
            </asp:Panel>
            <!--- END MODAL POPUP DIALOG PANEL --->

        </td>

        </Table>
        </asp:Content>