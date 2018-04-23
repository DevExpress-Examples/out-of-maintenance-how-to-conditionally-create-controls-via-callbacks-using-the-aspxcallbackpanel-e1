Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class topgrid
	Inherits System.Web.UI.UserControl
	Private Const RowCount As Int32 = 230000

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim tbl As New DataTable()

		Dim col As New DataColumn("Id", GetType(Int32))
		tbl.Columns.Add(col)
		tbl.PrimaryKey = New DataColumn() { col }

		col = New DataColumn("Name", GetType(String))
		tbl.Columns.Add(col)

		col = New DataColumn("Text", GetType(String))
		tbl.Columns.Add(col)

		For i As Integer = 0 To RowCount - 1
			tbl.Rows.Add(New Object() { i, String.Format("Name{0}", i), String.Format("Test{0}", i) })
		Next i

		grid1.DataSource = tbl
		grid1.DataBind()
	End Sub
End Class
