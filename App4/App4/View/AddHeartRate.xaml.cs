using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.Assist.AssistStructure;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHeartRate : ContentPage
    {
        MyViewModel viewModel;
        public AddHeartRate()
        {
            viewModel= new MyViewModel();
            InitializeComponent();
            boxHeart.Text = DateTime.Now.ToString();
            Title = "Adding heart rate data";
        }
        private void SendButton_ClickedHeart(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("ddd dd/MM");
            string calories = boxHeart2.Text;
            HeartRate caloriesInstance = new HeartRate();
            caloriesInstance.day = day;
            caloriesInstance.heartRate = calories;
            if (calories == "")
            {
                t2.TextColor = Color.Red;
                t2.Text = "all data is required";

            }
            else {
                viewModel.AddHeartRate(caloriesInstance);
                Move();
            }
            

        }
        private async void Move() {
            await Navigation.PushAsync(new MainPage());
        }
    }
}