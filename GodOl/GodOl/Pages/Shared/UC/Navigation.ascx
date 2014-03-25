<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="GodOl.Pages.Shared.UC.Navigation" %>
<ul>
    <li>
        <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=BeerList %>'>Öl-Listan</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=BeerCreate %>'>Lägg till öl</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=BreweryList %>'>Bryggerier</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=BreweryCreate %>'>Lägg till bryggeri</asp:HyperLink>
    </li>
</ul>
