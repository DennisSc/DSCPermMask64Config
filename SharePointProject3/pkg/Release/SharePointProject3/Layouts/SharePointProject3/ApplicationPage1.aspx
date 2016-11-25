<%@ Assembly Name="SharePointProject3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cc756c518c8f2a40" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationPage1.aspx.cs" Inherits="SharePointProject3.Layouts.SharePointProject3.ApplicationPage1" DynamicMasterPageFile="~masterurl/default.master" %>
 
<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
 
</asp:Content>
 
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
 
     <Sharepoint:ScriptLink ID="ScriptLink1" Name="sp.ui.dialog.js" LoadAfterUI="true" Localizable="false" runat="server"></Sharepoint:ScriptLink>
     <script type="text/javascript" >
 
         function onCancel(sender, args) {
                //find button
                //var objButton = document.getElementById("btnCallCSFunction");
        
                //Call server side button click
                //objButton.click(); //It will call server side event btnCallCSFunction_Click
    
                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, '');
            }
 
            function onOk(sender, args) {
                

                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('txtCategory').value);
            }

            function returnCurrentList(sender, args) {
                alert('test');
            }
    </script>



    <form id="aspnetForm" action="">
        <div style="display:none">




</div>
 
     <p>
         <asp:Button ID="Button1" runat="server" Text="Aktive Liste prüfen" onclick="Button1_Click" Visible="True" />&nbsp;&nbsp;
         <asp:Button ID="Button3" runat="server" Text="Vererbung anzeigen" onclick="Button3_Click" Visible="True" />&nbsp;&nbsp;
         <asp:Button ID="Button4" runat="server" Text="AnonymousPermMask64 anzeigen" onclick="Button4_Click" Visible="True" />
         <br />
         <br />
    </p>
        <p>
            <asp:Label ID="Label2" runat="server" Visible="true" Text="..."></asp:Label>
            <br />
            <br />
        </p>
        
            <p>
                <asp:button ID="btnCallCSFunction" runat="server" Text="AnonymousPermMask64 setzen (Vererbung aufheben)" onclick="BreakInheritance_Click" Visible="True" />
                <br /><br />
                <asp:button ID="Button2" runat="server" Text="AnonymousPermMask64 löschen (Vererbung aktivieren)" onclick="SetInheritance_Click" Visible="True" />
            </p>

       
            
        <p>
            <br /><br /><button id="Cancel" value="Cancel" onclick="onCancel();">Schließen</button>&nbsp;&nbsp;
            

        </p>
    </form>
</asp:Content>
 
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
DSC PermMask64 Config
</asp:Content>
 
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
DSC PermMask64 Config
</asp:Content>
