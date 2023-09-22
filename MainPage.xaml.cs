using maui_example.Base;
using maui_example.ViewModels;

namespace maui_example;

public partial class MainPage : ContentPage
{
    private readonly HomeViewModel _viewModel;
    public MainPage()
    {
        _viewModel = ServiceHelper.GetService<HomeViewModel>();
        InitializeComponent();
        this.BindingContext = _viewModel;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var btn = sender as ImageButton;
        if (string.IsNullOrEmpty(InputAjouterSite.Text)) return;

        _viewModel.Sites.Add(new SiteData(InputAjouterSite.Text));
        InputAjouterSite.Text = "";

        await btn.ScaleTo(0.8, 100, Easing.CubicOut);
        await btn.ScaleTo(1, 100, Easing.CubicIn);
    }

    private void RemoveItem_Tapped(object sender, TappedEventArgs e)
    {
        var item = sender as VisualElement;
        var site = item.BindingContext as SiteData;

        if (site == null) return;

        _viewModel.Sites.Remove(site);
    }
}