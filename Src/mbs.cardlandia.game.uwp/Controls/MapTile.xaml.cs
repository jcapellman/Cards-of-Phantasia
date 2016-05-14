using Windows.UI.Xaml.Controls;

using mbs.cardlandia.game.uwp.library.Implementatinos.Match;

namespace mbs.cardlandia.game.uwp.Controls {
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