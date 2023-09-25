using System.Collections.ObjectModel;
using System.Linq;

namespace maui_example.ViewModels
{
    public class SiteData
    {
        public string Url { get; set; }
        public string UrlImage { get; set; }
        public string Nom { get; set; }

        public SiteData()
        {
        }

        public SiteData(string url)
        {
            Url = url;
            UrlImage = $"https://t0.gstatic.com/faviconV2?client=SOCIAL&type=FAVICON&fallback_opts=TYPE,SIZE,URL&url={Url}&size=64";
            Nom = new Uri(Url).Host;
        }
    }

    public partial class HomeViewModel
    {
        public string RegexWebSite { get; set; } = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        public ObservableCollection<SiteData> Sites { get; set; } = new ObservableCollection<SiteData>();

        public HomeViewModel()
        {
            LoadSites();
            Sites.CollectionChanged += (s, e) => SaveSites();
        }

        public event Action<string> OnOpenWebView;
        public void OpenWebView(string url)
        {
            OnOpenWebView?.Invoke(url);
        }

        private void SaveSites()
        {
            Preferences.Set(nameof(Sites), String.Join(";", Sites.Select(x => x.Url)));
        }

        private void LoadSites()
        {
            var urls = Preferences.Get(nameof(Sites), "").Split(";", StringSplitOptions.RemoveEmptyEntries);
            Sites.Clear();
            foreach (var url in urls)
            {
                Sites.Add(new SiteData(url));
            }
        }
    }
}
