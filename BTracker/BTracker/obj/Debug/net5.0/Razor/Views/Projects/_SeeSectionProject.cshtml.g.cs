#pragma checksum "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69d746143cdd99580997aff22b60f6f46a3e039d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects__SeeSectionProject), @"mvc.1.0.view", @"/Views/Projects/_SeeSectionProject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69d746143cdd99580997aff22b60f6f46a3e039d", @"/Views/Projects/_SeeSectionProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0cc924b9a90ceafa5488ccd612c60c3c751c630", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects__SeeSectionProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BTracker.Models.Section>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight: 600"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddTicketDueDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tickets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveAssignSectionUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
  
    var pageName = ViewData["Title"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
 if (pageName == "List")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div id=""accordion"" class=""m-b-20"">
        <div class=""card"" style=""border: none;"">
            <div class=""card-header dis-flex"" style=""flex-direction: row; padding: 0; align-items: center; justify-items: flex-start; width: auto; background-color: #F0EFF3; border: none""");
            BeginWriteAttribute("id", " id=\"", 398, "\"", 428, 3);
            WriteAttributeValue("", 403, "heading-", 403, 8, true);
#nullable restore
#line 10 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
WriteAttributeValue("", 411, Model.SectionId, 411, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 427, "", 428, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h5 class=\"mb-0 col-8 p-l-20\">\r\n                    <a class=\"btn\" style=\"font-size: 18px; font-weight: 600; color: #150940; border: 1px solid #150940; border-radius: 5px;\" data-toggle=\"collapse\"");
            BeginWriteAttribute("href", " href=\"", 643, "\"", 676, 2);
            WriteAttributeValue("", 650, "#collapse-", 650, 10, true);
#nullable restore
#line 12 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
WriteAttributeValue("", 660, Model.SectionId, 660, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" aria-expanded=\"false\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 713, "\"", 754, 2);
            WriteAttributeValue("", 729, "collapse-", 729, 9, true);
#nullable restore
#line 12 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
WriteAttributeValue("", 738, Model.SectionId, 738, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
#nullable restore
#line 13 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                   Write(Html.DisplayFor(model => model.SectionName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </h5>\r\n");
#nullable restore
#line 16 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                 if (Model.ToUserId == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"txt1 col-1 text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d746143cdd99580997aff22b60f6f46a3e039d8081", async() => {
                WriteLiteral("Assign Section User");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                                                             WriteLiteral(Model.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                                                                                                    WriteLiteral(Model.SectionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sectionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                                                                                                                                       WriteLiteral(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["place"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-place", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["place"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 21 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"txt1\">\r\n                        Assigned To: ");
#nullable restore
#line 25 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                Write(Html.DisplayFor(model => model.ToUser.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d746143cdd99580997aff22b60f6f46a3e039d13020", async() => {
                WriteLiteral("\r\n                        <button type=\"submit\" name=\"button\">Remove Assigned User</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                               WriteLiteral(Model.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                                                                      WriteLiteral(Model.SectionId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["sectionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sectionId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["sectionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                                                                                                         WriteLiteral(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["place"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-place", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["place"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 30 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <div");
            BeginWriteAttribute("id", " id=\"", 1844, "\"", 1874, 2);
            WriteAttributeValue("", 1849, "collapse-", 1849, 9, true);
#nullable restore
#line 33 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
WriteAttributeValue("", 1858, Model.SectionId, 1858, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse hide\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1897, "\"", 1939, 2);
            WriteAttributeValue("", 1915, "heading-", 1915, 8, true);
#nullable restore
#line 33 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
WriteAttributeValue("", 1923, Model.SectionId, 1923, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#accordion\">\r\n                <div class=\"card-body\" style=\"background-color: #F0EFF3;\">\r\n");
#nullable restore
#line 35 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                     foreach (var ticket in Model.Tickets)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                   Write(await Html.PartialAsync("_SeeTicketSection", ticket));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                                                                             ;  
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        ");
#nullable restore
#line 40 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                   Write(Html.ActionLink("Add ticket", "Create", "Tickets", new { id = Model.ProjectId, sectionId = Model.SectionId, place = ViewData["Title"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 41 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                   Write(Html.ActionLink("Change Section Name", "Edit", "Sections", new { id = Model.ProjectId, sectionId = Model.SectionId, place = ViewData["Title"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 42 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
                   Write(Html.ActionLink("Delete section", "Delete", "Sections", new { id = Model.ProjectId, sectionId = Model.SectionId, place = ViewData["Title"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 48 "C:\Dev\Programs\BTracker\BTracker\BTracker\Views\Projects\_SeeSectionProject.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BTracker.Models.Section> Html { get; private set; }
    }
}
#pragma warning restore 1591
