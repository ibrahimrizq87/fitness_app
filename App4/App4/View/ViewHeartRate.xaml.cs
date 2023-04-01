using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using App4.View;
using App4.ViewModel;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.Assist.AssistStructure;
using static Android.Resource;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewHeartRate : ContentPage
    {
        int id = 0;
        MyViewModel viewModel;
        
        public ViewHeartRate()
        {
            viewModel = new MyViewModel();

            InitializeComponent();
            Title = "View current Heart Rate Record";

            viewModel.LoadHeartRate();
            Thread.Sleep(100);
            myListHeart.ItemsSource = viewModel.getHeartRateList();
           
        }
        void LoadHeart(object sender, EventArgs e)
        {
            viewModel.LoadHeartRate();
            Thread.Sleep(100);
            myListHeart.ItemsSource = viewModel.getHeartRateList();

        }
        void HeartAddNew(object sender, EventArgs e)
        {
            Move();
        }
        void Heartsteps(object sender, EventArgs e)
        {
            if (id != 0)
            {
                viewModel.deleteHeartRate(id);
                move();
            }


        }
        private async void move()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void heartItem(object sender, ItemTappedEventArgs e)
        {

            var item = e.Item as HeartRate;
            id = item.Id;


        }
        private async void Move() {
            await Navigation.PushAsync(new AddHeartRate());
        }
    }
}