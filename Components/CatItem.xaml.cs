namespace CatApp.Components {
    public partial class CatItem : ContentView {
        public Cat Cat { get; init; }
        public float AspectRatio {
            get {
                return Cat.width/ Cat.height;
            }
        }

        public string CatName {
            get {
                if (Cat.breeds == null || Cat.breeds.Count == 0 || Cat.breeds[0].name == null)
                    return "Unnamed";

                return Cat.breeds[0].name!;
            }
        }

        public CatItem(Cat cat) {
            InitializeComponent();

            Cat = cat;

            BindingContext = this;

            CatPreviewImage.WidthRequest = 150;
            CatPreviewImage.HeightRequest = 150;
        }

        public async void OnClick(object sender, EventArgs e) {
            await Navigation.PushAsync(new DetailPage(Cat));
        }
    }
}