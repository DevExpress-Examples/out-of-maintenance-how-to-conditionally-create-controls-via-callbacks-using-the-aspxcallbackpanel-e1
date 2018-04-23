<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navbar.ascx.cs" Inherits="navbar" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dx" %>

<script language="javascript" type="text/javascript" id="dxss_NavBar">
function OnItemClick(s, e) {
    e.processOnServer = false;
    
    if (e.item.name == "itm11")
    {
        hf.Set('cbpTop', true);   // load top grid (like e.Parameter);
        cbpTop.PerformCallback(); // all callback procesing is done in the cbpTop.Init event handler
    }
    else if (e.item.name == "itm12")
    {
        hf.Set('cbpTop', false);  // remove top grid (like e.Parameter);
        cbpTop.PerformCallback(); // all callback procesing is done in the cbpTop.Init event handler
    }
    else if (e.item.name == "itm21")
    {
        hf.Set('cbpBottom', true);   // load bottom grid (like e.Parameter);
        cbpBottom.PerformCallback(); // all callback procesing is done in the cbpBottom.Init event handler
    }
    else if (e.item.name == "itm22")
    {
        hf.Set('cbpBottom', false);  // remove bottom grid (like e.Parameter);
        cbpBottom.PerformCallback(); // all callback procesing is done in the cbpBottom.Init event handler
    }
    else if (e.item.name == "itm31")
        e.processOnServer = true;    // simple postback (just to see that the ASPxTextBox doesn't lose its text
    else if (e.item.name == "itm32")
        e.processOnServer = true;    // server-side processing
    else if (e.item.name == "itm33")
    {
        // send two parallel callbacks
        if (typeof(ShowGrid1Data) != "undefined")
            ShowGrid1Data();
        if (typeof(ShowGrid2Data) != "undefined")
            ShowGrid2Data();
    } 
    else if (e.item.name == "itm34")
    {
        // use the ASPxCallback control. 
        if (typeof (grid1) != "undefined")
        {
            hf.Set("cbpTopForce", true); // require the top grid at the server side
            callback.PerformCallback();
        }
        else
            alert("create the top grid first");
    }         
}
</script>

<dx:ASPxNavBar ID="nb" runat="server" ClientInstanceName="nb" EnableCallBacks="True" OnItemClick="nb_ItemClick">
    <Groups>
        <dx:NavBarGroup ItemBulletStyle="Disc" Name="grp1" Text="Step 1">
            <Items>
                <dx:NavBarItem Name="itm11" Text="Create Top Grid">
                </dx:NavBarItem>
                <dx:NavBarItem Name="itm12" Text="Remove Top Grid">
                </dx:NavBarItem>
            </Items>
        </dx:NavBarGroup>
        <dx:NavBarGroup Expanded="False" ItemBulletStyle="Disc" Name="grp2" Text="Step 2">
            <Items>
                <dx:NavBarItem Name="itm21" Text="Create Bottom Grid">
                </dx:NavBarItem>
                <dx:NavBarItem Name="itm22" Text="Remove Bottom Grid">
                </dx:NavBarItem>
            </Items>
        </dx:NavBarGroup>
        <dx:NavBarGroup Expanded="False" Name="itm3" Text="Test Group">
            <Items>
                <dx:NavBarItem Name="itm31" Text="Simple Postback">
                </dx:NavBarItem>
                <dx:NavBarItem Name="itm32" Text="Get Server Data">
                </dx:NavBarItem>
                <dx:NavBarItem Name="itm33" Text="Get Client-side data" ToolTip="Each control performs a callback">
                </dx:NavBarItem>
                <dx:NavBarItem Name="itm34" Text="Separate callback" ToolTip="Using the ASPxCallback to obtain some data from the server">
                </dx:NavBarItem>
            </Items>
        </dx:NavBarGroup>
    </Groups>
    <ClientSideEvents ItemClick="OnItemClick" />
</dx:ASPxNavBar>
