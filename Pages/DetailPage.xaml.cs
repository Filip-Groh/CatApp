namespace CatApp;

public partial class DetailPage : ContentPage
{
    public string CatId { get; set; }
    public DetailPage(string id)
    {
		InitializeComponent();

        CatId = id;

        BindingContext = this;
    }
}