using NasaPet.Models;

namespace NasaPet.Views;

[QueryProperty(nameof(SelectedNews), "SelectedNews")]
public partial class EventsPage : ContentPage
{
    private NewsModel _selectedNews;
    public NewsModel SelectedNews
    {
        get => _selectedNews;
        set
        {
            _selectedNews = value;
            OnPropertyChanged(nameof(SelectedNews));
        }
    }

    public EventsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
