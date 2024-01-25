using Microsoft.AspNetCore.Components;
namespace Append.Blazor.Sidepanel;

public interface ISidepanelService
{
    /// <summary>
    /// Event fired when the visibility of the <see cref="Sidepanel"/> Changes.
    /// </summary>
    event Func<ValueTask> OnSidepanelChanged;

    /// <summary>
    /// Indicator if the <see cref="Sidepanel"/> is open or not.
    /// </summary>
    bool IsOpen { get; }

    /// <summary>
    /// Indicator if the <see cref="Sidepanel"/> is fullscreen or not.
    /// </summary>
    bool IsFullscreen { get; }

    /// <summary>
    /// The title of the <see cref="Sidepanel"/>.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// An optional smaller subtitle rendered next to the title.
    /// </summary>
    string? Subtitle { get; }

    /// <summary>
    /// Optionally a backdrop, by default there is no backdrop and no light dismiss
    /// </summary>
    BackdropType Backdrop { get; internal set; }

    /// <summary>
    /// Type of the component to be rendered, it cannot be null when using the service.
    /// </summary>
    Type? Component { get; }

    /// <summary>
    /// When using a <see cref="SidepanelComponent"/> the inner ChildContent to be rendered, it cannot be null when using the <see cref="SidepanelComponent"/>.
    /// </summary>
    RenderFragment? ContentToRender { get; }

    /// <summary>
    /// When using the <see cref="ISidepanelService"/> the optional parameters you want to pass to the Child Component.
    /// </summary>
	Dictionary<string, object>? Parameters { get; }

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a strongly typed function of parameters.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="parameterBuilder"></param>
    void Open<TComponent>(string title, Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder) where TComponent : IComponent;

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a strongly typed function of parameters.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="subtitle"></param>
    /// <param name="parameterBuilder"></param>
    void Open<TComponent>(string title,string subtitle, Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder) where TComponent : IComponent;

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a dictionary of parameters.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="component"></param>
    /// <param name="subtitle"></param>
    /// <param name="parameters">Addtional parameters to pass through the child component</param>
    void Open(string title, Type component, string? subtitle = null, Dictionary<string, object>? parameters = null, BackdropType? backDrop = null);

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="RenderFragment"/>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="contentToRender"></param>
    /// <param name="subtitle"></param>
    /// <param name="parameters">Addtional parameters to pass through the child component</param>
	void Open(string title, RenderFragment contentToRender, string? subtitle = null, Dictionary<string, object>? parameters = null, BackdropType? backDrop = null);

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a single parameter as Tuple.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="parameter"></param>
    void Open<TComponent>(string title, (string Key, object Value) parameter, BackdropType? backDrop = null) where TComponent : IComponent;

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="subtitle"></param>
    void Open<TComponent>(string title, string subtitle = "", BackdropType? backDrop = null) where TComponent : IComponent;

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a single parameter as Tuple.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="subtitle"></param>
    /// <param name="parameter"></param>
    void Open<TComponent>(string title, string subtitle, (string Key, object Value) parameter, BackdropType? backDrop = null) where TComponent : IComponent;

    /// <summary>
    /// Opens the <see cref="Sidepanel"/> using a <see cref="IComponent"/> with a dictionary of parameters.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title"></param>
    /// <param name="subtitle"></param>
    /// <param name="parameters"></param>
    void Open<TComponent>(string title, string subtitle, Dictionary<string, object> parameters, BackdropType? backDrop = null) where TComponent : IComponent;

    /// <summary>
    /// Closes the <see cref="Sidepanel"/> softly, meaning the render is kept intact, for example when using a Form and still preserving the state of the inner render.
    /// </summary>
    void SoftClose();

    /// <summary>
    /// Closes the <see cref="Sidepanel"/> and cleans-up the inner render.
    /// </summary>
    void Close();

    /// <summary>
    /// Changes the width of the sidepanel to fullscreen
    /// </summary>
    void Fullscreen();

    /// <summary>
    /// Changes the width of the sidepanel to the original size.
    /// </summary>
    void ExitFullscreen();
}
