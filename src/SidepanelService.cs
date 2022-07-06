using Microsoft.AspNetCore.Components;
namespace Append.Blazor.Sidepanel;

internal class SidepanelService : ISidepanelService
{
    /// <inheritdoc />
    public event Func<ValueTask> OnSidepanelChanged;

    /// <inheritdoc />
    public string Title { get; internal set; }

    /// <inheritdoc />
    public string Subtitle { get; internal set; }

    /// <inheritdoc />
    public Type Component { get; internal set; }

    /// <inheritdoc />
    public RenderFragment ContentToRender { get; internal set; }

    /// <inheritdoc />
    public Dictionary<string, object> Parameters { get; internal set; }

    /// <inheritdoc />
    public bool IsOpen { get; internal set; }

    /// <inheritdoc />
    public bool IsFullscreen { get; internal set; }

    /// <inheritdoc />
    public BackdropType Backdrop { get;  set; }

    public void Open(string title, RenderFragment contentToRender, string subtitle = null, Dictionary<string, object> parameters = null, BackdropType? backDrop = null)
    {
        if (contentToRender is null)
        {
            throw new NullReferenceException($"{nameof(contentToRender)} cannot be null.");
		}
        Component = null;
        IsOpen = true;
        Title = title;
        Subtitle = subtitle;
        ContentToRender = contentToRender;
        Parameters = parameters;
        Backdrop = backDrop.HasValue ? backDrop.Value : Backdrop;
        OnSidepanelChanged?.Invoke();
	}

    /// <inheritdoc />
    public void Open(string title, Type component, string subtitle = null, Dictionary<string, object> parameters = null, BackdropType? backDrop = null)
    {
        if (component is null)
            throw new NullReferenceException($"{nameof(component)} cannot be null.");

        if (!typeof(ComponentBase).IsAssignableFrom(component))
            throw new ArgumentException($"{component.FullName} must be a Blazor Component");

        IsOpen = true;
        Title = title;
        Subtitle = subtitle;
        Component = component;
        Parameters = parameters;
        Backdrop = backDrop.HasValue ? backDrop.Value : Backdrop;
        OnSidepanelChanged?.Invoke();
    }
    /// <inheritdoc />
    public void Open<TComponent>(string title, string subtitle = "", BackdropType? backDrop = null) where TComponent : IComponent
    {
        Open(title, typeof(TComponent), subtitle,null, backDrop);
    }
    /// <inheritdoc />
    public void Open<TComponent>(string title, string subtitle, Dictionary<string, object> parameters, BackdropType? backDrop = null) where TComponent : IComponent
    {
        Open(title, typeof(TComponent), subtitle, parameters, backDrop);
    }
    /// <inheritdoc />
    public void Open<TComponent>(string title, string subtitle, (string Key, object Value) parameter, BackdropType? backDrop = null) where TComponent : IComponent
    {
        var dict = new Dictionary<string, object>
            {
                { parameter.Key, parameter.Value }
            };
        Open(title, typeof(TComponent), subtitle, dict , backDrop);
    }
    /// <inheritdoc />
    public void Open<TComponent>(string title, (string Key, object Value) parameter, BackdropType? backDrop = null) where TComponent : IComponent
    {
        Open<TComponent>(title, null, parameter, backDrop);
    }
    /// <inheritdoc />
    public void Close()
    {
        IsOpen = false;
        Title = string.Empty;
        Subtitle = null;
        Component = null;
        ContentToRender = null;
        IsFullscreen = false;
        OnSidepanelChanged?.Invoke();
    }
    /// <inheritdoc />
    public void SoftClose()
    {
        IsOpen = false;
        OnSidepanelChanged?.Invoke();
    }

    public void Fullscreen()
    {
        IsFullscreen = true;
    }

    public void ExitFullscreen()
    {
        IsFullscreen = false;
    }
}
