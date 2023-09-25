using CommunityToolkit.Maui.Views;
using maui_example.Base;
using maui_example.ViewModels;
using System;
using System.Diagnostics;

namespace maui_example.Views.Home;

public partial class SiteDisplay : ContentView
{
    // Could have used the BindindContext directly instead, but it show how to use BindableProperty
    #region Properties

    public static readonly BindableProperty DataProperty = BindableProperty.Create("Data", typeof(SiteData), typeof(SiteDisplay), null, propertyChanged: OnDataChanged);
    public SiteData Data
    {
        get => (SiteData)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }
    static void OnDataChanged(BindableObject bindable, object oldValue, object newValue)
    {
        SiteDisplay siteDisplay = (SiteDisplay)bindable;
        siteDisplay.BindingContext = siteDisplay.Data;
    }

    private HomeViewModel _HomeViewModel { get; }
    private ParametersViewModel _ParamsViewModel { get; }

    #endregion

    public SiteDisplay()
    {
        _HomeViewModel = ServiceHelper.GetService<HomeViewModel>();
        _ParamsViewModel = ServiceHelper.GetService<ParametersViewModel>();
        InitializeComponent();
    }

    private void Open_Clicked(object sender, EventArgs e)
    {
        if (_ParamsViewModel.IsOpenInBrowser)
        {
            Browser.Default.OpenAsync(new Uri(Data.Url), BrowserLaunchMode.SystemPreferred);
        }
        else
        {
            // Wanted to use Navigation and BackButtonBehavior, but I can't make it work (Shell is a pain <3)
            _HomeViewModel.OpenWebView(Data.Url);
        }
    }
}