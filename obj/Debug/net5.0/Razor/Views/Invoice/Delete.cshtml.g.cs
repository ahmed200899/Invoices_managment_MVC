#pragma checksum "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e738754fb919bf07f2d98363da4240d7f95c5876"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Delete), @"mvc.1.0.view", @"/Views/Invoice/Delete.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\_ViewImports.cshtml"
using InvoiceApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\_ViewImports.cshtml"
using InvoiceApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e738754fb919bf07f2d98363da4240d7f95c5876", @"/Views/Invoice/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d3bee5daa51057c3533e767f6e97e895f8e7d0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceApp.Models.Invoice>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml"
  
    ViewBag.Title = "Delete Invoice";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Delete Invoice</h2>\r\n\r\n<p>Are you sure you want to delete this invoice?</p>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml"
Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\">Delete</button>\r\n");
#nullable restore
#line 17 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Delete.cshtml"
Write(Html.ActionLink("Cancel", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceApp.Models.Invoice> Html { get; private set; }
    }
}
#pragma warning restore 1591
