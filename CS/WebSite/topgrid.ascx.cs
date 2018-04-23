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

public partial class topgrid : System.Web.UI.UserControl
{
    const Int32 RowCount = 230000; 

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tbl = new DataTable();
        
        DataColumn col = new DataColumn("Id", typeof(Int32));
        tbl.Columns.Add(col);
        tbl.PrimaryKey = new DataColumn[] { col };
        
        col = new DataColumn("Name", typeof(String));
        tbl.Columns.Add(col);

        col = new DataColumn("Text", typeof(String));
        tbl.Columns.Add(col);

        for (int i = 0; i < RowCount; i++)
            tbl.Rows.Add(new Object[] { i, String.Format("Name{0}", i), String.Format("Test{0}", i) });

        grid1.DataSource = tbl;
        grid1.DataBind();
    }
}
