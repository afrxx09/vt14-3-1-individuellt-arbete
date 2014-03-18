<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GodOl.Pages.BeerPages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:Panel ID="pnlSuccess" CssClass="success-panel" runat="server" Visible="false">
        <asp:Label ID="lblSuccess" CssClass="success-message" runat="server" Text="" />
    </asp:Panel>
    <asp:FormView ID="fwBeerDetails" RenderOuterTable="false" DefaultMode="ReadOnly" runat="server" ItemType="GodOl.Model.Beer" DataKeyNames="BeerId" SelectMethod="fwBeerDetails_GetItem" OnDataBound="fwBeerDetails_DataBound">
        <ItemTemplate>
            <div class="beer-details">
                <div class="details-row">
                    <div class="details-label details-col">
                        Namn
                    </div>
                    <div class="details-value details-col">
                        <%# Item.Name %>
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Typ
                    </div>
                    <div class="details-value details-col">
                        <asp:Label ID="lblBeerType" runat="server" />
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Bryggeri
                    </div>
                    <div class="details-value details-col">
                        <asp:HyperLink ID="hlBrewery" runat="server" />
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Produktionsstart
                    </div>
                    <div class="details-value details-col">
                        <%# Item.StartYear %>
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Alkohol(ABV)
                    </div>
                    <div class="details-value details-col">
                        <%# Item.ABV %>
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Bitterhet(IBU)
                    </div>
                    <div class="details-value details-col">
                        <%# Item.IBU %>
                    </div>
                </div>
                <div class="details-row">
                    <div class="details-label details-col">
                        Färg(EBC)
                    </div>
                    <div class="details-value details-col">
                        <%# Item.EBC %>
                    </div>
                </div>
            </div>
            <div class="clear"></div>
            <div class="form-button-container">
                <asp:HyperLink ID="HyperLink1" CssClass="form-button form-submit"  runat="server" NavigateUrl='<%# GetRouteUrl("BeerEdit", new { id = Item.BeerId })  %>'>Redigera</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" CssClass="form-button form-cancel"  runat="server" NavigateUrl='<%# GetRouteUrl("BeerDelete", new { id = Item.BeerId })  %>'>Ta bort</asp:HyperLink>
            </div>
            
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
