<%@ Page Title="Repeater Nested Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="RepeaterDisplay.aspx.cs" Inherits="WebApp.Sample_Pages.RepeaterDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Displaying a Nested LINQ Query in a Repeater</h1>
    <%-- To ease working with the properties in your class on this control use the ItemType attribute 
        and assign the class name of your data definition
    HeaderTemplate is top of list
    FooterTemplate is bottom of list
    ItemTemplate occurs once per DTO record
    AlternatingItem Template (every other record)--%>
    <asp:Repeater ID="AlbumTracksList" 
        runat="server" 
        DataSourceID="AlbumTracksListODS"
        ItemType="ChinookSystem.Data.DTOs.AlbumDTO">
        <HeaderTemplate>
            <h3>Albums and Tracks</h3>
        </HeaderTemplate>
        <ItemTemplate> <%--Represents a single record from the DTO--%>
            <h5><strong>Album: <%# Item.Albumtitle %></strong></h5> <%--The album name comes from the ItemType attribute--%>
            <p><strong>Artist: <%# Item.AlbumArtist %></strong>
            # of Tracks: <%# Item.TrackCount %>
            Play Time: <%# Item.PlayTime %></p>
            <asp:GridView ID="TrackList" runat="server" AutoGenerateColumns="False" DataSource="<%# Item.AlbumTracks %>"
                CssClass="table" GridLines="Horizontal" BorderStyle="None">              
            </asp:GridView>
        </ItemTemplate>
        <FooterTemplate>
            <p>&copy; DMIT2018 NAIT Course all rights reserved</p>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="AlbumTracksListODS" 
        runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Album_AlbumAndTracks" 
        TypeName="ChinookSystem.BLL.AlbumController">
    </asp:ObjectDataSource>
</asp:Content>
