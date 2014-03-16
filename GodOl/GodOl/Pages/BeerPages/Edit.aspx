<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="GodOl.Pages.BeerPages.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Redigera:
    <asp:Literal ID="litBeerName" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" DataKeyNames="BeerId" ItemType="GodOl.Model.Beer" SelectMethod="FormView1_GetItem" UpdateMethod="FormView1_UpdateItem">
        <EditItemTemplate>
            <div>
                <div>Namn</div>
                <div>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# BindItem.Name %>' /></div>
            </div>
            <div>
                <div>Typ</div>
                <div>
                    <asp:DropDownList ID="selBeerType" runat="server" SelectMethod="selBeerType_GetData" ItemType="GodOl.Model.BeerType" DataTextField="BType" DataValueField="BeerTypeId" SelectedValue='<%# Item.BeerTypeId %>'>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <div>Bryggeri</div>
                <div>
                    <asp:DropDownList ID="selBrewery" runat="server" SelectMethod="selBrewery_GetData" ItemType="GodOl.Model.Brewery" DataTextField="Name" DataValueField="BreweryId" SelectedValue='<%# Item.BreweryId %>'>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <div>Produktionsstart</div>
                <div><asp:TextBox ID="txtStartYear" runat="server" Text='<%# BindItem.StartYear %>' /></div>
            </div>
            <div>
                <div>Akoholhalt(ABV)</div>
                <div><asp:TextBox ID="txtABV" runat="server" Text='<%# BindItem.ABV %>' /></div>
            </div>
            <div>
                <div>Bitterhet(IBU)</div>
                <div><asp:TextBox ID="txtIBU" runat="server" Text='<%# BindItem.IBU %>' /></div>
            </div>
            <div>
                <div>EBC</div>
                <div><asp:TextBox ID="txtEBC" runat="server" Text='<%# BindItem.EBC %>' /></div>
            </div>
            <asp:Button ID="Button1" CommandName="Update" runat="server" Text="Spara" />
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
