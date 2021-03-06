#pragma checksum "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "726a4b260dd371bdcd14862dc8b527cabbe44880"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProjectAccesses_Index), @"mvc.1.0.view", @"/Views/ProjectAccesses/Index.cshtml")]
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
#line 1 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\_ViewImports.cshtml"
using BTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\_ViewImports.cshtml"
using BTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"726a4b260dd371bdcd14862dc8b527cabbe44880", @"/Views/ProjectAccesses/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0cc924b9a90ceafa5488ccd612c60c3c751c630", @"/Views/_ViewImports.cshtml")]
    public class Views_ProjectAccesses_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BTracker.Models.Views.ProjectSectionAndTicketsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var projectName = Model.Project.ProjectName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 11 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
Write(Html.ActionLink("Create New", "Create", "ProjectAccesses", new { id = ViewBag.currentProjectId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                User
            </th>
            <th>
                Project name
            </th>
            <th>
                Access level
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 29 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
 foreach (var item in Model.ProjectAccesses) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(projectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.AccessLevel.AccessName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(Html.ActionLink("Edit |", "Edit", "ProjectAccesses", new { id = Model.Project.ProjectId, projectAccessId = item.ProjectAccessId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 42 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(Html.ActionLink("Details |", "Details", "ProjectAccesses", new { id = Model.Project.ProjectId, projectAccessId = item.ProjectAccessId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 43 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", "ProjectAccesses", new { id = Model.Project.ProjectId, projectAccessId = item.ProjectAccessId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 46 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\ProjectAccesses\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BTracker.Models.Views.ProjectSectionAndTicketsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
