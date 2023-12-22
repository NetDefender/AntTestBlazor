using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace AntTestBlazor.Components.Pages;

public sealed partial class Error
{
    [CascadingParameter]
    private HttpContext? _httpContext { get; set; }

    private string _requestId { get; set; }
    private bool _showRequestId => !string.IsNullOrEmpty(_requestId);

    protected override void OnInitialized() =>
        _requestId = Activity.Current?.Id ?? _httpContext?.TraceIdentifier;
}
