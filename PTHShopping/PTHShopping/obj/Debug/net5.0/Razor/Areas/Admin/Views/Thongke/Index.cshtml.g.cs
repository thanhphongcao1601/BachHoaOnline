#pragma checksum "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7176aa7c77e9a6550e16332161b42e225fc69f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Thongke_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Thongke/Index.cshtml")]
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
#line 1 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\_ViewImports.cshtml"
using PTHShopping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\_ViewImports.cshtml"
using PTHShopping.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7176aa7c77e9a6550e16332161b42e225fc69f9", @"/Areas/Admin/Views/Thongke/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81781e9eafab353c8c8571f297611c0fb50fbd73", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Thongke_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
<style>
    .scroll {
        overflow-x: scroll;
        width: 100%;
    }

    .td1 {
        width: 100px;
        overflow: hidden;
        display: inline-block;
        white-space: nowrap;
    }
    .icon {
        font-size: 63px;
        color: white;
    }

    .head{
        box-sizing:border-box;
    }
    .box {
        height: 100px;
        box-sizing:border-box;
        margin: 0px;
       
    }
    .td{
        text-align: center !important;
        vertical-align: middle !important;
    }
    .date{
        max-width:54px;
        border:solid 1px white;
        margin-top:2px;
    }
    .dhht {
        overflow-y: scroll;
        max-height: 500px;
    }
    .sphh {
        overflow-y: scroll;
        max-height: 350px;
    }
    td {
        vertical-align: middle !important;
    }
</style>

