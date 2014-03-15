<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="GodOl.Pages.BeerPages.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:FormView ID="fwInsertBeer" runat="server" DataKeyNames="BeerId" ItemType="GodOl.Model.Beer" DefaultMode="Insert" InsertMethod="fwInsertBeer_InsertItem">
        <InsertItemTemplate>
            <div>
                <label>Namn</label>
                <asp:TextBox ID="txtBeerName" runat="server" Text='<%# BindItem.Name %>' />
            </div>
            <div>
                <label>Typ</label>
                <asp:DropDownList ID="selBeerType" runat="server" ItemType="GodOl.Model.BeerType" SelectMethod="selBeerType_GetData" />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
