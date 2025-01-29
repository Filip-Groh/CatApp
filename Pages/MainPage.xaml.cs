using CatApp.Components;

namespace CatApp
{
    public partial class MainPage : ContentPage
    {
        bool isLoading = false;

        public MainPage()
        {
            InitializeComponent();

            AddCats(10);
        }

        async void AddCats(int amount) {
            isLoading = true;
            List<Cat>? cats = await TheCatAPIService.Current.GetCatsAsync(amount, true, true, Size.Thumb);

            foreach (Cat cat in cats!) {
                InfiniteScrollContent.Add(new CatItem(cat));
            }
            isLoading = false;
        }

        void OnScroll(object sender, ScrolledEventArgs e) {
            if (!(sender is ScrollView scrollView))
                return;

            double scrollSpace = scrollView.ContentSize.Height - scrollView.Height;
            double loadTrigger = scrollSpace - 4 * scrollView.Height;

            if (loadTrigger < e.ScrollY && !isLoading) {
                AddCats(20);
            }
        }
    }
}
