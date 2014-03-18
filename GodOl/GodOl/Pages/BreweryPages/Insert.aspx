<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="GodOl.Pages.BreweryPages.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="error-messages" runat="server" />
    <asp:FormView ID="fwInsertBrewery" runat="server" DataKeyNames="BreweryId" ItemType="GodOl.Model.Brewery" DefaultMode="Insert" InsertMethod="fwInsertBrewery_InsertItem">
        <InsertItemTemplate>
            <div class="form-row">
                <div class="form-label">
                    <label>Namn <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtBreweryName" runat="server" Text='<%# BindItem.Name %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Måste ange Namn." Display="Dynamic" ControlToValidate="txtBreweryName" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Address <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtAdress" runat="server" Text='<%# BindItem.Adress %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAdress" ErrorMessage="Måste ange address." Display="Dynamic" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Address2</label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtAdress2" runat="server" Text='<%# BindItem.Adress2 %>' />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Stat / Province</label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtState" runat="server" Text='<%# BindItem.State %>' />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Postnummer <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtZip" runat="server" Text='<%# BindItem.Zip %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtZip" ErrorMessage="Måste ange postnummer." Display="Dynamic" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Stad <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtCity" runat="server" Text='<%# BindItem.City %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity" ErrorMessage="Måste ange address." Display="Dynamic" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Nationalitet <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:DropDownList ID="selNationality" runat="server" SelectedValue='<%# BindItem.Nationality%>'>
                        <asp:ListItem Text="Danmark" Value="DK" />
                        <asp:ListItem Text="Storbritannien" Value="UK" />
                        <asp:ListItem Text="Tyskland" Value="DE" />
                        <asp:ListItem Text="USA" Value="US" />
                        <asp:ListItem Text="Sverige" Value="SE" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="selNationality" ErrorMessage="Måste välja ett land." Display="Dynamic" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-label">
                    <label>Etableringsår <span class="required">*</span></label>
                </div>
                <div class="form-input">
                    <asp:TextBox ID="txtEstablished" runat="server" Text='<%# BindItem.Established %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEstablished" ErrorMessage="Måste ange postnummer." Display="Dynamic" Text="*" />
                </div>
            </div>
            <div class="form-row">
                <asp:Button ID="Button1" CssClass="form-button form-submit" runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink ID="hlCancelDelete" CssClass="form-button form-cancel" runat="server">Avbryt</asp:HyperLink>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
