<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBeer.ascx.cs" Inherits="GodOl.Pages.Shared.UC.ucBeer" %>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
<asp:FormView ID="fwBeer" runat="server" ItemType="GodOl.Model.Beer" DataKeyNames="BeerId" SelectMethod="fwBeer_GetItem" InsertMethod="fwBeer_InsertItem" UpdateMethod="fwBeer_UpdateItem">
    <ItemTemplate>

    </ItemTemplate>
    <InsertItemTemplate>

    </InsertItemTemplate>
</asp:FormView>
<asp:ListView ID="lwBeerUserControl" runat="server" ItemType="GodOl.Model.Beer" SelectMethod="lwBeerUserControl_GetData" DataKeyNames="BeerId" InsertMethod="lwBeerUserControl_InsertItem" DeleteMethod="lwBeerUserControl_DeleteItem">
    <ItemTemplate>
        <%# Item.Name %>
        <div>
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("BeerEdit", new { id = Item.BeerId })  %>'>Redigera</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("BeerDelete", new { id = Item.BeerId })  %>'>Ta bort</asp:HyperLink>
        </div>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtEditBeerName" runat="server" Text='<%# BindItem.Name %>'/>
        <div>
            <asp:LinkButton runat="server">Spara</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("BeerList", null)  %>'>Avbryt</asp:HyperLink>
        </div>
    </EditItemTemplate>
    <InsertItemTemplate>
        <div>
            <asp:LinkButton runat="server">Spara</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("BeerList", null)  %>'>Avbryt</asp:HyperLink>
        </div>
    </InsertItemTemplate>
</asp:ListView>