namespace CatApp.Components {
    public partial class CatItem : ContentView {
        public string ImageUrl { get; private set; }
        public string CatId { get; private set; }
        public int CatWidth { get; private set; }
        public int CatHeight { get; private set; }
        public float AspectRatio {
            get {
                return CatWidth / CatHeight;
            }
        }

        public CatItem(string Id, string url, int width, int height) {
            InitializeComponent();

            CatId = Id;
            ImageUrl = url;
            CatWidth = width;
            CatHeight = height;

            BindingContext = this;

            CatPreviewImage.MinimumHeightRequest = CatPreviewImage.Width * AspectRatio;
        }

        public async void OnClick(object sender, EventArgs e) {
            await Navigation.PushAsync(new DetailPage(CatId));
        }
    }
}