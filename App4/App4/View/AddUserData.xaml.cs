using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using App4.ViewModel;
using Java.Lang;
using Org.Apache.Http.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserData : ContentPage
    {
        MyViewModel viewModel;
        UserData current;
        public AddUserData()
        {
            current = new UserData();
            viewModel = new MyViewModel();
            getData();
            Thread.Sleep(100);
           // nameUser.Text = current.name;
            InitializeComponent();
            Title = "Updating User Data";
        }
        private void addUser(object sender, EventArgs e)
        {
           
            UserData user = new UserData();
         
            if (user.name == "" || weightEntery.Text == "" || HightEntery.Text == "" || ageEntery.Text == "")
            {
                Button55.FontSize = 12;
                Button55.TextColor = Color.Red;
                Button55.Text = "all data is required \ntype required data and press again";

            }
            else {
                user.name = nameUser.Text;
                user.weight = int.Parse(weightEntery.Text);
                user.hight = int.Parse(HightEntery.Text);
                user.age = int.Parse(ageEntery.Text);
                user.state = "Latest";
                viewModel.AddUser(user);
                move();
            }
            
        }
        private async void getData() {
            current= await viewModel.getLatestUser();
        }
        private async void move() {
            await Navigation.PushAsync(new ViewUserHistory());
        }

    }
}