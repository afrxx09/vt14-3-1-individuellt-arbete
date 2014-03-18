<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GodOl.Pages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
Obs! Något gick fel.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <h1>Oväntat serverfel</h1>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">Tillbaka</asp:HyperLink>
    </p>
</asp:Content>
