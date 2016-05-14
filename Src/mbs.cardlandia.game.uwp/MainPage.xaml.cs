using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using mbs.cardlandia.game.uwp.ViewModels;

namespace mbs.cardlandia.game.uwp {
    public sealed partial class MainPage : Page {
        private MainPageModel viewModel => (MainPageModel) DataContext;

        public MainPage() {
            this.InitializeComponent();

            DataContext = new MainPageModel();

            this.SizeChanged += MainPage_SizeChanged;
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e) {
            gMain.Refresh(this.ActualWidth, this.ActualHeight);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            viewModel.LoadData();
        }
    }
}