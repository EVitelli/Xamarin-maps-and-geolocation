using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace Xamarin_maps_and_geolocation
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            setGeolocation();
        }

        private async Task setGeolocation()
        {
            Location location = await Geolocation.GetLocationAsync();
            Position position = new Position(location.Latitude, location.Longitude);

            mapa.Pins.Clear();
            mapa.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Você está aqui"
            });

            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(position,Distance.FromMeters(100)));
        }
    }
}
