#pragma checksum "C:\A_Workarea\Repository_Git\dot-net-stack\gleac-demo-on-ld\Gleac.Anand.Web.Levenshtein.Distance\Gleac.Anand.Web.App.Levenshtein.Distance\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3d971dc2facd7bb2f8a277537c2f90a0fe9c921"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
#line 1 "C:\A_Workarea\Repository_Git\dot-net-stack\gleac-demo-on-ld\Gleac.Anand.Web.Levenshtein.Distance\Gleac.Anand.Web.App.Levenshtein.Distance\Views\_ViewImports.cshtml"
using Gleac.Anand.Web.App.Levenshtein.Distance;

#line default
#line hidden
#line 2 "C:\A_Workarea\Repository_Git\dot-net-stack\gleac-demo-on-ld\Gleac.Anand.Web.Levenshtein.Distance\Gleac.Anand.Web.App.Levenshtein.Distance\Views\_ViewImports.cshtml"
using Gleac.Anand.Web.App.Levenshtein.Distance.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3d971dc2facd7bb2f8a277537c2f90a0fe9c921", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f251d3bc9973659823948932b5a7f75287268866", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\A_Workarea\Repository_Git\dot-net-stack\gleac-demo-on-ld\Gleac.Anand.Web.Levenshtein.Distance\Gleac.Anand.Web.App.Levenshtein.Distance\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(41, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(46, 17, false);
#line 4 "C:\A_Workarea\Repository_Git\dot-net-stack\gleac-demo-on-ld\Gleac.Anand.Web.Levenshtein.Distance\Gleac.Anand.Web.App.Levenshtein.Distance\Views\Home\About.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(63, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
            BeginContext(105, 474, true);
            WriteLiteral(@"
<p>
    The Levenshtein distance is a number that tells you how different two strings are. The higher the number, the more different the two strings are.

    For example, the Levenshtein distance between “kitten” and “sitting” is 3 since, at a minimum, 3 edits are required to change one into the other.

    kitten → sitten (substitution of “s” for “k”)
    sitten → sittin (substitution of “i” for “e”)
    sittin → sitting (insertion of “g” at the end).
</p>
");
            EndContext();
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
