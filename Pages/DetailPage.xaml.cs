namespace CatApp;

public partial class DetailPage : ContentPage
{
    public Cat Cat { get; init; }

    public DetailPage(Cat cat)
    {
		InitializeComponent();

        Cat = cat;

        BindingContext = this;

        if (Cat.breeds == null)
            return;

        foreach (Breed breed in Cat.breeds) {
            Breeds.Add(new Label() { Text = breed.weight!.metric });
            Breeds.Add(new Label() { Text = breed.weight!.imperial });
            Breeds.Add(new Label() { Text = breed.id });
            Breeds.Add(new Label() { Text = breed.name });
            Breeds.Add(new Label() { Text = breed.temperament });
            Breeds.Add(new Label() { Text = breed.origin });
            Breeds.Add(new Label() { Text = breed.country_codes });
            Breeds.Add(new Label() { Text = breed.country_code });
            Breeds.Add(new Label() { Text = breed.life_span });
            Breeds.Add(new Label() { Text = breed.wikipedia_url });
        }
    }
}