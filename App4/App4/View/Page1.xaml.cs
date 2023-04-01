using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        MyViewModel viewModel =new MyViewModel();
        public Page1()
        {
            InitializeComponent();
            Title = "Adding Calories data";
            DayEntry.Text = DateTime.Now.ToString();
        }
        private void SendButton_Clicked(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("ddd dd/MM") ;
            float calories = (float)int.Parse(CaloriesEntry.Text);

            Calories caloriesInstance = new Calories();
            caloriesInstance.day = day;
            caloriesInstance.calories= calories;
            viewModel.AddCalories(caloriesInstance);
            Move();

        }
        private async void Move()
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}