<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_ucBeerType.ascx.cs" Inherits="GodOl.Pages.Beer._ucBeerType" %>

<asp:ListView ID="lwBeerType" runat="server" ItemType="GodOl.Model.BeerType" DataKeyNames="BeerTypeId"" SelectMethod="lwBeerType_GetData">
    <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
    </LayoutTemplate>
    <ItemTemplate>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="ReadOnlyView" runat="server">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </asp:View>
            <asp:View ID="SelectBoxView" runat="server">

            </asp:View>
        </asp:MultiView>
    </ItemTemplate>
</asp:ListView>
