using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public string cityName;
        public WeatherData weatherData;
        public MainPage()
        {
            InitializeComponent();
            var temp = GetLocation();
            temp.Wait();
            weatherData = temp.Result;
            BindingContext = weatherData;

        }

        CancellationTokenSource cts;

        async Task<WeatherData> GetLocation()
        {
            try
            {
                // Location
                Xamarin.Essentials.Location location = null;
                while (location == null)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);
                }
                var lati = location.Latitude;
                var longi = location.Longitude;

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {lati}, Longitude: {longi}, Altitude: {location.Altitude}");
                    //city
                    var placemarks = await Geocoding.GetPlacemarksAsync(lati, longi);
                    var placemark = placemarks?.FirstOrDefault();
                    cityName = String.Format("{0}, {1}", placemark.Locality, placemark.CountryName);
                    horizontalTown.Text = cityName;
                    verticalTown.Text = cityName;

                    // Weather
                    var key = "05eae1fa34e3bc6757059b9dd6c38636";
                    var url = String.Format("https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&lang=da&units=metric&appid={2}", lati, longi, key);
                    return await RestService.GetData<WeatherData>(url);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }


        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;

                // landscape
                if (width > height)
                {
                    containerVertical.IsVisible = false;
                    containerHorizontal.IsVisible = true;
                }
                else
                // portrait
                {
                    containerVertical.IsVisible = true;
                    containerHorizontal.IsVisible = false;
                }

            }

        }
    }
}