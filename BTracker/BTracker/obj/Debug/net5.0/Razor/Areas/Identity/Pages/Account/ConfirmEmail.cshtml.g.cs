#pragma checksum "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20346db7e07bdcfe0542b2578a6dd774fe07a5c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_ConfirmEmail), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
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
#line 1 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\_ViewImports.cshtml"
using BTracker.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\_ViewImports.cshtml"
using BTracker.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using BTracker.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20346db7e07bdcfe0542b2578a6dd774fe07a5c3", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc240fb592f2d489b2090f71ceb9c745c5a0f935", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12330f07399dd8eabe649cde74a3611b84abb669", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Confirm email";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""limiter"">
    <div class=""container-login100"">
        <div class=""wrap-login100"">
            <span class=""login100-form-title p-b-26"">
                Confirm email
            </span>
            <div class=""text-center"">
                <span class=""txt1 text"">
                    <b>");
#nullable restore
#line 15 "C:\Dev\Programs\BTracker\BTracker\BTracker\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
                  Write(Html.ActionLink("Log in", "Account", "Identity", new { id = "Login" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConfirmEmailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel>)PageContext?.ViewData;
        public ConfirmEmailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591