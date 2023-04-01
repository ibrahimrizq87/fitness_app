using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using App4.Model;
using App4.View;
using App4.ViewModel;
using Google.Type;
using Java.Lang;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunningOnTreadmill : ContentPage
    {
        
        MyViewModel viewModel;
        UserData user;
        int n = 0;
        float maxX = 0;
        float maxy = 0;
        float maxz = 0;
        double step = 0;
        double distance = 0;
        string text = "";
        string text2 = "";
        SensorSpeed speed = SensorSpeed.Game;
        SensorSpeed speed2 = SensorSpeed.UI;
        public RunningOnTreadmill()
        {
            user = new UserData();
            viewModel = new MyViewModel();

            Title = "Run Run ....";
            InitializeComponent();
            updateUser();
            Thread.Sleep(500);
            calculations();


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

            if (currentX > maxX) maxX = currentX;
            if (currenty > maxy) maxy = currenty;
            if (currentz > maxz) maxz = currentz;
            speedX.Text = $"X Direction: {maxX}";
            speedY.Text = $"Y Direction: {maxy}";

        }
        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
        
            n++;
            calculations();
            distance = n * step /100;

            distanceMade.Text = $"distance: {distance} m";
            text = "No.Steps: " + n.ToString();
            text2 = "Calories: " + ((float)n * 0.04).ToString();
            noOfSteps.Text = text;
            noOfCalories.Text = text2;

        }


        private void calculations()
        {
            namename.Text = $"Go {user.name}";
            step = (user.hight) * 0.415;
            stepText.Text = $"Stride Length: {step} Cm";
            hight.Text = $"Body hight: {user.hight}";
            weight.Text= $"Body Weight is: {user.weight}";
        }
        private async void updateUser()
        {
            user = await viewModel.getLatestUser();
        }

        private void updateRunningTread(object sender, EventArgs e)
        { MoveToUpdate(); }
            private void ViewRunningTread(object sender, EventArgs e)
        {


            MoveToView();

        }
        private void DoneRunningTread(object sender, EventArgs e)
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

        private async void Move()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void MoveToUpdate()
        {
            await Navigation.PushAsync(new AddUserData());
        }
        private async void MoveToView()
        {
            await Navigation.PushAsync(new ViewUserHistory());
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
                {
                    Gyroscope.Stop();
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
                speedX.Text = fnsEx.ToString();
            }
            catch (System.Exception ex)
            {
                speedY.Text = ex.ToString();
            }
        }
    
    }
}