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
Imports DevExpress.Web.ASPxPanel
Imports DevExpress.Web.ASPxCallbackPanel
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.Web.ASPxEditors
Imports System.Xml
Imports System.Threading
Imports DevExpress.Web.ASPxGridView

' http://stackoverflow.com/questions/1110625/how-do-i-detect-if-a-request-is-a-callback-in-the-global-asax

Partial Public Class Main
	Inherits Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		ASPxEdit.RegisterBaseScript(Page)
	End Sub

	Protected Sub cbpTop_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim cbp As ASPxCallbackPanel = TryCast(sender, ASPxCallbackPanel)

		If (hf.Contains("all") AndAlso Convert.ToBoolean(hf.Get("all"))) OrElse (hf.Contains("cbpTopForce") AndAlso Convert.ToBoolean(hf.Get("cbpTopForce"))) OrElse (Page.IsCallback AndAlso hf.Contains("cbpTop") AndAlso Convert.ToBoolean(hf.Get("cbpTop")) AndAlso Request.Params("__CALLBACKID").Contains(cbp.ID)) OrElse (Page.IsPostBack AndAlso (Not Page.IsCallback) AndAlso hf.Contains("cbpTop")) Then ' and the page contains the top grid
			Dim ctrl As Control = LoadControl("~/topgrid.ascx")
			ctrl.ID = "topgrid"
			cbp.Controls.Clear()
			cbp.Controls.Add(ctrl)
		End If
	End Sub

	Protected Sub cbpBottom_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim cbp As ASPxCallbackPanel = TryCast(sender, ASPxCallbackPanel)

		If (hf.Contains("all") AndAlso Convert.ToBoolean(hf.Get("all"))) OrElse (Page.IsCallback AndAlso hf.Contains("cbpBottom") AndAlso Convert.ToBoolean(hf.Get("cbpBottom")) AndAlso Request.Params("__CALLBACKID").Contains(cbp.ID)) OrElse (Page.IsPostBack AndAlso (Not Page.IsCallback) AndAlso hf.Contains("cbpBottom")) Then
			Dim ctrl As Control = LoadControl("~/bottomgrid.ascx")
			ctrl.ID = "bottomgrid"
			cbp.Controls.Clear()
			cbp.Controls.Add(ctrl)
		End If
	End Sub

	Protected Sub pnlNavBar_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim panel As ASPxPanel = TryCast(sender, ASPxPanel)

		' ASPxNavBar should be created at the first time, and on its callbacks
		If (hf.Contains("all") AndAlso Convert.ToBoolean(hf.Get("all"))) OrElse (Not Page.IsCallback) OrElse Request.Params("__CALLBACKID").Contains(panel.ID) Then
			Dim ctrl As Control = LoadControl("~/navbar.ascx")
			ctrl.ID = "navbar"
			panel.Controls.Clear()
			panel.Controls.Add(ctrl)
		End If
	End Sub

	Protected Sub callback_Callback(ByVal source As Object, ByVal e As DevExpress.Web.ASPxCallback.CallbackEventArgs)
		Dim ctrl As UserControl = TryCast(cbpTop.FindControl("topgrid"), UserControl)
		Dim grid1 As ASPxGridView = TryCast(ctrl.FindControl("grid1"), ASPxGridView)
		e.Result = grid1.VisibleRowCount.ToString()
	End Sub
End Class
