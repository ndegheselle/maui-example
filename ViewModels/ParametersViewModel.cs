
namespace maui_example.ViewModels
{
    public class ParametersViewModel
    {
        public bool IsOpenInBrowser
        {
            get { return Preferences.Get(nameof(IsOpenInBrowser), false); }
            set { Preferences.Set(nameof(IsOpenInBrowser), value); }
        }
    }
}
