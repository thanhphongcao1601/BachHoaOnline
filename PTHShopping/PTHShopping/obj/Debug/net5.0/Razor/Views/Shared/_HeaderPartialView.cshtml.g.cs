#pragma checksum "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7882f211a48dd1b756b22d0f99187514b792abe0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HeaderPartialView), @"mvc.1.0.view", @"/Views/Shared/_HeaderPartialView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7882f211a48dd1b756b22d0f99187514b792abe0", @"/Views/Shared/_HeaderPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffed51b33a69608cde4de23549a5a67c17c07f58", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HeaderPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Userassets/img/lg.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Userassets/img/language.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:60%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <!-- Page Preloder -->
<div id=""preloder"">
    <div class=""loader""></div>
</div>

<!-- Humberger Begin -->
<div class=""humberger__menu__overlay""></div>
<div class=""humberger__menu__wrapper"">
    <div class=""humberger__menu__logo"">
        <a href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7882f211a48dd1b756b22d0f99187514b792abe05083", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
    </div>
    <div class=""humberger__menu__cart"">
        <ul>
            <li><a href=""#""><i class=""fa fa-heart""></i> <span>1</span></a></li>
            <li><a href=""#""><i class=""fa fa-shopping-bag""></i> <span>3</span></a></li>
        </ul>
        <div class=""header__cart__price"">item: <span>");
#nullable restore
#line 17 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                                Write(ViewBag.totalprice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</span></div>\r\n    </div>\r\n    <div class=\"humberger__menu__widget\">\r\n        <div class=\"header__top__right__language\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7882f211a48dd1b756b22d0f99187514b792abe06957", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div>English</div>
            <span class=""arrow_carrot-down""></span>
            <ul>
                <li><a href=""#"">Spanis</a></li>
                <li><a href=""#"">English</a></li>
            </ul>
        </div>
        <div class=""header__top__right__auth"">
            <a href=""#""><i class=""fa fa-user""></i> Login</a>
        </div>
    </div>
    <nav class=""humberger__menu__nav mobile-menu"">
        <ul>
            <li class=""active""><a href=""/"">Trang Chủ</a></li>
            <li><a href=""/MuaSam"">Mua Sắm</a></li>
            <li><a href=""/TinTuc"">Tin Tức</a></li>
            <li><a href=""/LienHe"">Liên Hệ</a></li>
        </ul>
    </nav>
    <div id=""mobile-menu-wrap""></div>
    <div class=""header__top__right__social"">
        <a href=""#""><i class=""fa fa-facebook""></i></a>
        <a href=""#""><i class=""fa fa-twitter""></i></a>
        <a href=""#""><i class=""fa fa-linkedin""></i></a>
        <a href=""#""><i class=""fa fa-pinterest-p""></i></a>
    </div>
    <div cla");
            WriteLiteral(@"ss=""humberger__menu__contact"">
        <ul>
            <li><i class=""fa fa-envelope""></i> hello@colorlib.com</li>
            <li>Free Shipping for all Order of $99</li>
        </ul>
    </div>
</div>
<!-- Humberger End -->
<!-- Header Section Begin -->
<header class=""header"">
    <div class=""header__top"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6 col-md-6"">
                    <div class=""header__top__left"">
                        <ul>
                            <li><i class=""fa fa-envelope""></i> bachhoa.online@gmail.com</li>
                            <li>CỬA HÀNG BÁCH HOÁ ONLINE</li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-6 col-md-6"">
                    <div class=""header__top__right font-weight-bold"">
                        <div class=""header__top__right__auth d-flex float-right"">
");
#nullable restore
#line 72 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                             if (User.Identity.IsAuthenticated)
                            {

                                var roles = ((ClaimsIdentity)User.Identity).Claims
                                .Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value).ToList()[0];
                                if (roles != "Admin" && roles != "Staff" && roles != "shipper")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"mr-3\"");
            BeginWriteAttribute("href", " href=\"", 3310, "\"", 3348, 1);
#nullable restore
#line 80 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
WriteAttributeValue("", 3317, Url.Action("Index", "Profile"), 3317, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-user-circle-o\"></i>");
#nullable restore
#line 80 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                                                                                                         Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 81 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                }
                                if (roles == "Admin" || roles == "Staff")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"mr-3\" href=\"/Admin\">| Vào trang quản trị </a>\r\n");
#nullable restore
#line 85 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                }
                                if (roles == "Shipper")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"mr-3\" href=\"/Shipper\">| Vào trang giao hàng </a>\r\n");
#nullable restore
#line 89 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"/Login/Home/Logout\">| <i class=\"fa fa-sign-out\"></i> Đăng xuất</a>\r\n");
#nullable restore
#line 91 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"/Login\"><i class=\"fa fa-user\"></i> Đăng nhập</a>\r\n");
#nullable restore
#line 95 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3"">
                <div class=""header__logo"">
                    <a href=""./index.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7882f211a48dd1b756b22d0f99187514b792abe013933", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                </div>
            </div>
            <div class=""col-lg-6"">
                <nav class=""header__menu"">
                    <ul>
                        <li id=""trangchu""class=""active""><a href=""/"">Trang chủ</a></li>
                        <li id=""muasam""><a href=""/MuaSam"">Mua sắm</a></li>
                        <li id=""trangkhac""><a href=""/TinTuc"">Tin Tức</a></li>
                        <li id=""lienhe""><a href=""./LienHe"">Liên hệ</a></li>
                    </ul>
                </nav>
            </div>
            <div class=""col-lg-3"">
                <div class=""header__cart"">
                    <ul>
                        <li><a href=""/Cart""><i class=""fa fa-shopping-bag""></i> <span>");
#nullable restore
#line 122 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                                                                Write(ViewBag.cartNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a></li>\r\n                    </ul>\r\n                    <div class=\"header__cart__price\">Tổng: <span>");
#nullable restore
#line 124 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Views\Shared\_HeaderPartialView.cshtml"
                                                            Write(ViewBag.totalprice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</span></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"humberger__open\">\r\n            <i class=\"fa fa-bars\"></i>\r\n        </div>\r\n    </div>\r\n</header>\r\n<!-- Header Section End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
