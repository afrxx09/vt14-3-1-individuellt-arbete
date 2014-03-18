<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="GodOl.Pages.BeerPages.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="error-messages" runat="server" />
    <asp:FormView ID="fwInsertBeer" runat="server" DataKeyNames="BeerId" ItemType="GodOl.Model.Beer" DefaultMode="Insert" InsertMethod="fwInsertBeer_InsertItem">
        <InsertItemTemplate>
            <div class="form-row">
                <div class="form-label">
                    <label>Namn <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtBeerName" runat="server" Text='<%# BindItem.Name %>' />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Måste ange Namn." Display="Dynamic" ControlToValidate="txtBeerName" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Typ <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:DropDownList ID="selBeerType" runat="server" SelectMethod="selBeerType_GetData" ItemType="GodOl.Model.BeerType" DataTextField="BType" DataValueField="BeerTypeId" SelectedValue='<%# BindItem.BeerTypeId %>' />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Bryggeri <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:DropDownList ID="selBrewery" runat="server" SelectMethod="selBrewery_GetData" ItemType="GodOl.Model.Brewery" DataTextField="Name" DataValueField="BreweryId" SelectedValue='<%# BindItem.BreweryId %>' />
                </div>
            </div>
            <div>
                <div class="form-label">
                    <label>
                        Produktionsstart
                    </label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtStartYear" runat="server" Text='<%# BindItem.StartYear %>' />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Akoholhalt(ABV) <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtABV" runat="server" Text='<%# BindItem.ABV %>' />
                    <asp:RequiredFieldValidator ControlToValidate="txtABV" runat="server" ErrorMessage="Måste ange ABV" />
                    <asp:RangeValidator runat="server" ErrorMessage="Endast värden mellan 0 och 100 tillåtet." Display="Dynamic" ControlToValidate="txtABV" MaximumValue="100" MinimumValue="0" Type="Double" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Bitterhet(IBU) <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtIBU" runat="server" Text='<%# BindItem.IBU %>' />
                    <asp:RequiredFieldValidator ControlToValidate="txtIBU" runat="server" ErrorMessage="Måste ange IBU" />
                    <asp:RangeValidator runat="server" ErrorMessage="Endast värden mellan 0 och 100 tillåtet." Display="Dynamic" ControlToValidate="txtIBU" MaximumValue="100" MinimumValue="0" Type="Double" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>EBC <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtEBC" runat="server" Text='<%# BindItem.EBC %>' />
                    <asp:RequiredFieldValidator ControlToValidate="txtEBC" runat="server" ErrorMessage="Måste ange EBC" />
                    <asp:RangeValidator runat="server" ErrorMessage="Endast värden mellan 0 och 80 tillåtet." Display="Dynamic" ControlToValidate="txtEBC" MaximumValue="80" MinimumValue="0" Type="Double" Text="*" />
                </div>
            </div>
            <div class="clear"></div>
            <div class="form-button-container">
                <asp:Button ID="Button1" CssClass="form-button form-submit" runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink ID="hlCancelDelete" CssClass="form-button form-cancel"  runat="server">Avbryt</asp:HyperLink>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
