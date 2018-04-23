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
using DevExpress.Web.ASPxNavBar;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System.Text;
using DevExpress.Web.ASPxSplitter;

public partial class navbar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void nb_ItemClick(object source, DevExpress.Web.ASPxNavBar.NavBarItemEventArgs e)
    {
        ASPxNavBar navbar = source as ASPxNavBar;
        ASPxLabel lbl = Page.FindControl("lbl") as ASPxLabel;
        ASPxSplitter splitter = Page.FindControl("splitter") as ASPxSplitter;
        UserControl topgrid = splitter.FindControl("cbpTop").FindControl("topgrid") as UserControl;
        UserControl bottomgrid = splitter.FindControl("cbpBottom").FindControl("bottomgrid") as UserControl;

        ASPxGridView grid1 = null,
            grid2 = null;

        if (topgrid != null)
            grid1 = topgrid.FindControl("grid1") as ASPxGridView;
        if (bottomgrid != null)
            grid2 = bottomgrid.FindControl("grid2") as ASPxGridView;

        if (e.Item.Name == "itm32")
        {
            StringBuilder result = new StringBuilder();
            if (grid1 != null)
                result.AppendFormat("grid1 exists, current page is {0}", grid1.PageIndex + 1);
            if (grid2 != null)
            {
                Object[] values = (Object[])grid2.GetRowValues(grid2.VisibleStartIndex + 1, new String[] { "Id", "Name", "Text" });
                result.AppendFormat("<br />grid2 exists, the second visible row values are <span style=\"Color: Red;\">{0}, {1}, {2}</span>", values[0], values[1], values[2]);
            }
            lbl.Text = result.ToString();
        }
    }
}
