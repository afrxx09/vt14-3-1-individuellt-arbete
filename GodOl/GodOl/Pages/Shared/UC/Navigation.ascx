<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="GodOl.Pages.Shared.UC.Navigation" %>
<ul>
    <li>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/beers">Öl-Listan</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/beer/new">Lägg till öl</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/breweries">Bryggerier</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/brewery/new">Lägg till bryggeri</asp:HyperLink>
    </li>
</ul>
