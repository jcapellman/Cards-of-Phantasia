using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SpaceTactics.Controls;
using SpaceTactics.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpaceTactics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageModel viewModel => (MainPageModel) DataContext;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new MainPageModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            viewModel.LoadData();

            for (var x = 0; x < MainPageModel.HEIGHT; x++) {
                gMain.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            }

            for (var x = 0; x < MainPageModel.WIDTH; x++)
            {
                gMain.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            var rowCount = 0;
            var currentRow = 0;

            foreach (var item in viewModel.Tiles)
            {
                if (rowCount == MainPageModel.WIDTH)
                {
                    currentRow++;
                    rowCount = 0;
                }

                var tile = new MapTile(item);

               
                tile.SetValue(Grid.RowProperty, currentRow);
                tile.SetValue(Grid.ColumnProperty, rowCount);

                gMain.Children.Add(tile);

                rowCount++;
            }
        }
    }
}