using Microsoft.AspNetCore.Components;
namespace Append.Blazor.Sidepanel;

public interface ISidepanelService
{
    event Func<ValueTask> OnSidepanelChanged;
    bool IsOpen { get; }
    string Title { get; }
    string Subtitle { get; }
    Type Component { get; }
    Dictionary<string, object> Parameters { get; }
    void Open(string title, Type component, string subtitle = null, Dictionary<string, object> parameters = null);
    void Open<TComponent>(string title, (string Key, object Value) parameter) where TComponent : IComponent;
    void Open<TComponent>(string title, string subtitle = "") where TComponent : IComponent;
    void Open<TComponent>(string title, string subtitle, (string Key, object Value) parameter) where TComponent : IComponent;
    void Open<TComponent>(string title, string subtitle, Dictionary<string, object> parameters) where TComponent : IComponent;
    void SoftClose();
    void Close();
}
