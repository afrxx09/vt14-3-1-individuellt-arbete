<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="GodOl.Pages.BreweryPages.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Ta bort bryggeri
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="error-messages" runat="server" />
    <asp:PlaceHolder ID="phConfirmMessage" runat="server">
        <div class="warning-message">
            <p>Är du säker på att du vill ta bort <asp:Label ID="lblBreweryName" runat="server"/>?</p>
        </div>
    </asp:PlaceHolder>
    <div class="form-button-container">
        <asp:LinkButton ID="lbConfirmDelete" CssClass="form-button form-submit" runat="server" OnCommand="lbConfirmDelete_Command">Ta bort</asp:LinkButton>
        <asp:HyperLink ID="hlCancelDelete" CssClass="form-button form-cancel" runat="server">Avbryt</asp:HyperLink>
    </div>
</asp:Content>
