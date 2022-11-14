using CommunityToolkit.Mvvm.ComponentModel;

namespace Christmas.ViewModel;

public partial class AboutViewModel : BaseViewModel
{
    [ObservableProperty]
    private string heading;

    [ObservableProperty]
    private string subHeading;

    [ObservableProperty]
    private List<FontImageSource> carousel;

    [ObservableProperty]
    private ImageSource leftImage;

    [ObservableProperty]
    private ImageSource rightImage;

    [ObservableProperty]
    private List<string> content;

    public AboutViewModel()
    {
        Title = "About";

        Heading = "Happy Christmas!";

        SubHeading = "Azyra Christmas Party App 2022";

        object color;
        Color red = Colors.Black;
        if (Application.Current.Resources.TryGetValue("Red", out color))
        {
            red = (Color)color;
        }

        Color green = Colors.Black;
        if (Application.Current.Resources.TryGetValue("Green", out color))
        {
            green = (Color)color;
        }

        Carousel = new List<FontImageSource>()
        {
            new FontImageSource
            {
            FontFamily = "FontAwesome-Solid",
            Glyph = "\uf06b",
            Color = red,
            },
            new FontImageSource
            {
            FontFamily = "FontAwesome-Solid",
            Glyph = "\uf7cc",
            Color = green,
            },
            new FontImageSource
            {
            FontFamily = "FontAwesome-Solid",
            Glyph = "\uf786",
            Color = red,
            }
        };

        LeftImage = new FontImageSource
        {
            FontFamily = "FontAwesome-Solid",
            Glyph = "\uf120",
            Color = Colors.Black,
        };

        RightImage = new FontImageSource
        {
            FontFamily = "FontAwesome-Solid",
            Glyph = "\uf121",
            Color = Colors.Black,
        };

        Content = new List<string>()
        {
            "Written in C# and .NET MAUI by Ian Kavanagh.",
            "Designed by Ian Kavanagh and Ali Ryan.",
            "Icons designed by Ali Ryan."
        };
    }
}
