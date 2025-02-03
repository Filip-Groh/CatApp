namespace CatApp.Components;

public partial class BreedItem : ContentView
{
	public Breed Breed { get; init; }
    public string BreedWeight {
        get {
            return $"Weight: {Breed.weight!.metric} kg ({Breed.weight!.imperial} lb)";
        }
    }

    public string BreedName {
        get {
            return $"Breed Name: {Breed.name} ({Breed.id})";
        }
    }

    public string BreedLivesFor {
        get {
            return $"Lives for: {Breed.life_span} years";
        }
    }

    public string BreedTemperament {
        get {
            return $"Temperament: {Breed.temperament}";
        }
    }

    public string BreedOrigin {
        get {
            return $"Origin: {Breed.origin} ({Breed.country_codes})";
        }
    }

    public BreedItem(Breed breed)
	{
		InitializeComponent();

		Breed = breed;

        BindingContext = this;
    }

    private async void OpenWiki(object sender, EventArgs e) {
        try {
            await Launcher.OpenAsync(new Uri(Breed.wikipedia_url!));
        } catch (Exception ex) {
            await Navigation.NavigationStack.Last().DisplayAlert("Error", "Could not open the URL.", "OK");
        }
    }
}