﻿// <auto-generated/>
namespace BlazorApp.ComponentsIntro.Components.Pages
{
  // bunch of usings
  using global::System;
  using global::System.Collections.Generic;
  using global::System.Linq;
  using global::System.Threading.Tasks;
  using global::Microsoft.AspNetCore.Components;
  using System.Net.Http;
  using System.Net.Http.Json;
  using Microsoft.AspNetCore.Components.Forms;
  using Microsoft.AspNetCore.Components.Routing;
  using Microsoft.AspNetCore.Components.Web;
  using static Microsoft.AspNetCore.Components.Web.RenderMode;
  using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorApp.ComponentsIntro\src\BlazorApp.ComponentsIntro\Components\_Imports.razor"
  using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorApp.ComponentsIntro\src\BlazorApp.ComponentsIntro\Components\_Imports.razor"
  using BlazorApp.ComponentsIntro;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorApp.ComponentsIntro\src\BlazorApp.ComponentsIntro\Components\_Imports.razor"
  using BlazorApp.ComponentsIntro.Components;

#line default
#line hidden
#nullable disable
  [RouteAttribute("/counter")]
  public partial class Counter : ComponentBase
  {
    // Generated from the markup section

    protected override void BuildRenderTree(
      RenderTreeBuilder __builder)
    {
      __builder.OpenComponent<PageTitle>(0);
      __builder.AddAttribute(1, "ChildContent", 
      (RenderFragment)((__builder2) =>
      {
        __builder2.AddContent(2, "Counter");
      }
      ));
      __builder.CloseComponent();
      __builder.AddMarkupContent(3, "\r\n\r\n");
      __builder.AddMarkupContent(4, "<h1>Counter</h1>\r\n\r\n");
      __builder.OpenElement(5, "p");
      __builder.AddAttribute(6, "role", "status");
      __builder.AddContent(7, "Current count: ");
      __builder.AddContent(8, currentCount);
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\r\n\r\n");
      __builder.OpenElement(10, "button");
      __builder.AddAttribute(11, "class", "btn btn-primary");
      __builder.AddAttribute(12, "onclick", 
        EventCallback.Factory.Create<MouseEventArgs>(
        this, IncrementCount
      ));
      __builder.AddContent(13, "Click me");
      __builder.CloseElement();
    }

    // Copied from the @code section

    private int currentCount = 0;

    private void IncrementCount()
    {
      currentCount++;
    }
  }
}
