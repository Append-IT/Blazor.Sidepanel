using System;
namespace Append.Blazor.Sidepanel;

[Flags]
public enum BackdropType
{
    None = 0,
    /// <summary>
    /// Shows an overlay so the content not in the <see cref="Sidepanel"/> is greyed out abit.
    /// </summary>
    Overlay = 1 << 0,
    /// <summary>
    /// When the backdrop is clicked, the <see cref="Sidepanel"/> is softly closed.
    /// </summary>
    LightDismiss = 1 << 1 | Overlay,
    /// <summary>
    /// When the backdrop is clicked, the <see cref="Sidepanel"/> is closed.
    /// </summary>
    Dismiss = 1 << 2 | Overlay | LightDismiss,
}

