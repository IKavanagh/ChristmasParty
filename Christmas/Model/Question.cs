using CommunityToolkit.Mvvm.ComponentModel;

namespace Christmas.Model;

public partial class Question : ObservableObject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Answer { get; set; }

    public FontImageSource Glyph => new FontImageSource
    {
        FontFamily = "FontAwesome-Solid",
        Glyph = isExpanded ? "\uf077" : "\uf078",
        Color = Colors.Black
    };

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Glyph))]
    private bool isExpanded;
}
