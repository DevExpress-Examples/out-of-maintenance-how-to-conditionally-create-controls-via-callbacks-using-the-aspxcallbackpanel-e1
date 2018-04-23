<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bottomgrid.ascx.cs" Inherits="bottomgrid" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<script language="javascript" type="text/javascript" id="dxss_topGrid">
    ShowGrid2Data = function()
    {
        grid2.GetRowValues(grid2.GetTopVisibleIndex() + 1, "Id;Name;Text", OnGrid1Callback);
    }
    
    function OnGrid1Callback(values)
    {
        alert("grid2 second row values: " + values[0] + "; " + values[1] + "; " + values[2]);
    }
</script>

<dx:ASPxGridView ID="grid2" ClientInstanceName="grid2" runat="server" AutoGenerateColumns="False"
    KeyFieldName="Id">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Text" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Styles CssFilePath="~/Styles/grid.css" CssPostfix="grid">
    </Styles>
    <Images SpriteCssFilePath="~/Styles/grid_sprites.css">
    </Images>
</dx:ASPxGridView>
<dx:ASPxTextBox ID="txt2" runat="server" Width="400px" Text="Please enter any text and do a simple postback">
</dx:ASPxTextBox>
