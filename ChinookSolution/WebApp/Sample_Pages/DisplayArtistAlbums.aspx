<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayArtistAlbums.aspx.cs" Inherits="WebApp.Sample_Pages.DisplayArtistAlbums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ArtistAlbumsList" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="ArtistAlbumsListODS" runat="server"></asp:ObjectDataSource>
</asp:Content>
