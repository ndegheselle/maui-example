using CommunityToolkit.Maui.Views;
using maui_example.Base;
using maui_example.ViewModels;

namespace maui_example;

public partial class MySimplePopup : Popup
{
    public MySimplePopup(string url)
    {
        Content = new WebView()
        {
            Source = url
        };
    }
}

public partial class MainPage : ContentPage
{
    private readonly HomeViewModel _ViewModel;
    public MainPage(HomeViewModel viewModel)
    {
        _ViewModel = viewModel;
        _ViewModel.OnOpenWebView += ViewModel_OnOpenWebView;
        InitializeComponent();
        this.BindingContext = _ViewModel;
    }

    private void ViewModel_OnOpenWebView(string url)
    {
        var popup = new MySimplePopup(url);
        this.ShowPopup(popup);
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var btn = sender as ImageButton;
        if (string.IsNullOrEmpty(InputAjouterSite.Text)) return;

        _ViewModel.Sites.Add(new SiteData(InputAjouterSite.Text));
        InputAjouterSite.Text = "";

        await btn.ScaleTo(0.8, 100, Easing.CubicOut);
        await btn.ScaleTo(1, 100, Easing.CubicIn);
    }

    private void RemoveItem_Tapped(object sender, TappedEventArgs e)
    {
        var item = sender as VisualElement;
        var site = item.BindingContext as SiteData;

        if (site == null) return;

        _ViewModel.Sites.Remove(site);
    }
}