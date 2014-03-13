<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="BreweryList.aspx.cs" Inherits="GodOl.Pages.BreweryPages.BreweryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ListView ID="lwBreweries" runat="server" SelectMethod="lwBreweries_GetData" DataKeyNames="BreweryId" ItemType="GodOl.Model.Brewery">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-row">
                <div class="list-col">
                    <asp:HyperLink ID="hlBreweryDetails" runat="server" NavigateUrl='<%# GetRouteUrl("BreweryDetails", new { id = Item.BreweryId })  %>'><%# Item.Name %></asp:HyperLink>
                </div>
                <div class="list-col"><%# Item.Nationality %></div>
                <div class="list-col"><%# Item.City %></div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>

        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
