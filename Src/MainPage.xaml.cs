using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using SpaceTactics.ViewModels;

namespace SpaceTactics {
    public sealed partial class MainPage : Page {
        private MainPageModel viewModel => (MainPageModel) DataContext;

        public MainPage() {
            this.InitializeComponent();

            DataContext = new MainPageModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            viewModel.LoadData();
        }
    }
}