using CommunityToolkit.Mvvm.ComponentModel;

namespace Christmas.Model;

public partial class Question : ObservableObject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Answer { get; set; }

    public FontImageSource ExpandIcon { get; init; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ExpandIcon))]
    private bool isExpanded;

    public Question()
    {
        ExpandIcon = new FontImageSource()
        {
            FontFamily = "FontAwesome-Solid",
            Glyph = isExpanded ? "\uf077" : "\uf078",
        };
        ExpandIcon.SetAppThemeColor(FontImageSource.ColorProperty, Colors.Black, Colors.White);
    }
}
