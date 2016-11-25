using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace SharePointProject3.Layouts.SharePointProject3
{
    public partial class ApplicationPage1 : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SPSite oSiteCollection = SPContext.Current.Site;

            //btnCallCSFunction.Click += new EventHandler(this.BreakInheritance_Click);

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1Message();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button3Message();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button4Message();

        }

        protected void BreakInheritance_Click(object sender, EventArgs e)
        {
            BreakInheritance();
            
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "closePage", "SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.ok, '');", true);
        
        }

        protected void SetInheritance_Click(object sender, EventArgs e)
        {
            SetInheritance();

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "closePage", "SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.ok, '');", true);

        }


        private void Button1Message()
        {
            //string listtitle = SPContext.Current.List.Title;



            try
            {

                //string userLoginName = SPContext.Current.Web.CurrentUser.LoginName;
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + userLoginName + "');", true);
                string itemID = (Request.QueryString["LibraryName"]);
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + itemID + "');", true);
                SPWeb web = this.Site.OpenWeb();
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + itemID + " is GUID of List we want, located in web with title "+ web.Title + "');", true);
                Guid ListGUID = new Guid(itemID);
                SPList list = web.Lists[ListGUID];

                Label2.Text = "Ausgewählte Liste ist \"" + list.Title + "\". (AllowEveryoneViewItems: \"" + (list.AllowEveryoneViewItems) + "\")";
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Ausgewählte Liste ist " + list.Title + ".\\r\\n(AllowEveryoneViewItems: " + (list.AllowEveryoneViewItems) + ")');", true);

            }
            catch (Exception)
                            {
                                // An error with the list. Move onto the next list.
                            }
     
            
        }

        private void Button3Message()
        {
            //string listtitle = SPContext.Current.List.Title;



            try
            {
                string itemID = (Request.QueryString["LibraryName"]);
                SPWeb web = this.Site.OpenWeb();
                Guid ListGUID = new Guid(itemID);
                SPList list = web.Lists[ListGUID];
                Label2.Text = "HasUniqueRoleAssignments: " + (list.HasUniqueRoleAssignments);
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('HasUniqueRoleAssignments: " + (list.HasUniqueRoleAssignments) + "');", true);
            }
            catch (Exception)
            {
                // An error with the list. Move onto the next list.
            }


        }



        private void Button4Message()
        {
            //string listtitle = SPContext.Current.List.Title;



            try
            {
                string itemID = (Request.QueryString["LibraryName"]);
                SPWeb web = this.Site.OpenWeb();
                Guid ListGUID = new Guid(itemID);
                SPList list = web.Lists[ListGUID];
                Label2.Text = "AnonymousPermMask64: " + list.AnonymousPermMask64.ToString();
                
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('AnonymousPermMask64:\\r\\n\\r\\n" + list.AnonymousPermMask64 + "');", true);
            }
            catch (Exception)
            {
                // An error with the list. Move onto the next list.
            }


        }

        private void BreakInheritance()
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('breaking PermMask64 Inheritance');", true);

            try
            {
                string itemID = (Request.QueryString["LibraryName"]);
                Guid ListGUID = new Guid(itemID);
                SPWeb web = this.Site.OpenWeb();
                SPList list = web.Lists[ListGUID];

                if (list != null)
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('result');", true);
                {
                    //LogInfo("found list " + list.Title);
                    //LogInfo("setting new AnonymousPermMask64 for list " + list.ParentWebUrl + "/" + list.Title + " with the following permissions: OpenItems, ViewPages, ViewVersions, Open, UseClientIntegration, ViewListItems, ViewFormPages");
                    list.BreakRoleInheritance(true, false);
                    list.AllowEveryoneViewItems = true;
                    list.AnonymousPermMask64 = SPBasePermissions.ViewPages |
                                           SPBasePermissions.OpenItems | SPBasePermissions.ViewVersions |
                                           SPBasePermissions.Open | SPBasePermissions.UseClientIntegration |
                                           SPBasePermissions.ViewFormPages | SPBasePermissions.ViewListItems;

                    list.Update();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Setzen der AnonymousPermMask64 für anonymen Zugriff auf Liste " + list.Title + " erfolgreich.\\r\\n\\r\\nDie Berechtigungsvererbung wurde aufgehoben.');", true);
                    //return list.Title;
                }
            }
            catch (Exception)
            {
                //return "list not found"; 

            }
        }




        private void SetInheritance()
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('breaking PermMask64 Inheritance');", true);

            try
            {
                string itemID = (Request.QueryString["LibraryName"]);
                Guid ListGUID = new Guid(itemID);
                SPWeb web = this.Site.OpenWeb();
                SPList list = web.Lists[ListGUID];

                if (list != null)
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('result');", true);
                {
                    //LogInfo("found list " + list.Title);
                    //LogInfo("setting new AnonymousPermMask64 for list " + list.ParentWebUrl + "/" + list.Title + " with the following permissions: OpenItems, ViewPages, ViewVersions, Open, UseClientIntegration, ViewListItems, ViewFormPages");
                    
                    list.AllowEveryoneViewItems = false;
                    list.AnonymousPermMask64 = SPBasePermissions.EmptyMask;
                    list.ResetRoleInheritance();
                    list.Update();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Entfernen der AnonymousPermMask64 für anonymen Zugriff auf Liste " + list.Title + " erfolgreich.\\r\\n\\r\\nDie Vererbung der Berechtigungen wurde aktiviert.');", true);
                    //return list.Title;
                }
            }
            catch (Exception)
            {
                //return "list not found"; 

            }
        }
    }
}
