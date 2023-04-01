using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using App4.Model;
using App4.ViewModel;
using Google.Type;
using Java.Lang;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.Assist.AssistStructure;
using static Android.Content.ClipData;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Running : ContentPage
    {
        LatLng latlng1;
        LatLng latlng2;
        LatLng currentLatlng2;

        MyViewModel viewModel;
        int n = 0;
        float maxX = 0;
        float maxy = 0;
        float maxz = 0;
        double fLat = 0;
        double fLong = 0;
        string text = "";
        string text2 = "";
        SensorSpeed speed = SensorSpeed.Game;
        SensorSpeed speed2 = SensorSpeed.UI;
        public  Running()
        {

            Title = "wait I am not ready";
            InitializeComponent();

            latlng1 = new LatLng();
            currentLatlng2 = new LatLng();
            location();
            fLat = currentLatlng2.Latitude;
            fLong= currentLatlng2.Longitude;

            start.Text = $"starting from Lat: {fLat}, Long: {fLong}";

            viewModel = new MyViewModel();
            latlng2 = new LatLng();
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
            ToggleAccelerometer();
            ToggleGyroscope();
          
            
            text = "No.Steps: " + n.ToString();
            text2 = "Calories: " + ((float)n * 0.04).ToString();

            noOfSteps.Text = text;
            noOfCalories.Text = text2;
        }
        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            float currentX = System.Math.Abs(data.AngularVelocity.X);
            float currenty = System.Math.Abs(data.AngularVelocity.Y);

            float currentz = System.Math.Abs(data.AngularVelocity.Z);

            if ( currentX>maxX) maxX= currentX;
            if (currenty > maxy) maxy = currenty;
            if (currentz > maxz) maxz = currentz;
            speedX.Text = $"X Direction: {maxX}";
            speedY.Text = $"Y Direction: {maxy}";

        }
        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            
            n++;
            text = "No.Steps: " + n.ToString();
            text2 = "Calories: " + ((float)n * 0.04).ToString();
            noOfSteps.Text = text;
            noOfCalories.Text = text2;

        }
        
        private void CalculateDistance(object sender, EventArgs e)
        {
            
            location();
            latlng1.Longitude = fLong;
            latlng1.Latitude = fLat;

            latlng2 = currentLatlng2;

            end.Text = $"ending location lat: {latlng2.Latitude}, long: {latlng2.Longitude}";
            var km1 = Meters.ComputeDistanceBetween(latlng1, latlng2);
            if (km1 != 0)
            {
                distance.Text = $"distance is: {(int)km1} meters";
                distance.FontSize = 25;
                distance.TextColor = System.Drawing.Color.White;
            }
            else
            {
                distance.FontSize = 12;
                distance.TextColor = System.Drawing.Color.Red;
                distance.Text = $"You did not move or you have poor network connection.........\nTry running on treadmill or track insted";
            }

        }
        private void DoneRunning(object sender, EventArgs e)
        {
            string day = System.DateTime.Now.ToString("ddd dd/MM");
            double calories = n * 0.04;
            int Steps = n;

            Calories c = new Calories();
            Steps s = new Steps();
            c.day = day;
            c.calories = (float)calories;
            s.day = day;
            s.steps = Steps;

            viewModel.AddCalories(c);
            viewModel.AddSteps(s);
            Move();

        }
        private async void Move() {
            await Navigation.PushAsync(new MainPage());
        }
        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                noOfSteps.Text = fnsEx.ToString();
            }
            catch (System.Exception ex)
            {
                noOfSteps.Text = ex.ToString();

            }
        }
        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                { Gyroscope.Stop();
                 //   speedText.Text = "here stop";
                }
                else
                {
                    Gyroscope.Start(speed2);
                   // speedText.Text = "here start";
                }   
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                speedX.Text= fnsEx.ToString();
            }
            catch (System.Exception ex)
            {
                speedY.Text = ex.ToString();
            }
        }
        private async void location() {

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                Thread.Sleep(2000);
                if (location != null)
                {
                    Log.Debug("[running]","sleep");
                    Title = "ok go go go .. ";
                    currentLatlng2.Latitude = location.Latitude;
                    currentLatlng2.Longitude = location.Longitude;
                }
                else {
                    start.Text = "make sure to open internet and location on your phone";
                }
            }
          
            catch (System.Exception ex)
            {
                end.Text = ex.ToString();            }
        }
    }
}