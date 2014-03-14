<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GodOl.Pages.BeerPages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:FormView ID="fwBeerDetails" runat="server" ItemType="GodOl.Model.Beer" DataKeyNames="BeerId" SelectMethod="fwBeerDetails_GetItem" OnDataBound="fwBeerDetails_DataBound" on>
        <ItemTemplate>
            <div>
                <p>Namn: <%# Item.Name %></p>
                <p>
                    Typ: <asp:Label ID="lblBeerType" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    Bryggeri: <asp:HyperLink ID="hlBrewery" runat="server" />
                </p>
                <p>Produktionsstart: <%# Item.StartYear %></p>
                <p>Alkohol(ABV): <%# Item.ABV %></p>
                <p>Bitterhet(IBU): <%# Item.IBU %></p>
                <p>Färg(EBC): <%# Item.EBC %></p>
            </div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("BeerEdit", new { id = Item.BeerId })  %>'>Redigera</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("BeerDelete", new { id = Item.BeerId })  %>'>Ta bort</asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
