using CommunityToolkit.Maui.Views;
using maui_example.ViewModels;

namespace maui_example.Views.Home;

public partial class SiteDisplay : ContentView
{
    public static readonly BindableProperty DataProperty = BindableProperty.Create("Data", typeof(SiteData), typeof(SiteDisplay), null);
    public SiteData Data
    {
        get => (SiteData)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    public SiteDisplay()
    {
        this.BindingContext = Data;
        InitializeComponent();
    }
}