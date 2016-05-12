using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using SpaceTactics.Transports;

namespace SpaceTactics.Controls {
    public sealed partial class MapGrid : UserControl {
        public IEnumerable<Tileset> ItemSource {
            set { SetValue(ItemSourceProperty, value); }
            get { return (IEnumerable<Tileset>) GetValue(ItemSourceProperty); }
        }

        public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemSource", typeof(IEnumerable<Tileset>), typeof(MapGrid), null);

        public int Columns {
            get { return (int) GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(MapGrid), null);

        public int Rows {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(MapGrid), null);

        public MapGrid() {
            this.InitializeComponent();
            this.Loaded += MapGrid_Loaded;
        }

        public void Refresh(double windowWidth, double windowHeight) {
            var itemWidth = (windowWidth - 50) / Columns;
            var itemHeight = (windowHeight - 100) / Rows;
           
            for (var x = 0; x < gMain.Children.Count; x++) {
                gMain.Children[x].SetValue(WidthProperty, itemWidth);
                gMain.Children[x].SetValue(HeightProperty, itemHeight);
            }
        }

        private void MapGrid_Loaded(object sender, RoutedEventArgs e) {
            for (var x = 0; x < Rows; x++) {
                gMain.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (var x = 0; x < Columns; x++) {
                gMain.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            var colCount = 0;
            var currentRow = 0;

            var itemWidth = gMain.ActualWidth/Columns;
            var itemHeight = gMain.ActualHeight/Rows;

            foreach (var item in ItemSource) {
                if (colCount == Columns) {
                    currentRow++;
                    colCount = 0;
                }

                var tile = new MapTile(item);
                
                tile.SetValue(WidthProperty, itemWidth);
                tile.SetValue(HeightProperty, itemHeight);

                tile.SetValue(Grid.RowProperty, currentRow);
                tile.SetValue(Grid.ColumnProperty, colCount);

                gMain.Children.Add(tile);

                colCount++;
            }
        }
    }
}