using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App4.Model;
using App4.View;
using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Content.ClipData;
using static Android.Resource;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCalories : ContentPage
    {
        Calories item;
        int id = 0;
        MyViewModel viewModel;
        public  ViewCalories()
        {
                      viewModel =new MyViewModel();
            item=new Calories();
            InitializeComponent();
            Title = "View current Calories Record";
            viewModel.LoadCalories();
            Thread.Sleep(100);
            myList.ItemsSource = viewModel._caloriesList;
       
        }
         void Load1(object sender, EventArgs e)
        {
           viewModel.LoadCalories();
            Thread.Sleep(100);
            myList.ItemsSource = viewModel._caloriesList;

        }
        void Calsteps(object sender, EventArgs e)
        {
            if (id != 0)
            {
                viewModel.deleteCalories(id);
                move();
            }


        }
        private async void move()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void CalItem(object sender, ItemTappedEventArgs e)
        {

             item = e.Item as Calories;

            id = item.Id;


        }
    }
}
    