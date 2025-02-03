using CatApp.Components;

namespace CatApp;

public partial class DetailPage : ContentPage
{
    public Cat Cat { get; init; }

    public string CatName {
        get {
            if (Cat.breeds == null || Cat.breeds.Count == 0 || Cat.breeds[0].name == null)
                return "Unnamed";

            return Cat.breeds[0].name!;
        }
    }

    public DetailPage(Cat cat)
    {
		InitializeComponent();

        Cat = cat;

        BindingContext = this;

        if (Cat.breeds == null)
            return;

        LabelId.Text = $"Cat Id: {Cat.id}";
        LabelImageSize.Text = $"({Cat.width}x{Cat.height})";

        foreach (Breed breed in Cat.breeds) {
            Breeds.Add(new BreedItem(breed));
        }
    }

    private async void OpenImage(object sender, EventArgs e) {
        try {
            await Launcher.OpenAsync(new Uri(Cat.url));
        } catch (Exception ex) {
            await DisplayAlert("Error", "Could not open the URL.", "OK");
        }
    }
}