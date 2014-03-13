<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="GodOl.Pages.BeerPages.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Ta bort öl.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:PlaceHolder ID="phConfirmMessage" runat="server">
        Är du säker på att du vill ta bort <asp:Label ID="lblBeerName" runat="server"/>?
    </asp:PlaceHolder>
    <asp:LinkButton ID="lbConfirmDelete" runat="server" OnCommand="lbConfirmDelete_Command">Ta bort</asp:LinkButton>
    <asp:HyperLink ID="hlCancelDelete" runat="server">Avbryt</asp:HyperLink>
</asp:Content>
