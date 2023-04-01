using System;

using System.Threading;

using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App4.Model;
using Android.Util;


namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnteryPage : ContentPage
    {
        MyViewModel viewModel;
        public EnteryPage()
        {
            viewModel= new MyViewModel();
            InitializeComponent();
            try {
                if (Application.Current.Properties["registered"] != null)
                {
                    Move();
                }
            }catch(Exception ex)
            {
               
            }
        }
        private async void Move() {
           await Navigation.PushAsync(new MainPage());
        }
        private void saveDataUser(object sender, EventArgs e)
        {
            UserData user = new UserData();
         
            if (user.name == "" || weightEntery.Text == "" || ageEntery.Text == "" || hightEntery.Text== "")
            {
                t1.TextColor = Color.Red;
                t1.Text = "All data is required";
            }
            else {
                user.state = "Latest";
                user.name = nameEntery.Text;
                user.weight = int.Parse(weightEntery.Text);
                user.age = int.Parse(ageEntery.Text);
                user.hight = int.Parse(hightEntery.Text);
                viewModel.AddUser(user);
                Application.Current.Properties["registered"] = "yes";
                Thread.Sleep(200);
                Move();
               
            }
            
        }
    }
}