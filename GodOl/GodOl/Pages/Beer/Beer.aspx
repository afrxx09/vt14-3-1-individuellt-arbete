<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Beer.aspx.cs" Inherits="GodOl.Pages.Beer.Beer" %>


<asp:Content ID="cHeadTitle" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Öl-lista
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cph1" runat="server">
    <asp:Panel ID="pBeerSuccess" runat="server" Visible="false" CssClass="success">
        <asp:Label ID="lblBeerSuccess" runat="server" />
    </asp:Panel>
    <asp:ValidationSummary ID="vsBeer" runat="server" />
    <asp:ListView ID="lwBeer" runat="server" ItemType="GodOl.Model.Beer" SelectMethod="lwBeer_GetData" DataKeyNames="BeerId">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                    <asp:HyperLink runat="server"><%# Item.Name %></asp:HyperLink>
                </dt>
                <dd>
                    Tillverkningsstart: <asp:Label ID="Label4" runat="server"><%# Item.StartYear %></asp:Label>
                </dd>
                <dd>
                    Alkohol(ABV): <asp:Label ID="Label1" runat="server"><%# Item.ABV %></asp:Label>
                </dd>
                <dd>
                    Bitter(IBU): <asp:Label ID="Label2" runat="server"><%# Item.IBU %></asp:Label>
                </dd>
                <dd>
                    Färg(EBC): <asp:Label ID="Label3" runat="server"><%# Item.EBC %></asp:Label>
                </dd>
            </dl>
            
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>Inga poster hittades...</p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
