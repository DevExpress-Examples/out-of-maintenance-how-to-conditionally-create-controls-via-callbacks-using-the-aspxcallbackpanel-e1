# How to conditionally create controls via callbacks using the ASPxCallbackPanel


<p>The standard ASP.NET behavior demands full page hierarchy recreation on each page request. However, there are situations when the ASPxNavBar (with turned callbacks on) is expanded too slowly if the nearest ASPxGridView binding is long. This example demonstrates the following tasks:<br />
1. How to create a control via callbacks;<br />
2. How to conditionally create controls on each page request.</p><p><strong>Warning:</strong> this solution requires deeper examination, because it can't be simply implemented in the large projects, and it might break the existing functionality.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2972">How to create ASPxGridView after the page has been loaded</a></p><p><strong>Update:</strong> it is not recommended to use this example if its implementation breaks the existing project functionality. This example is not supported starting with version v2010 vol 2.7. We apologize for a possible inconvenience.</p>


<h3>Description</h3>

<p>Each control, which sends a callback, defines the <strong>__CALLBACKID</strong> request parameter with its client name. The name contains a long and complex string which is built from all parent naming containers. E.g. in the current example each ASPxGridView control (or the ASPxNavBar) contains the ASPxCallbackPanel&#39;s (ASPxPanel&#39;s) name, which can be used within the complex conditions.<br />
The ASPxHiddenField contains all information about already created controls. This data is required for conditional creation. E.g. if the top grid&#39;s callback occurs, the top ASPxCallbackPanel loads the UserControl (with the grid) and the further processing works fine. The ASPxHiddenField contains the code, which allow you to get the post data in the Init event handler of any control which <strong>lays below the hidden field</strong>.<br />
&nbsp;<br />
Many &quot;if&quot; conditions are created for demonstration purposes only, but the main condition should be the following: <i>if the current callback argument contains a panel&#39;s ID, we should create the panel&#39;s content</i>. The lesser condition is <i>to create other controls if we require them</i>.</p>

<br/>


