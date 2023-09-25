using maui_example.Base;
using maui_example.ViewModels;

namespace maui_example.Views;

public partial class ParametersPage : ContentPage
{
    private readonly HomeViewModel _HomeViewModel;
    private readonly ParametersViewModel _ParamsViewModel;

    public ParametersPage(HomeViewModel homeViewModel, ParametersViewModel parametersViewModel)
    {
        _HomeViewModel = homeViewModel;
        _ParamsViewModel = parametersViewModel;
        this.BindingContext = _ParamsViewModel;
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
        _HomeViewModel.Sites.Clear();
    }
}