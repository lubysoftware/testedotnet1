#pragma checksum "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6156afefdc6d0508896a6a5e2dacbc6e353059f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Token_Index), @"mvc.1.0.view", @"/Views/Token/Index.cshtml")]
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
#line 1 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\_ViewImports.cshtml"
using ApiRestWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\_ViewImports.cshtml"
using ApiRestWebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6156afefdc6d0508896a6a5e2dacbc6e353059f3", @"/Views/Token/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20b21659cbba9f8814b54bab62fe856c9b543ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Token_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApiRestWebClient.Models.ViewModels.TokenViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
  
    ViewData["Title"] = "TOKEN";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n        <table id=\"token\" name=\"token\" class=\"table table-responsive table-hover table-striped\">\r\n\r\n            <thead>\r\n                <tr>\r\n                    <th>");
#nullable restore
#line 15 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 16 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Token));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </thead>\r\n\r\n            <tbody>\r\n                <tr>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
                   Write(Model.User);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><label>");
#nullable restore
#line 23 "C:\Users\Santi\source\repos\SantiSjp\testedotnet1\ApiRestDevs\ApiRestWebClient\Views\Token\Index.cshtml"
                          Write(Model.Token);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n                </tr>\r\n            </tbody>\r\n\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApiRestWebClient.Models.ViewModels.TokenViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
