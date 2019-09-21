<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewCRUDODS.aspx.cs" Inherits="WebApp.UserControls.ListViewCRUDODS" %>

<%@ Register Src="~/UserControls/messageUserControl.ascx" TagPrefix="uc1" TagName="messageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>List View ODS CRUD</h1>
    <blockquote class="alert alert-info">
       This page will demonstrate a CRUD process using the List View control and only ODS datasources.
    </blockquote>

    <uc1:messageUserControl runat="server" ID="messageUserControl" />
    <br />
    <asp:ListView ID="AlbumList" runat="server" DataSourceID="AlbumListODS" InsertItemPosition="LastItem" DataKeyNames="AlbumId">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Remove" ID="DeleteButton" 
                        OnClientClick="return confirm('Are you sure you want to decend into madness?')"/>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" 
                        width="30px" Enabled="false" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" Width="400px"/></td>
                <td>
                <asp:DropDownList ID="ArtistList" runat="server" 
                    DataSourceID="ArtistListODS" 
                    DataTextField="Name" 
                    DataValueField="ArtistId"
                    SelectedValue='<%# Eval("ArtistId") %>'
                    Enabled="false" Width="300px">
                </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseYear") %>' runat="server" ID="ReleaseYearLabel" Width="50px"/></td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <asp:RequiredFieldValidator ID="RequiredTitleTextBoxE" 
                runat="server" 
                ErrorMessage="Title is required" Display="None"
                ControlToValidate="TitleTextBoxE"
                ValidationGroup="EGroup">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
                ID="RegExTitleTextBoxE" 
                runat="server" 
                ErrorMessage="Title is limited to 160 characters" Display="None"
                ControlToValidate="TitleTextBoxE" ValidationGroup="EGroup"
                ValidationExpression="^.{1,160}$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredReleaseYearTextBoxE" 
                runat="server" 
                ErrorMessage="Year is required" Display="None"
                ControlToValidate="ReleaseYearTextBoxE"
                ValidationGroup="EGroup">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeReleaseYearTextBoxE" 
                runat="server" 
                ErrorMessage="Year must be between 1950 and today"
                ValidationGroup="EGroup"
                ControlToValidate="ReleaseYearTextBoxE"
                MinimumValue="1950" MaximumValue='<%# DateTime.Today.Year %>'>
            </asp:RangeValidator>
            <tr style="background-color: #008A8C; color: #000000;">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdTextBox" width="30px" Enabled="false"/></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBoxE" Width="400px"/></td>
               <td>
                <asp:DropDownList ID="ArtistList" runat="server" 
                    DataSourceID="ArtistListODS" 
                    DataTextField="Name" 
                    DataValueField="ArtistId"
                    SelectedValue='<%# Bind("ArtistId") %>'
                    Width="300px">
                </asp:DropDownList>
               </td>
                <td>
                    <asp:TextBox Text='<%# Bind("ReleaseYear") %>' runat="server" ID="ReleaseYearTextBoxE" Width="50px"/></td>
                <td>
                    <asp:TextBox Text='<%# Bind("ReleaseLabel") %>' runat="server" ID="ReleaseLabelTextBox" /></td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <asp:RequiredFieldValidator ID="RequiredTitleTextBoxI" 
                runat="server" 
                ErrorMessage="Title is required" Display="None"
                ControlToValidate="TitleTextBoxI"
                ValidationGroup ="IGroup">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
                ID="RegExTitleTextBoxI" 
                runat="server" 
                ErrorMessage="Title is limited to 160 characters" Display="None"
                ControlToValidate="TitleTextBoxI" ValidationGroup="IGroup"
                ValidationExpression="^.{1,160}$">
            </asp:RegularExpressionValidator>
            <asp:RangeValidator ID="RangeReleaseYearTextBoxI" 
                runat="server" 
                ErrorMessage="Year must be between 1950 and today"
                ValidationGroup="IGroup"
                ControlToValidate="ReleaseYearTextBoxI"
                MinimumValue="1950" MaximumValue='<%# DateTime.Today.Year %>'>
            </asp:RangeValidator>
            <asp:RegularExpressionValidator 
                ID="RegExReleaseLabelTextBoxI" 
                runat="server" 
                ErrorMessage="Label is limited to 50 characters" Display="None"
                ControlToValidate="ReleaseLabelTextBoxI" ValidationGroup="IGroup"
                ValidationExpression="^.{0,50}$">
            </asp:RegularExpressionValidator>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdTextBox" width="30px" Enabled="false"/></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBoxI" Width="400px"/></td>
                <td>
               <asp:DropDownList ID="ArtistList" runat="server" 
                    DataSourceID="ArtistListODS" 
                    DataTextField="Name" 
                    DataValueField="ArtistId"
                    SelectedValue='<%# Bind("ArtistId") %>'
                    Width="300px">
                </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("ReleaseYear") %>' runat="server" ID="ReleaseYearTextBoxI" Width="50px"/></td>
                <td>
                    <asp:TextBox Text='<%# Bind("ReleaseLabel") %>' runat="server" ID="ReleaseLabelTextBoxI" /></td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Remove" ID="DeleteButton" 
                        OnClientClick="return confirm('Are you sure you want to decend into madness?')"/>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" width="30px" Enabled="false"/></td>
                <td>
                    <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                <td>
                <asp:DropDownList ID="ArtistList" runat="server" 
                    DataSourceID="ArtistListODS" 
                    DataTextField="Name" 
                    DataValueField="ArtistId"
                    SelectedValue='<%# Eval("ArtistId") %>'
                    Enabled="false" Width="300px">
                </asp:DropDownList>
                    </td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseYear") %>' runat="server" ID="ReleaseYearLabel" Width="50px"/></td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; 
                        border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">Id</th>
                                <th runat="server">Title</th>
                                <th runat="server">Artist</th>
                                <th runat="server">Year</th>
                                <th runat="server">Label</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; 
                    background-color: #CCCCCC; 
                    font-family: Verdana, Arial, Helvetica, sans-serif; 
                    color: #000000;">
                        <asp:DataPager runat="server" ID="DataPager1">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Remove" ID="DeleteButton" 
                        OnClientClick="return confirm('Are you sure you want to decend into madness?')"/>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" width="30px" Enabled="false"/></td>
                <td>
                    <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" Width="400px"/></td>
                <td>
                <asp:DropDownList ID="ArtistList" runat="server" 
                    DataSourceID="ArtistListODS" 
                    DataTextField="Name" 
                    DataValueField="ArtistId"
                    SelectedValue='<%# Eval("ArtistId") %>'
                    Enabled="false" Width="300px">
                </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseYear") %>' runat="server" ID="ReleaseYearLabel" Width="50px"/></td>
                <td>
                    <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="AlbumListODS" runat="server" 
        DataObjectTypeName="ChinookSystem.Data.Entities.Album" 
        DeleteMethod="Album_Delete"
        InsertMethod="Album_Add" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Album_List" 
        TypeName="ChinookSystem.BLL.AlbumController" 
        UpdateMethod="Album_Update"
        OnDeleted="CheckForException"
        OnInserted="CheckForException"
        OnUpdated="CheckForException"
        OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Artists_List" 
        TypeName="ChinookSystem.BLL.ArtistController"
        OnSelected="CheckForException">

    </asp:ObjectDataSource>
</asp:Content>
