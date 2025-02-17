using NasaPet.APIs;
using NasaPet.APIs.URLConstants;
using NasaPet.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace NasaPet.Views;

public partial class NewsPage : ContentPage
{
    private readonly INasaHttpClient<NewsRootModel> _newsClient;
    private DateTime? _lastEventDate;
    private const int PageSize = 25;

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<NewsModel> NewsItems { get; set; } = new ObservableCollection<NewsModel>();

    public ICommand OpenEventsCommand { get; }

    public NewsPage(INasaHttpClient<NewsRootModel> newsClient)
    {
        _newsClient = newsClient;

        OpenEventsCommand = new Command<NewsModel>(async (news) =>
        {
            Console.WriteLine("OpenEventsCommand вызвана!");

            if (news == null)
            {
                Console.WriteLine("news == null");
                return;
            }

            Console.WriteLine($"Переход на EventsPage с {news.Geometries.Count} событиями");

            await Shell.Current.GoToAsync("///eventsPage", true, new Dictionary<string, object>
            {
                { "SelectedNews", news }
            });
        });


        LoadNewsPage();
        InitializeComponent();
        BindingContext = this;
    }

    protected virtual void OnPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void LoadNewsPage()
    {
        string urlParams = $"?limit={PageSize}";
        if (_lastEventDate != null)
        {
            string formattedDate = _lastEventDate.Value.ToString("yyyy-MM-dd");
            urlParams += $"&start={formattedDate}";
        }

        var newEvents = await _newsClient.GetListAsync(NasaConstants.Events, urlParams);

        if (newEvents?.Events != null && newEvents.Events.Count > 0)
        {
            foreach (var item in newEvents.Events)
            {
                NewsItems.Add(item);
            }
            _lastEventDate = NewsItems.SelectMany(item => item.Geometries).Max(geo => geo.Date);
        }
    }

    private void OnThresholdReached(object sender, EventArgs e)
    {
        LoadNewsPage();
    }
}