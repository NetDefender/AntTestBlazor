using AntDesign.ProLayout;

namespace AntTestBlazor.Client.Layout;

public sealed partial class MainLayout
{
    private readonly MenuDataItem[] _routes =
    [
        new MenuDataItem { Path = "/", Name = "Home", Key = "Home", Icon = "smile" },
        new MenuDataItem { Path = "/Counter", Name = "Counter", Key = "Counter", Icon = "smile"},
        new MenuDataItem { Path = "/Weather", Name = "Weather", Key = "Weather", Icon = "smile"}
    ];
}