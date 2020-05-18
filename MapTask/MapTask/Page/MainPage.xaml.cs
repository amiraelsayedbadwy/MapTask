using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapTask
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Polygon myploygon;
        public List<Position> MyList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MyList = new List<Position>();
            Device.BeginInvokeOnMainThread(async() =>
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));
            });
                
           
         
        }

        private void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            MyList.Add(e.Position);
          
           
          
            if (MyList.Count==3)
            {
                

                foreach (var item in MyList)
                {

                    Pin pin = new Pin
                    {
                        Label = "",
                        Type = PinType.Place,
                        Position = new Position(item.Latitude, item.Longitude)
                    };
                    map.Pins.Add(pin);
                    myploygon.Geopath.Add(item);

                   
                }
              
                map.MapElements.Add(myploygon);
            }
          
        }
    }
}
