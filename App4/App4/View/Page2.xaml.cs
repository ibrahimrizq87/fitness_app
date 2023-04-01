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
    public partial class Page2 : ContentPage
    {
        MyViewModel viewModel ;
        public Page2()
        {
            InitializeComponent();
            Title = "Adding Steps data";
            stepsDay.Text = DateTime.Now.ToString();
            viewModel = new MyViewModel();
        }
        private void SendButton_ClickedSteps(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("ddd dd/MM");
            int calories = int.Parse(stepsEntry.Text);

            Steps caloriesInstance = new Steps();
            caloriesInstance.day = day;
            caloriesInstance.steps = calories;
            viewModel.AddSteps(caloriesInstance);
            Move();
        }
        private async void Move()
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}