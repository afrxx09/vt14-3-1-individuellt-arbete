<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="BeerList.aspx.cs" Inherits="GodOl.Pages.BeerPages.BeerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Öl
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ListView ID="ListView1" runat="server" SelectMethod="ListView1_GetData" DataKeyNames="BeerId" ItemType="GodOl.Model.Beer" OnItemDataBound="ListView1_ItemDataBound">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-row">
                <div class="list-col">
                    <asp:HyperLink ID="hlBeerDetails" runat="server" NavigateUrl='<%# GetRouteUrl("BeerDetails", new { id = Item.BeerId })  %>'><%# Item.Name %></asp:HyperLink>
                </div>
                <div class="list-col">
                    <asp:Label ID="lblBeerType" runat="server" />
                </div>
                <div class="list-col">
                    <asp:HyperLink ID="hlBrewery" runat="server" />
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            Finns ingen öl...
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
