#pragma checksum "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93094720b6d3d1959e4d2c29e0455e9b53bdf786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Login_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Login/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\_ViewImports.cshtml"
using PTHShopping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\_ViewImports.cshtml"
using PTHShopping.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93094720b6d3d1959e4d2c29e0455e9b53bdf786", @"/Areas/Login/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98bc40aeb7f02c4ad2dfab2f91ee5096ea0c5ddb", @"/Areas/Login/Views/_ViewImports.cshtml")]
    public class Areas_Login_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Login/Views/Shared/_LoginLayout.cshtml";



#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"login-block\">\r\n    <div class=\"container login-container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4 login-sec pl-5\">\r\n                <h2 class=\"text-center\">Wellcome</h2>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93094720b6d3d1959e4d2c29e0455e9b53bdf7865022", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label>Số điện thoại</label>\r\n                        <input type=\"text\" class=\"form-control\" placeholder=\"Nhập số điện thoại của bạn\" name=\"sdt\"");
                BeginWriteAttribute("value", " value=\"", 627, "\"", 647, 1);
#nullable restore
#line 17 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
WriteAttributeValue("", 635, ViewBag.sdt, 635, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" maxlength=""11"">

                    </div>
                    <div class=""form-group"">
                        <label>Mật khẩu</label>
                        <input type=""password"" class=""form-control"" placeholder=""Nhập mật khẩu của bạn"" name=""Password"">
                    </div>
");
#nullable restore
#line 24 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
                     if (ViewBag.notFound != null)
                    {
                        if (ViewBag.notFound == "0")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"text-danger\">Số điện thoại và mật khẩu không được trống!</div>\r\n");
#nullable restore
#line 29 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
                        }
                        if (ViewBag.notFound == "1")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"text-danger\">Số điện thoại hoặc mật khẩu không đúng!</div>\r\n");
#nullable restore
#line 33 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Login\Views\Home\Index.cshtml"
                        }

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <div class=\"form-check\">\r\n                        <input type=\"checkbox\" class=\"form-check-input\" id=\"exampleCheck1\" name=\"nhomk\">\r\n                        <label for=\"nhomk\"");
                BeginWriteAttribute("class", " class=\"", 1657, "\"", 1665, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                           Nhớ mật khẩu\r\n                        </label>\r\n                        <br />\r\n                        <button type=\"submit\" class=\"btn btn-login float-right\">Đăng nhập</button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""copy-text""><i class=""fa fa-heart""></i><a href=""Login/Home/SignUp""> Đăng ký ngay</a></div>
            </div>
            <div class=""col-md-8 banner-sec"">
                <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                    <ol class=""carousel-indicators"">
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                    </ol>
                    <div class=""carousel-inner"" role=""listbox"">
                        <div class=""carousel-item active"">
                            <img class=""d-block img-slide"" src=""https://vnn-imgs-f.vgcloud.vn/2020/09/24/18/tranh-cai-an-hoa-qua-truoc-hay-sau-bua-an-da-co-cau-tra-loi.jpg"" alt=""First slide"">
                            <div class=""ca");
            WriteLiteral(@"rousel-caption d-none d-md-block"">
                                <div class=""banner-text"">
                                    <h2>Bách Hóa Online</h2>
                                    <p>Các mặt hàng trái cây tươi sạch 100%</p>
                                </div>
                            </div>
                        </div>
                        <div class=""carousel-item"">
                            <img class=""d-block img-slide"" src=""https://icdn.dantri.com.vn/thumb_w/640/2018/do-hop-1515983456164.jpeg"" alt=""First slide"">
                            <div class=""carousel-caption d-none d-md-block"">
                                <div class=""banner-text"">
                                    <h2>Bách Hóa Online</h2>
                                    <p>Đầy đủ các mặt hàng phục vụ cho một bửa ăn gia đình</p>
                                </div>
                            </div>
                        </div>
                        <div class=""carousel-item"">
              ");
            WriteLiteral(@"              <img class=""d-block img-slide"" src=""https://cdn.tgdd.vn/2021/04/content/xred-meat-vs-white-meat.jpg.pagespeed.ic.FDaubWNNo--800x533.jpg"" alt=""First slide"">
                            <div class=""carousel-caption d-none d-md-block"">
                                <div class=""banner-text"">
                                    <h2>Bách Hóa Online</h2>
                                    <p>Các mặt hàng tươi sống, bán trong ngày, đảm bảo sạch 100%</p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</section>


");
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
