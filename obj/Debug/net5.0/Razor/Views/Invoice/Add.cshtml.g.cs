#pragma checksum "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc79d12cd4d4e87a0476dcbd05d5892edd560481"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Add), @"mvc.1.0.view", @"/Views/Invoice/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc79d12cd4d4e87a0476dcbd05d5892edd560481", @"/Views/Invoice/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d3bee5daa51057c3533e767f6e97e895f8e7d0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceApp.Models.CreateInvoiceViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 4 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
  
    ViewBag.Title = "Add Invoice";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Add Invoice</h2>\n\n");
#nullable restore
#line 12 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        <label for=\"Customer\">Customer:</label>\n        ");
#nullable restore
#line 18 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
   Write(Html.EditorFor(model => model.Invoice.Customer, new { htmlAttributes = new { id = "Invoice_Customer" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div>\n        <label for=\"Id\">Id:</label>\n        ");
#nullable restore
#line 22 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
   Write(Html.EditorFor(model => model.Invoice.Id, new { htmlAttributes = new { id = "Invoice_Id" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div>\n        <label for=\"InvoiceDate\">InvoiceDate:</label>\n        ");
#nullable restore
#line 26 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
   Write(Html.EditorFor(model => model.Invoice.InvoiceDate, new { htmlAttributes = new { id = "Invoice_InvoiceDate" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
            WriteLiteral("    <div class=\"form-group\">\n\n        <label for=\"SelectedItemIds\">Select Items:</label>\n        ");
#nullable restore
#line 32 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
   Write(Html.DropDownListFor(model => model.AvailableItems,ViewBag.groceryItems as SelectList,  new { @class = "form-control", @onChange  =  "SelectedValue(this)"} ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        <label for \"itemprice\"> Item Price</label>\n        <input type=\"text\" id=\"ItemPrice\" class=\"form-control\" readonly> \n\n        <label for=\"amount\">Amount:</label>\n        ");
#nullable restore
#line 38 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
   Write(Html.EditorFor(model => model.InvoiceItems.Amount, new { htmlAttributes = new { @class = "form-control", id = "Amount", onchange = "UpdatePrice()" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        <label for \"Price\"> Price</label>\n        <input type=\"text\" id=\"Price\" class=\"form-control\" readonly> \n    </div>\n");
            WriteLiteral("    <button type=\"Button\" id=\"Addtotablebutton\" onclick=\"AddToTable()\"> Add Item </button>\n");
            WriteLiteral(@"    <table id=""itemTable"" class=""table"">
        <thead>
            <tr>
                <th>Item</th>
                <th>Amount</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <div id=""totalprice"" class=""total-price"">Total Price: 0.00</div>
");
            WriteLiteral("    <button type=\"button\" id=\"SaveInvoiceButton\" >Save Invoice</button>\n");
#nullable restore
#line 61 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"

    

    
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .form-control 
    {
        width: 170px; 
        height: 35px; 
        font-size: 14px; 
        display: inline-block;
        margin-right: 10px;
    }

    #ItemPrice 
    {
        width: 80px;
    }

    .total-price
    {
        font-size: 16px;
        font-weight: bold;        
    }

</style>



<script>
    var itemsList = ");
#nullable restore
#line 94 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
               Write(Html.Raw(Json.Serialize(ViewBag.itemslist)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
</script>
  

<script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>
<script type=""text/javascript"">

    var itemPriceValue = 0;
    var totalPrice = 0; 


    function SelectedValue(selecteditem) 
    {
        var selecteditemname = selecteditem.options[selecteditem.selectedIndex].innerHTML;
        var selectedId = selecteditem.value;
        var targetItem = itemsList.find(function(item) {
            return item.id === parseInt(selectedId);
        });
        var selectedprice = parseFloat(targetItem.itemprice);

        document.getElementById(""ItemPrice"").value = selectedprice;
        itemPriceValue = parseFloat(selectedprice);
        UpdatePrice(); 
        window.selectedItemName = selecteditemname;
        window.selectedid = selectedId
    }


    function UpdatePrice() 
    {
        var amount = parseFloat(document.getElementById(""Amount"").value);
        var Price = amount * itemPriceValue; 
        document.getElementById(""Price"").value = Price.toFixed(2); 
    }



    windo");
            WriteLiteral(@"w.onload = function () 
     {
        var amountInput = document.getElementById(""Amount"");
        if (amountInput.value === """") {
            amountInput.value = 1;
        }
     }; 



    function AddToTable() 
    {
        var amount = parseFloat(document.getElementById(""Amount"").value);
        var Price = parseFloat(document.getElementById(""Price"").value);

        var tableBody = document.getElementById(""itemTable"").getElementsByTagName(""tbody"")[0];
        var newRow = tableBody.insertRow();
        var cell1 = newRow.insertCell(0);
        var cell2 = newRow.insertCell(1);
        var cell3 = newRow.insertCell(2);
        cell1.innerHTML = window.selectedItemName; 

        cell2.innerHTML = amount;
        cell3.innerHTML = Price.toFixed(2);

        document.getElementById(""Amount"").value = 1;
        document.getElementById(""Price"").value = itemPriceValue.toFixed(2);
        totalPrice += Price; 
        UpdateTotalprice(); 

        document.getElementById(""Amount"").value = 1;
        document");
            WriteLiteral(@".getElementById(""Price"").value = itemPriceValue.toFixed(2);
    }



    function UpdateTotalprice() 
    {
        var totalpriceElement = document.getElementById(""totalprice"");
        totalpriceElement.innerHTML = ""Total Price: "" + totalPrice.toFixed(2);
    }



    $(document).ready(function () 
    {
        $(""#SaveInvoiceButton"").click(function () 
        {
            var totalprice =totalPrice
            var customer = $(""#Invoice_Customer"").val();
            var id = $(""#Invoice_Id"").val();
            var invoiceDate = $(""#Invoice_InvoiceDate"").val();
            var invoiceItems = [];


            var tableBody = document.getElementById(""itemTable"").getElementsByTagName(""tbody"")[0];
            var rows = tableBody.getElementsByTagName(""tr"");
            for (var i = 0; i < rows.length; i++) {
                var cells = rows[i].getElementsByTagName(""td"");
                var item_Name = cells[0].innerHTML;
                var amount = parseFloat(cells[1].innerHTML);
                var item_");
            WriteLiteral(@"price = parseFloat(cells[2].innerHTML);
                var ItemId = window.selectedId;

                var invoiceItem = {
                    InvoiceId: id, 
                    Amount: amount,
                    item_Name:item_Name                
                    };

                invoiceItems.push(invoiceItem);
            }

            $.ajax
            ({
                url: ""/Invoice/AddInvoice"",
                type: ""POST"",
                data: 
                    {
                        totalprice: totalprice,
                        Customer: customer,
                        Id :id,
                        InvoiceDate: invoiceDate,
                        invoiceItems:invoiceItems
                    },success: function (response) {
                        console.log(""Response received:"", response);
                    },


            });
        });
    });



</script>


");
#nullable restore
#line 229 "C:\Users\Ahmed\Desktop\.net\InvoiceApp\Views\Invoice\Add.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceApp.Models.CreateInvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
