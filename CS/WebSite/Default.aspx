<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Main" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPager" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxSplitter" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGlobalEvents" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
    var startDate, endDate;
  
    function OnBeginCallback(s, e) {
        startDate = new Date();
    }
    
    function OnEndCallback(s, e) {        
        hf.Remove("cbpTopForce");
        
        endDate = new Date();
        var diff = (endDate - startDate) / 1000;
        lbl.SetText("Callback processing time:&nbsp;" + diff + "&nbsp;sec");
    }
   
    function OnCheckedChanged(s, e) {
        hf.Set("all", s.GetChecked());
    }
    
    function OnCallbackComplete(s, e) {
        alert("Top grid: visible row count - " + e.result);
    }
    </script>

    <link href="Styles/grid.css" type="text/css" rel="Stylesheet" />
    <link href="Styles/grid_sprites.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxHiddenField ID="hf" runat="server" ClientInstanceName="hf">
            </dx:ASPxHiddenField>
            <dx:ASPxCallback ID="callback" runat="server" ClientInstanceName="callback" OnCallback="callback_Callback">
                <ClientSideEvents CallbackComplete="OnCallbackComplete" />
            </dx:ASPxCallback>
            <table>
                <tr>
                    <td style="padding-right: 20px;">
                        <dx:ASPxCheckBox ID="cb" runat="server" ClientInstanceName="cb" Text="Always create controls"
                            Checked="false" AutoPostBack="true">
                            <ClientSideEvents CheckedChanged="OnCheckedChanged" />
                        </dx:ASPxCheckBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbl" ClientInstanceName="lbl" runat="server" Text="Useful information:"
                            ForeColor="DarkGreen" EncodeHtml="false">
                        </dx:ASPxLabel>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 200px;" valign="top">
                        <dx:ASPxPanel ID="pnlNavBar" runat="server" Width="200px" OnInit="pnlNavBar_Init">
                        </dx:ASPxPanel>
                    </td>
                    <td valign="top">
                        <dx:ASPxSplitter ID="splitter" runat="server" ClientInstanceName="splitter" Orientation="Vertical"
                            Height="650px">
                            <Panes>
                                <dx:SplitterPane>
                                    <ContentCollection>
                                        <dx:SplitterContentControl runat="server">
                                            <dx:ASPxCallbackPanel ID="cbpTop" runat="server" ClientInstanceName="cbpTop" OnInit="cbpTop_Init">
                                                <PanelCollection>
                                                    <dx:PanelContent runat="server">
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                    <PaneStyle>
                                        <Paddings Padding="5px" />
                                    </PaneStyle>
                                </dx:SplitterPane>
                                <dx:SplitterPane>
                                    <ContentCollection>
                                        <dx:SplitterContentControl runat="server">
                                            <dx:ASPxCallbackPanel ID="cbpBottom" runat="server" ClientInstanceName="cbpBottom"
                                                OnInit="cbpBottom_Init">
                                                <PanelCollection>
                                                    <dx:PanelContent runat="server">
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                    <PaneStyle>
                                        <Paddings Padding="5px" />
                                    </PaneStyle>
                                </dx:SplitterPane>
                            </Panes>
                        </dx:ASPxSplitter>
                    </td>
                </tr>
            </table>
        </div>
        <dx:ASPxGlobalEvents ID="glob" runat="server">
            <ClientSideEvents BeginCallback="OnBeginCallback" EndCallback="OnEndCallback" />
        </dx:ASPxGlobalEvents>
        &nbsp;
    </form>
</body>
</html>
