using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Util;
using App4.Model;
using App4.ViewModel;
using Java.Security;
using SendGrid.Helpers.Mail;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Android.App.Assist.AssistStructure;

namespace App4
{
    public partial class MainPage : ContentPage
    { MyViewModel viewModel;
        UserData user;
        public MainPage()
        {
      

            user = new UserData();
            viewModel= new MyViewModel();
            InitializeComponent();
            viewModel.LoadUserHistory();
            Thread.Sleep(100);
            Title = "Home Page";
            foreach (var item in viewModel.getUserList()) {
                Log.Debug("Main",item.name);
                Log.Debug("Main2", item.state);
            } 
           
            
            /*txtname.Text = $"Hi {user.name}";
            txtage.Text = $"current age: {user.age}";
            txtHight.Text = $"current hight: {user.hight}";
            txtweight.Text = $"current weight: {user.weight}";*/

        }


       /* IEnumerator<UserData> updateUserData() {
            yield return  viewModel.UpdateUserData();

        }*/
       async void StartRunning(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Running());
        }
        async void NavigateTo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
        async void NavigateTo2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
        async void RunningTrack(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RunningOnTreadmill());
        }
        async void NavigateTo4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTarget());
        }
        async void NavigateTo5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewCalories());
        }
        async void NavigateTo6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewSteps());
        }
        async void NavigateTo7(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewHeartRate());
        }
        async void NavigateTo8(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewTarget());
        }
    }
}
