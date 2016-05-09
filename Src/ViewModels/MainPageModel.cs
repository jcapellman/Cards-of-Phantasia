using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using SpaceTactics.Transports;

namespace SpaceTactics.ViewModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public const int HEIGHT = 10;
        public const int WIDTH = 10;

        private ObservableCollection<Tileset> _tiles;

        public ObservableCollection<Tileset> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; OnPropertyChanged(); }
        }

        public void LoadData() {
            Tiles = new ObservableCollection<Tileset>();

            Random rand = new Random((int)DateTime.Now.Ticks);

            var numItems = 0;

            for (var x = 0; x < HEIGHT * WIDTH; x++)
            {
                var tile = new Tileset
                {
                    BackgroundImage = new BitmapImage(new Uri("ms-appx:///Assets/Textures/Ground/brick.jpg")),
                };

                var rando = rand.Next(0, 10) % 2 == 0;

                if (numItems < 10 && rando)
                {
                    rando = rand.Next(0, 10)%2 == 0;

                    if (rando)
                    {
                        tile.CharacterImage =
                            new BitmapImage(new Uri("ms-appx:///Assets/Textures/Characters/marine.png"));
                    }
                    else
                    {
                        tile.CharacterImage = new BitmapImage(new Uri("ms-appx:///Assets/Textures/Characters/Thor.png"));
                    }
                    numItems++;
                }
                else
                {
                    tile.CharacterImage = tile.BackgroundImage;
                }

                Tiles.Add(tile);
            }    
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
