<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayArtistAlbums.aspx.cs" Inherits="WebApp.SamplePages.DisplayArtistAlbums" %>

<%@ Register Src="~/UserControls/messageUserControl.ascx" TagPrefix="uc1" TagName="messageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <uc1:messageUserControl runat="server" id="messageUserControl" />
    <asp:Label ID="Label1" runat="server" Text="Enter your artist name (or partial search)" ></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="ArtistName1" runat="server" placeholder="artist name"></asp:TextBox>&nbsp;&nbsp;
    <asp:Button ID="Fetch1" runat="server" Text="Fetch" CssClass="btn btn-primary" />&nbsp;&nbsp;<br/><br/>
    <asp:GridView ID="ArtistAlbumsList" 
        runat="server" 
    <asp:Label ID="Label2" runat="server" Text="Enter your artist name (or partof)"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="ArtistName2" runat="server"
         placeholder="artist name"></asp:TextBox>
    &nbsp;&nbsp;
    <asp:Button ID="Fetch2" runat="server" Text="Fetch"
         CssClass="btn btn-primary"/><br/><br/>
    <asp:GridView ID="ArtistAlbumsList" runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="ArtistAlbumsListODS" 
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="Artist" HeaderText="Artist" SortExpression="Artist"></asp:BoundField>
            <asp:BoundField DataField="ArtistName" HeaderText="ArtistName" SortExpression="ArtistName"></asp:BoundField>
            <asp:BoundField DataField="RYear" HeaderText="RYear" SortExpression="RYear"></asp:BoundField>
            <asp:BoundField DataField="RLabel" HeaderText="RLabel" SortExpression="RLabel"></asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            No data available for artist name.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ArtistAlbumsListODS" 
        runat="server" 
    <asp:ObjectDataSource ID="ArtistAlbumsListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Album_AlbumsOfArtist" 
        TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ArtistName" 
                PropertyName="Text" 
                DefaultValue="zvbgfdv" 
                Name="artistname" 
                Type="String">
            </asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
                DefaultValue="zxcvfd" 
                Name="artistname" 
                Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
