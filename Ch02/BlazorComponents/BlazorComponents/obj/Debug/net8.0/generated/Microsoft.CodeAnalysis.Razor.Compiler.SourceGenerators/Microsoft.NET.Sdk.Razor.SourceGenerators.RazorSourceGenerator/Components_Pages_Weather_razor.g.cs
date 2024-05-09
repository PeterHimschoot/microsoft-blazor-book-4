﻿#pragma checksum "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d1de8649866c4fc96f4b08adf47fdf093999d9365efef5a3e30e507a5eb65558"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorComponents.Components.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using static Microsoft.AspNetCore.Components.Web.RenderMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using BlazorComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\_Imports.razor"
using BlazorComponents.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/weather")]
    public partial class Weather : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Web.PageTitle>(0);
            __builder.AddAttribute(1, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(2, "Weather");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n\r\n");
            __builder.AddMarkupContent(4, "<h1>Weather</h1>\r\n\r\n");
            __builder.AddMarkupContent(5, "<p>This component demonstrates showing data.</p>");
#nullable restore
#line 9 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
 if (forecasts == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p><em>Loading...</em></p>");
#nullable restore
#line 12 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "table");
            __builder.AddAttribute(8, "class", "table");
            __builder.AddMarkupContent(9, "<thead><tr><th>Date</th>\r\n                <th>Temp. (C)</th>\r\n                <th>Temp. (F)</th>\r\n                <th>Summary</th></tr></thead>\r\n        ");
            __builder.OpenElement(10, "tbody");
#nullable restore
#line 25 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
             foreach (var forecast in forecasts)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "tr");
            __builder.OpenElement(12, "td");
#nullable restore
#line (28,26)-(28,59) 25 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
__builder.AddContent(13, forecast.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                    ");
            __builder.OpenElement(15, "td");
#nullable restore
#line (29,26)-(29,47) 25 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
__builder.AddContent(16, forecast.TemperatureC);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                    ");
            __builder.OpenElement(18, "td");
#nullable restore
#line (30,26)-(30,47) 25 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
__builder.AddContent(19, forecast.TemperatureF);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                    ");
            __builder.OpenElement(21, "td");
#nullable restore
#line (31,26)-(31,42) 25 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
__builder.AddContent(22, forecast.Summary);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 33 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 36 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "C:\Code\GitHub\microsoft-blazor-book-4\Ch02\BlazorComponents\BlazorComponents\Components\Pages\Weather.razor"
       
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();
    }

    private class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
