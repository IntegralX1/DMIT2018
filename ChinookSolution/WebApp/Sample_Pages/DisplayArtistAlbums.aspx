<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayArtistAlbums.aspx.cs" Inherits="WebApp.Sample_Pages.DisplayArtistAlbums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ArtistAlbumsList" runat="server"></asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Enter your artist name" ></asp:Label>
    <asp:TextBox ID="ArtistName" runat="server" placeholder="artist name"></asp:TextBox>
    <asp:Button ID="Fetch" runat="server" Text="Fetch" CssClass="btn btn-primary" /><br/><br/>
    <asp:ObjectDataSource ID="ArtistAlbumsListODS" runat="server"></asp:ObjectDataSource>

</asp:Content>
