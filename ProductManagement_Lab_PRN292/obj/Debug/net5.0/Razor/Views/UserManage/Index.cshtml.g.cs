#pragma checksum "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b701f1f235586e9c7d965e8781b3f69e96741376"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserManage_Index), @"mvc.1.0.view", @"/Views/UserManage/Index.cshtml")]
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
#line 1 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\_ViewImports.cshtml"
using ProductManagement_Lab_PRN292;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\_ViewImports.cshtml"
using ProductManagement_Lab_PRN292.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b701f1f235586e9c7d965e8781b3f69e96741376", @"/Views/UserManage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d372d8b634ee201433f3e962e1beff04bbc925b4", @"/Views/_ViewImports.cshtml")]
    public class Views_UserManage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductManagement_Lab_PRN292.Models.UserManageViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b701f1f235586e9c7d965e8781b3f69e967413763955", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>

            <th>
                User Name
            </th>
            <th>
                Full Name
            </th>
            <th>
                Email
            </th>
            <th>
                Phone Number
            </th>
            <th>
                Age
            </th>
");
            WriteLiteral("            <th>\r\n                Status\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 49 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
                                                             Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 59 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
                      
                        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        int dob = int.Parse(item.Dob.ToString("yyyyMMdd"));
                        int age = (now - dob) / 10000;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 65 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 68 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
                      
                        string Status = "";

                        if (item.Lockout)
                        {
                            Status = "Suspended";
                        }
                        else { Status = "Active"; }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 77 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 82 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 83 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 84 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 87 "C:\Users\lehuuhieu\Desktop\Semester 5\PRN292\ProductManagement_Lab_PRN292\ProductManagement_Lab_PRN292\Views\UserManage\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductManagement_Lab_PRN292.Models.UserManageViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
