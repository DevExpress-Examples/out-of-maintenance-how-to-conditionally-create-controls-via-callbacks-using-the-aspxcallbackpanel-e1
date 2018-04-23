using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxCallbackPanel;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using System.Xml;
using System.Threading;
using DevExpress.Web.ASPxGridView;

// http://stackoverflow.com/questions/1110625/how-do-i-detect-if-a-request-is-a-callback-in-the-global-asax

public partial class Main : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        ASPxEdit.RegisterBaseScript(Page);
    }

    protected void cbpTop_Init(object sender, EventArgs e)
    {
        ASPxCallbackPanel cbp = sender as ASPxCallbackPanel;

        if ((hf.Contains("all") && Convert.ToBoolean(hf.Get("all"))) ||                   // If we check the "All" ASPxCheckBox
            (hf.Contains("cbpTopForce") && Convert.ToBoolean(hf.Get("cbpTopForce"))) ||   // required for the ASPxCallback control
            (Page.IsCallback &&                                                 // The page callback
            hf.Contains("cbpTop") &&                                            // contains the top callback panel in page's 
            Convert.ToBoolean(hf.Get("cbpTop")) &&                              // request patameters
            Request.Params["__CALLBACKID"].Contains(cbp.ID)) ||                 // and the top grid should be created
            (Page.IsPostBack && !Page.IsCallback &&                             // the simple postback iccurs
            hf.Contains("cbpTop")))                                             // and the page contains the top grid
        {
            Control ctrl = LoadControl("~/topgrid.ascx");
            ctrl.ID = "topgrid";
            cbp.Controls.Clear();
            cbp.Controls.Add(ctrl);
        }
    }

    protected void cbpBottom_Init(object sender, EventArgs e)
    {
        ASPxCallbackPanel cbp = sender as ASPxCallbackPanel;

        if ((hf.Contains("all") && Convert.ToBoolean(hf.Get("all"))) ||
            (Page.IsCallback &&
            hf.Contains("cbpBottom") &&
            Convert.ToBoolean(hf.Get("cbpBottom")) &&
            Request.Params["__CALLBACKID"].Contains(cbp.ID)) ||
            (Page.IsPostBack && !Page.IsCallback &&
            hf.Contains("cbpBottom")))
        {
            Control ctrl = LoadControl("~/bottomgrid.ascx");
            ctrl.ID = "bottomgrid";
            cbp.Controls.Clear();
            cbp.Controls.Add(ctrl);
        }
    }

    protected void pnlNavBar_Init(object sender, EventArgs e)
    {
        ASPxPanel panel = sender as ASPxPanel;

        // ASPxNavBar should be created at the first time, and on its callbacks
        if ((hf.Contains("all") && Convert.ToBoolean(hf.Get("all"))) ||
            !Page.IsCallback ||
            Request.Params["__CALLBACKID"].Contains(panel.ID))
        {
            Control ctrl = LoadControl("~/navbar.ascx");
            ctrl.ID = "navbar";
            panel.Controls.Clear();
            panel.Controls.Add(ctrl);
        }
    }

    protected void callback_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
    {
        UserControl ctrl = cbpTop.FindControl("topgrid") as UserControl;
        ASPxGridView grid1 = ctrl.FindControl("grid1") as ASPxGridView;
        e.Result = grid1.VisibleRowCount.ToString();
    }
}
