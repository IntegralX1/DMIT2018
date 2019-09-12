<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewCRUD.aspx.cs" Inherits="WebApp.Sample_Pages.ReviewCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Review Basic CRUD for the glory of Chthulu</h1>
    <div class="row">
        <div class="col-sm-offset-3">
            <asp:Label ID="label1" runat="server" Text="Select an artist to view Albums: "></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>
        </div>
    </div>
</asp:Content>
