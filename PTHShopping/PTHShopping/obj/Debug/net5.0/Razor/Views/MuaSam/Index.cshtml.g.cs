#pragma checksum "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47aad844614601205499aabe5dfe5cbb92af810d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MuaSam_Index), @"mvc.1.0.view", @"/Views/MuaSam/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47aad844614601205499aabe5dfe5cbb92af810d", @"/Views/MuaSam/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffed51b33a69608cde4de23549a5a67c17c07f58", @"/Views/_ViewImports.cshtml")]
    public class Views_MuaSam_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PTHShopping.Models.Sanpham_Danhmuc>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
  
    Layout = "_MuaSamLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-lg-9 col-md-7"">
    <div class=""product__discount"">
        <div class=""section-title product__discount__title"">
            <h2>Sale Off</h2>
        </div>
        <div class=""row"">
            <div class=""product__discount__slider owl-carousel"">
");
#nullable restore
#line 12 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                 foreach (var item in Model.ListSanpham)
                {
                    int index = Model.ListSanpham.ToList().IndexOf(item);
                    if (ViewBag.idspdm == item.CatId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-4\">\r\n                            <div class=\"product__discount__item\">\r\n                                <div class=\"product__discount__item__pic set-bg\"\r\n                                     data-setbg=\"");
#nullable restore
#line 20 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                            Write(item.Thumb);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
#nullable restore
#line 21 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                     if (item.KhuyenMai != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"product__discount__percent\">");
#nullable restore
#line 23 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                                                           Write(item.KhuyenMai);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</div>\r\n");
#nullable restore
#line 24 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <ul class=""product__item__pic__hover"">
                                        <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                        <li><a href=""#""><i class=""fa fa-retweet""></i></a></li>
                                        <li><a href=""#""><i class=""fa fa-shopping-cart""></i></a></li>
                                    </ul>
                                </div>
                                <div class=""product__discount__item__text"">
                                    <span>");
#nullable restore
#line 32 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                     Write(item.CatId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <h5><a");
            BeginWriteAttribute("href", " href=\"", 1725, "\"", 1783, 1);
#nullable restore
#line 33 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
WriteAttributeValue("", 1732, Url.Action("Index", "ChiTietSP",new { id = index}), 1732, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 33 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                                                                                 Write(item.TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n");
#nullable restore
#line 34 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                     if (item.KhuyenMai != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"product__item__price\">");
#nullable restore
#line 36 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                                                      Write(item.Gia*(100-item.KhuyenMai)/100);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND <span>");
#nullable restore
#line 36 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                                                                                                    Write(item.Gia);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</span></div>\r\n");
#nullable restore
#line 37 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"product__item__price\">");
#nullable restore
#line 40 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                                                      Write(item.Gia);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</div>\r\n");
#nullable restore
#line 41 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 46 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\MuaSam\Index.cshtml"
                    }

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PTHShopping.Models.Sanpham_Danhmuc> Html { get; private set; }
    }
}
#pragma warning restore 1591