<h5 class=""text-info"">Thống kê Bách Hóa Online</h5>
<hr />
");
            WriteLiteral(@"

<div class=""d-flex row"">
    <div class=""card d-flex box col-12 col-md-3"">
        <table>
            <tr>
                <td class=""bg-danger td td1""><i class=""icon mdi mdi-cart-outline""> </i></td>
                <td class=""td"">
                    Tổng số đơn hàng
                    <br />
                    (<strong>");
#nullable restore
#line 67 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                        Write(ViewBag.sodonhang);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>)
                    <br />
                    <a href=""/Admin/DonHang"">Chi tiết</a>
                </td>
            </tr>
        </table>
    </div>

    <div class=""card d-flex box col-12 col-md-3"">
        <table>
            <tr>
                <td class=""bg-primary td td1""><i class=""icon mdi mdi-human-greeting""> </i></td>
                <td class=""td"">
                    Tổng số khách hàng
                    <br />
                    (<strong>");
#nullable restore
#line 82 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                        Write(ViewBag.sokhachhang);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>)
                    <br/>
                    <a href=""/Admin/KhachHangs"">Chi tiết</a>
                </td>
            </tr>
        </table>
    </div>

    <div class=""card d-flex box col-12 col-md-3"">
        <table>
            <tr>
                <td class=""bg-info td td1""><i class=""icon mdi mdi-book-multiple""> </i></td>
                <td class=""td"">
                    Tổng số sản phẩm
                    <br />
                    (<strong>");
#nullable restore
#line 97 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                        Write(ViewBag.sosanpham);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>)
                    <br />
                    <a href=""/Admin/AdminSanPhams"">Chi tiết</a>
                </td>
            </tr>
        </table>
    </div>
    <div class=""card d-flex box col-12 col-md-3"">
        <table>
            <tr>
                <td class=""bg-success td td1""><i class=""icon mdi mdi-newspaper""> </i></td>
                <td class=""td"">
                    Tổng số tin tức
                    <br />
                    (<strong>");
#nullable restore
#line 111 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                        Write(ViewBag.sotintuc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>)
                    <br />
                    <a href=""/Admin/TinTuc"">Chi tiết</a>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class=""row mt-3"" >
    <div class=""card scroll col-12 col-md-6"" id=""piechart""></div>
    <div class=""card col-12 col-md-6 scroll"">
        <div class=""d-flex align-items-center mt-2 w-100"">
            <strong>Thống kê đơn hàng theo ngày</strong>
            <input type=""date"" class=""float-right date"" id=""date""");
            BeginWriteAttribute("value", " value=\"", 3493, "\"", 3514, 1);
#nullable restore
#line 125 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 3501, ViewBag.date, 3501, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n            <strong class=\"text-secondary ml-1\">");
#nullable restore
#line 126 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                           Write(ViewBag.date);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>
        </div>
        <hr />
        <table class=""table"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Trạng thái</th>
                    <th scope=""col"">Số lượng đơn</th>
                    <th scope=""col"">Tổng số sản phẩm</th>
                    <th scope=""col"">Tiền đơn</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row"">1</th>
                    <td class=""text-success"">Đã giao</td>
                    <td>");
#nullable restore
#line 143 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.sldagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 144 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.slspdagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 145 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.dsdagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">2</th>\r\n                    <td class=\"text-primary\">Đang giao</td>\r\n                    <td>");
#nullable restore
#line 150 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.sldanggiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 151 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.slspdanggiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 152 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.dsdanggiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">3</th>\r\n                    <td class=\"text-warning\">Chưa giao</td>\r\n                    <td>");
#nullable restore
#line 157 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.slchuagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 158 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.slspchuagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 159 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.dschuagiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">4</th>\r\n                    <td class=\"text-danger\">Đã hủy</td>\r\n                    <td>");
#nullable restore
#line 164 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.sldahuy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 165 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.slspdahuy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 166 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                   Write(ViewBag.dsdahuy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row mt-3 dhht\">\r\n    <div class=\"card scroll col-12\">\r\n        <strong class=\"mt-2\">Danh sách đơn hàng hoàn thành trong tháng (tính đến ");
#nullable restore
#line 175 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                            Write(DateTime.Now.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@") </strong>
        <hr />
        <div>
            <table class=""table"">
                <thead class=""thead-dark"">
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Mã đơn</th>
                        <th scope=""col"">Ngày đặt</th>
                        <th scope=""col"">Ngày giao</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 189 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                     if (ViewBag.dhht.Count > 0)
                    {
                        for (var i = 0; i < ViewBag.dhht.Count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th scope=\"row\">");
#nullable restore
#line 194 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                            Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <td>");
#nullable restore
#line 195 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                               Write(ViewBag.dhht[i].IddonHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 196 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                               Write(ViewBag.dhht[i].NgayDatHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 197 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                               Write(ViewBag.dhht[i].NgayGiaoHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><a");
            BeginWriteAttribute("href", " href=\"", 6468, "\"", 6530, 2);
            WriteAttributeValue("", 6475, "/Admin/AdminCtDonHangs/Index/", 6475, 29, true);
#nullable restore
#line 198 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 6504, ViewBag.dhht[i].IddonHang, 6504, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Chi tiết</a></td>\r\n                            </tr>\r\n");
#nullable restore
#line 200 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"

                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""row mt-3"">
    <div class=""card col-12 col-md-6"">
        <strong class=""mt-2"">Top sản phẩm bán chạy</strong>
        <hr />
        <div class=""table-responsive sphh"">
            <table class=""table"">
                <thead class=""thead-dark"">
                    <tr>
                        <th> Sản phẩm  </th>
                        <th> Loại </th>
                        <th> Tình trạng </th>
                        <th> Số lượng bán </th>
                        <th> Còn lại </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 226 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                     if (ViewBag.sp.Count > 0)
                    {
                        var count = ViewBag.sp.Count > 10 ? 10 : ViewBag.sp.Count;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 229 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         for (int i = 0; i < count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 7674, "\"", 7701, 2);
            WriteAttributeValue("", 7680, "/", 7680, 1, true);
#nullable restore
#line 233 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 7681, ViewBag.sp[i].Thumb, 7681, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 233 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                          Write(ViewBag.sp[i].TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td> ");
#nullable restore
#line 235 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sp[i].Cat.CatName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>\r\n                                    <label class=\"badge badge-gradient-success\">Bán chạy</label>\r\n                                </td>\r\n                                <td> ");
#nullable restore
#line 239 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sp[i].Slban);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> ");
#nullable restore
#line 240 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sp[i].UnitsInStock);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            </tr>\r\n");
#nullable restore
#line 242 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 242 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""card col-12 col-md-6"">
        <strong class=""mt-2"">Những sản phẩm còn ít hoặc hết hàng</strong>
        <hr />
        <div class=""table-responsive sphh"">
            <table class=""table"">
                <thead class=""thead-dark"">
                    <tr>
                        <th> Sản phẩm  </th>
                        <th> Loại </th>
                        <th> Tình trạng </th>
                        <th> Số lượng bán </th>
                        <th> Còn lại </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 266 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                     if (ViewBag.sphh.Count > 0)
                    {
                        var count = ViewBag.sphh.Count;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 269 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         for (int i = 0; i < count; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 9272, "\"", 9301, 2);
            WriteAttributeValue("", 9278, "/", 9278, 1, true);
#nullable restore
#line 273 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 9279, ViewBag.sphh[i].Thumb, 9279, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 273 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                            Write(ViewBag.sphh[i].TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td> ");
#nullable restore
#line 275 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sphh[i].Cat.CatName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>\r\n                                    <label class=\"badge badge-gradient-danger\">Cháy hàng</label>\r\n                                </td>\r\n                                <td> ");
#nullable restore
#line 279 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sphh[i].Slban);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> ");
#nullable restore
#line 280 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                Write(ViewBag.sphh[i].UnitsInStock);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            </tr>\r\n");
#nullable restore
#line 282 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 283 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""row mt-3"">
    <div class=""card col-12 col-md-6"">
        <strong class=""mt-2"">Những khách hàng tiềm năng</strong>
        <hr />
        <div class=""table-responsive sphh"">
            <table class=""table"">
                <thead class=""thead-dark"">
                    <tr>
                        <th> #</th>
                        <th> Khách hàng </th>
                        <th> Số điện thoại </th>
                        <th> Số đơn đã mua </th>

                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 310 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                     if (ViewBag.khtn.Count > 0)
                    {
                        var i = 1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 313 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         foreach (var item in ViewBag.khtn)
                        {
                            if (i <= 10)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th>");
#nullable restore
#line 318 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>\r\n");
#nullable restore
#line 320 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                         if (@item.kh.Avatar != null && @item.kh.Avatar != string.Empty)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <img");
            BeginWriteAttribute("src", " src=\"", 11121, "\"", 11143, 2);
            WriteAttributeValue("", 11127, "/", 11127, 1, true);
#nullable restore
#line 322 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 11128, item.kh.Avatar, 11128, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 322 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                             Write(item.kh.HoTen);

#line default
#line hidden
#nullable disable
#nullable restore
#line 322 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                                
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <img src=\"https://www.iconpacks.net/icons/2/free-user-icon-3297-thumb.png\" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 326 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                                                            Write(item.kh.HoTen);

#line default
#line hidden
#nullable disable
#nullable restore
#line 326 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                                                                               

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td> ");
#nullable restore
#line 330 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                    Write(item.kh.Sdt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td> ");
#nullable restore
#line 331 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                    Write(item.count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đơn</td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 334 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                            }
                            i++;

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 337 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
    <div class=""card col-12 col-md-6"">
        <strong class=""mt-2"">Những khách mới</strong>
        <hr />
        <div class=""table-responsive sphh"">
            <table class=""table"">
                <thead class=""thead-dark"">
                    <tr>
                        <th> #</th>
                        <th> Khách hàng </th>
                        <th> Số điện thoại </th>
                        <th> Ngày tạo </th>

                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 359 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                     if (ViewBag.khm.Count > 0)
                    {
                        var i = 1;
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 362 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         foreach (var item in ViewBag.khm)
                        {
                            if (i <= 10)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th>");
#nullable restore
#line 367 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>\r\n");
#nullable restore
#line 369 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                         if (@item.Avatar != null && @item.Avatar != string.Empty)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <img");
            BeginWriteAttribute("src", " src=\"", 13035, "\"", 13054, 2);
            WriteAttributeValue("", 13041, "/", 13041, 1, true);
#nullable restore
#line 371 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
WriteAttributeValue("", 13042, item.Avatar, 13042, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 371 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                          Write(item.HoTen);

#line default
#line hidden
#nullable disable
#nullable restore
#line 371 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                          
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <img src=\"https://www.iconpacks.net/icons/2/free-user-icon-3297-thumb.png\" class=\"mr-2\" alt=\"image\"> ");
#nullable restore
#line 375 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                                                            Write(item.HoTen);

#line default
#line hidden
#nullable disable
#nullable restore
#line 375 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                                                                                                                                            

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td> ");
#nullable restore
#line 379 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                    Write(item.Sdt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td> ");
#nullable restore
#line 380 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                                    Write(item.NgayTao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 383 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                            }
                            i++;

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 386 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
    <script type=""text/javascript"">

    $(document).ready(() => {
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Đơn hàng', 'Trạng thái'],
                ['Đang giao', ");
#nullable restore
#line 404 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         Write(ViewBag.danggiao);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Đã hủy\', ");
#nullable restore
#line 405 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                      Write(ViewBag.dahuy);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Chưa giao\', ");
#nullable restore
#line 406 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                         Write(ViewBag.chuagiao);

#line default
#line hidden
#nullable disable
                WriteLiteral("],\r\n                [\'Đã giao\', ");
#nullable restore
#line 407 "E:\_dotNetCoreMVC\BachHoa\BachHoaOnline\PTHShopping\PTHShopping\Areas\Admin\Views\Thongke\Index.cshtml"
                       Write(ViewBag.dagiao);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"],
            ]);
            var options = { 'title': ' Tỷ lệ đơn hàng trong tháng này', 'width': 500, 'height': 300 };
            var chart = new google.visualization.PieChart(document.getElementById('piechart'));
            chart.draw(data, options);
        }

        $('#date').change(() => {
            var date = $(""#date"").val().toString();
            $.ajax({
                url: '/Admin/Thongke/datecontact',
                datatype: ""json"",
                type: ""POST"",
                data: {
                    date: date
                },
                async: true,
                success: function (result) {
                    if (result.status == ""success"") {
                        window.location.href = result.redirectUrl;
                    }
                },
                error: function (xhr) {
                    alert('error')
                }
            });
        });
    });
    </script>
");
            }
            );
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
