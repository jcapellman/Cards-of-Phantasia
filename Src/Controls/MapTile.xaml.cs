using Windows.UI.Xaml.Controls;

using SpaceTactics.Transports;

namespace SpaceTactics.Controls {
    public sealed partial class MapTile : UserControl {
        public MapTile() {
            this.InitializeComponent();
        }

        public MapTile(Tileset tile) {
            this.InitializeComponent();

            iCharacter.Source = tile.CharacterImage;
            ibBackground.ImageSource = tile.BackgroundImage;
        }
    }
}