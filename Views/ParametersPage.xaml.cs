using maui_example.Base;
using maui_example.ViewModels;

namespace maui_example.Views;

public partial class ParametersPage : ContentPage
{
    private readonly HomeViewModel _viewModel;
    public ParametersPage()
    {
        _viewModel = ServiceHelper.GetService<HomeViewModel>();
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var layout = sender as Layout;
        var check = layout.FirstOrDefault(c => c.GetType() == typeof(CheckBox));

        if (check != null)
        {
            ((CheckBox)check).IsChecked = !((CheckBox)check).IsChecked;
        }
    }

    private void RemoveAll_Clicked(object sender, EventArgs e)
    {
        _viewModel.Sites.Clear();
    }
}