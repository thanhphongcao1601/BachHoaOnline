#pragma checksum "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb1c12a0b0fde5338433a5412c920157e0565ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Details), @"mvc.1.0.view", @"/Views/Profile/Details.cshtml")]
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
#line 1 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\_ViewImports.cshtml"
using PTHShopping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\_ViewImports.cshtml"
using PTHShopping.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb1c12a0b0fde5338433a5412c920157e0565ff", @"/Views/Profile/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffed51b33a69608cde4de23549a5a67c17c07f58", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PTHShopping.Models.KhachHang>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Login/Views/Shared/_LoginLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>KhachHang</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HoTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.HoTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SinhNhat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.SinhNhat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Avatar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Avatar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DiaChi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.DiaChi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Quan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Phuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Phuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NgayTao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.NgayTao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MatKhau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.MatKhau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Salt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Salt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastLogin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastLogin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Giotinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.Giotinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdvitriNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdvitriNavigation.IdviTri));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb1c12a0b0fde5338433a5412c920157e0565ff14390", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Profile\Details.cshtml"
                           WriteLiteral(Model.IdkhachHang);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb1c12a0b0fde5338433a5412c920157e0565ff16556", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PTHShopping.Models.KhachHang> Html { get; private set; }
    }
}
#pragma warning restore 1591
