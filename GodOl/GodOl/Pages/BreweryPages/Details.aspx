<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GodOl.Pages.BreweryPages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:Panel ID="pnlSuccess" CssClass="success-panel" runat="server" Visible="false">
        <asp:Label ID="lblSuccess" CssClass="success-message" runat="server" Text="" />
    </asp:Panel>
    <asp:FormView ID="fwBreweryDetails" runat="server" RenderOuterTable="false" DefaultMode="ReadOnly" ItemType="GodOl.Model.Brewery" DataKeyNames="BreweryId" SelectMethod="fwBreweryDetails_GetItem">
        <ItemTemplate>
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
                    Address
                </div>
                <div class="details-value details-col">
                    <%# Item.Adress %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Address2
                </div>
                <div class="details-value details-col">
                    <%# Item.Adress2 %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Stat / Provins
                </div>
                <div class="details-value details-col">
                    <%# Item.State %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Postnummer
                </div>
                <div class="details-value details-col">
                    <%# Item.Zip %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Stad
                </div>
                <div class="details-value details-col">
                    <%# Item.City %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Nationalitet
                </div>
                <div class="details-value details-col">
                    <%# Item.Nationality %>
                </div>
            </div>
            <div class="details-row">
                <div class="details-label details-col">
                    Etableningsår
                </div>
                <div class="details-value details-col">
                    <%# Item.Established%>
                </div>
            </div>
            <div class="clear"></div>
            <div class="form-button-container">
                <asp:HyperLink ID="HyperLink1" CssClass="form-button form-submit"  runat="server" NavigateUrl='<%# GetRouteUrl("BreweryEdit", new { id = Item.BreweryId })  %>'>Redigera</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" CssClass="form-button form-cancel"  runat="server" NavigateUrl='<%# GetRouteUrl("BreweryDelete", new { id = Item.BreweryId })  %>'>Ta bort</asp:HyperLink>
            </div>
            
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
