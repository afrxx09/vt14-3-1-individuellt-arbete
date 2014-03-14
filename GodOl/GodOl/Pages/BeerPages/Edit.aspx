<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="GodOl.Pages.BeerPages.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
    Redigera: <asp:Literal ID="litBeerName" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" DataKeyNames="BeerId" ItemType="GodOl.Model.Beer" SelectMethod="FormView1_GetItem" UpdateMethod="FormView1_UpdateItem">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Name %>' />
            <asp:Button ID="Button1" runat="server" Text="Spara" />
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
