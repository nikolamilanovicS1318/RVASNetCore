#pragma checksum "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f53cc022a93f83ab8a7cb1671f94f4bd30d0586"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_AvailableRooms), @"mvc.1.0.view", @"/Views/Room/AvailableRooms.cshtml")]
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
#line 1 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\_ViewImports.cshtml"
using RVAS_Hotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\_ViewImports.cshtml"
using RVAS_Hotel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
using System.Drawing;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f53cc022a93f83ab8a7cb1671f94f4bd30d0586", @"/Views/Room/AvailableRooms.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0f1b788e745532e7cf29cbc6d64415e51f8ee3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Room_AvailableRooms : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid h-50 w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f53cc022a93f83ab8a7cb1671f94f4bd30d05864040", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Available rooms</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f53cc022a93f83ab8a7cb1671f94f4bd30d05865223", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral("    <div class=\"container-fluid\">\r\n\r\n");
                WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 17 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
             foreach (var x in (List<Room>)ViewData["ListOfRooms"])
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-md-6 mb-4\">\r\n                    <dl class=\"dl-horizontal\">\r\n                        <dt>Room number</dt>\r\n                        <dd>");
#nullable restore
#line 23 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
                       Write(x.RoomNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</dd>\r\n                        <dt>Price</dt>\r\n                        <dd>");
#nullable restore
#line 25 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
                       Write(x.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" $</dd>\r\n                    </dl>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5f53cc022a93f83ab8a7cb1671f94f4bd30d05866755", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 942, "~/images/", 942, 9, true);
#nullable restore
#line 27 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
AddHtmlAttributeValue("", 951, x.ImageName, 951, 12, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                    <button type=\"button\" class=\"btn btn-primary mr-3 mt-4\"> ");
#nullable restore
#line 29 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
                                                                        Write(Html.ActionLink("More Details", "RoomDetails", routeValues: new { RoomID = x.RoomID }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n\r\n                </div>\r\n");
#nullable restore
#line 32 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"

            
             }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 43 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
         if (TempData["alertMessage"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <script type=\"text/javascript\">\r\n                    alert(\'");
#nullable restore
#line 46 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
                      Write(TempData["alertMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            </script>\r\n");
#nullable restore
#line 48 "C:\Users\Radovan\Desktop\RVAS PROJEKAT\SolRVAS-Hotel\RVAS-Hotel\Views\Room\AvailableRooms.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
