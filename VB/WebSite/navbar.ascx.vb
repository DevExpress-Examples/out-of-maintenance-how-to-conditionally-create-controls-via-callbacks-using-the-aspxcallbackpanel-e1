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
Imports DevExpress.Web.ASPxNavBar
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Text
Imports DevExpress.Web.ASPxSplitter

Partial Public Class navbar
	Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub nb_ItemClick(ByVal source As Object, ByVal e As DevExpress.Web.ASPxNavBar.NavBarItemEventArgs)
		Dim navbar As ASPxNavBar = TryCast(source, ASPxNavBar)
		Dim lbl As ASPxLabel = TryCast(Page.FindControl("lbl"), ASPxLabel)
		Dim splitter As ASPxSplitter = TryCast(Page.FindControl("splitter"), ASPxSplitter)
		Dim topgrid As UserControl = TryCast(splitter.FindControl("cbpTop").FindControl("topgrid"), UserControl)
		Dim bottomgrid As UserControl = TryCast(splitter.FindControl("cbpBottom").FindControl("bottomgrid"), UserControl)

		Dim grid1 As ASPxGridView = Nothing, grid2 As ASPxGridView = Nothing

		If topgrid IsNot Nothing Then
			grid1 = TryCast(topgrid.FindControl("grid1"), ASPxGridView)
		End If
		If bottomgrid IsNot Nothing Then
			grid2 = TryCast(bottomgrid.FindControl("grid2"), ASPxGridView)
		End If

		If e.Item.Name = "itm32" Then
			Dim result As New StringBuilder()
			If grid1 IsNot Nothing Then
				result.AppendFormat("grid1 exists, current page is {0}", grid1.PageIndex + 1)
			End If
			If grid2 IsNot Nothing Then
				Dim values() As Object = CType(grid2.GetRowValues(grid2.VisibleStartIndex + 1, New String() { "Id", "Name", "Text" }), Object())
				result.AppendFormat("<br />grid2 exists, the second visible row values are <span style=""Color: Red;"">{0}, {1}, {2}</span>", values(0), values(1), values(2))
			End If
			lbl.Text = result.ToString()
		End If
	End Sub
End Class
