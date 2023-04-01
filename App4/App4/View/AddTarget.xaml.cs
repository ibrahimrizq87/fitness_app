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
    public partial class AddTarget : ContentPage
    {
        MyViewModel viewModel;
        public AddTarget()
        {
            viewModel= new MyViewModel();
            InitializeComponent();
            Title = "Adding Target Data";
            targetDay.Text = DateTime.Now.ToString();
        }
        private void SendButton_ClickedTarget(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("ddd dd/MM"); ;
            int calories = int.Parse(TargetCalories.Text);
            int steps = int.Parse(targetSteps.Text);
            string heartRate = targetHeart.Text;
            Target caloriesInstance = new Target();
            caloriesInstance.day = day;
            caloriesInstance.calories = calories;
            caloriesInstance.steps = steps;
            caloriesInstance.heartRate= heartRate;
            viewModel.AddTarget(caloriesInstance);
            Move();
        }

        private async void Move()
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}