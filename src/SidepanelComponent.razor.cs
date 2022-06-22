using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.Blazor.Sidepanel;

public partial class SidepanelComponent : ComponentBase, IDisposable
{
    [Inject] public ISidepanelService Sidepanel { get; set; }

    /// <summary>
    /// Inner content to be rendered in the <see cref="Sidepanel"/>/.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// The main title of the <see cref="Sidepanel"/>.
    /// </summary>
    [Parameter] public string Title { get; set; }

    /// <summary>
    /// Optional Subtitle of the <see cref="Sidepanel"/> rendered next to the title.
    /// </summary>
    [Parameter] public string SubTitle { get; set; }

    public void Open()
    {
        Sidepanel.Open(Title, ChildContent, SubTitle);
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
