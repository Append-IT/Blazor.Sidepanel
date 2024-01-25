using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.Blazor.Sidepanel;

public partial class SidepanelComponent : ComponentBase, IDisposable
{
    [Inject] public ISidepanelService Sidepanel { get; set; } = default!;

    /// <summary>
    /// Inner content to be rendered in the <see cref="Sidepanel"/>/.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// The main title of the <see cref="Sidepanel"/>.
    /// </summary>
    [Parameter] public string Title { get; set; } = default!;

    /// <summary>
    /// Optional Subtitle of the <see cref="Sidepanel"/> rendered next to the title.
    /// </summary>
    [Parameter] public string? SubTitle { get; set; }

    /// <summary>
    /// Optional <see cref="BackdropType"/>
    /// </summary>
    [Parameter] public BackdropType? Backdrop { get; set; }

    public void Open()
    {
        Sidepanel.Open(Title, ChildContent, SubTitle, backDrop:Backdrop);
    }

    public void Close()
    {
        Sidepanel.Close();
    }

    public void SoftClose()
    {
        Sidepanel.SoftClose();
    }

    public void Dispose()
    {
        Sidepanel.Close();
    }
}
