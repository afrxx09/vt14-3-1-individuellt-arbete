<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="BreweryList.aspx.cs" Inherits="GodOl.Pages.BreweryPages.BreweryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:Panel ID="pnlSuccess" CssClass="success-panel" runat="server" Visible="false">
        <asp:Label ID="lblSuccess" CssClass="success-message" runat="server" Text="" />
    </asp:Panel>
    <asp:ListView ID="lwBreweries" runat="server" SelectMethod="lwBreweries_GetData" DataKeyNames="BreweryId" ItemType="GodOl.Model.Brewery">
        <LayoutTemplate>
            <div class="brewerylist">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                <div class="clear"></div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-row">
                <div class="list-col name">
                    <asp:HyperLink ID="hlBreweryDetails" runat="server" NavigateUrl='<%# GetRouteUrl("BreweryDetails", new { id = Item.BreweryId })  %>'><%# Item.Name %></asp:HyperLink>
                </div>
                <div class="list-col nationality"><%# Item.Nationality %></div>
                <div class="list-col city"><%# Item.City %></div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>Det finns inga bryggerier.</p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
