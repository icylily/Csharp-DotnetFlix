#pragma checksum "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4eb5ac2e6c916e9a49ca12ecbba6a7956162e2d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\_ViewImports.cshtml"
using DotnetFlix;

#line default
#line hidden
#line 2 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\_ViewImports.cshtml"
using DotnetFlix.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4eb5ac2e6c916e9a49ca12ecbba6a7956162e2d8", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eef0b26d12b4ca70b412c7e0ec0891e47d05507", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dashboard>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 569, true);
            WriteLiteral(@"<div class = ""row  align-items-end"">
    <div class = ""col-md-4 text-left"" > <h1>Dot Net Flix</h1></div>
    <div class = ""col-md-4 align-text-top text-center"" >  </div>
    <div class = ""col-md-4 text-center "" ></div>
</div>
<div class = ""row  align-items-end"">
    <div class = ""col-md-4 text-left"" ></div>
    <div class = ""col-md-4 align-text-top text-center"" >  </div>
    <div class = ""col-md-4 text-center "" ><a href=""/Movies"">Movies</a> | <a href=""javascript:if(confirm('Do you want to log out?'))location='/logout'"">Log out </a></div>
</div>

<hr>
");
            EndContext();
            BeginContext(587, 29, true);
            WriteLiteral("\r\n<h2>Status</h2>\r\n<h4>Name: ");
            EndContext();
            BeginContext(617, 27, false);
#line 16 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
     Write(Model.CurrentUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(644, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(646, 26, false);
#line 16 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
                                  Write(Model.CurrentUser.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(672, 32, true);
            WriteLiteral("</h4>\r\n<h4># of watched Movies: ");
            EndContext();
            BeginContext(705, 19, false);
#line 17 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
                    Write(Model.WatchedMovies);

#line default
#line hidden
            EndContext();
            BeginContext(724, 22, true);
            WriteLiteral("</h4>\r\n<h4>Join Date: ");
            EndContext();
            BeginContext(747, 49, false);
#line 18 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
          Write(Model.CurrentUser.CreatedAt.ToString("M/dd/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(796, 66, true);
            WriteLiteral("</h4>\r\n\r\n<br>\r\n<br>\r\n<br>\r\n\r\n<h2>Movie current Checked out:</h2>\r\n");
            EndContext();
#line 25 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
 foreach (var movie in Model.CurrentCheckedout)
{

#line default
#line hidden
            BeginContext(914, 9, true);
            WriteLiteral("   <h5><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 923, "\"", 952, 2);
            WriteAttributeValue("", 930, "/Movies/", 930, 8, true);
#line 27 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 938, movie.MovieId, 938, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(953, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(955, 11, false);
#line 27 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
                                   Write(movie.Title);

#line default
#line hidden
            EndContext();
            BeginContext(966, 9, true);
            WriteLiteral("</a> | <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 975, "\"", 1011, 2);
            WriteAttributeValue("", 982, "/Movies/return/", 982, 15, true);
#line 27 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 997, movie.MovieId, 997, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1012, 19, true);
            WriteLiteral(">Return</a></h5> \r\n");
            EndContext();
#line 28 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\DotnetFlix\Views\Home\Dashboard.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dashboard> Html { get; private set; }
    }
}
#pragma warning restore 1591
