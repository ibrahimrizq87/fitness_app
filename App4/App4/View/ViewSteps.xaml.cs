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
using static Android.App.Assist.AssistStructure;
using static Android.Resource;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSteps : ContentPage
    {
        int id = 0;
        MyViewModel viewModel;
        public ViewSteps()
        {
            viewModel = new MyViewModel();
            Title = "View current Steps Record";


            InitializeComponent();
            viewModel.LoadStepss();
            Thread.Sleep(100);
            myListSteps.ItemsSource = viewModel.getStepsList();

        }
        void Loadstep(object sender, EventArgs e)
        {
            viewModel.LoadStepss();
            Thread.Sleep(100);

            myListSteps.ItemsSource = viewModel.getStepsList();

        }
        void Deletesteps(object sender, EventArgs e)
        {
            if (id != 0)
            {
                viewModel.deleteSteps(id);
                move();
            }


        }
        private async void move()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void stepItem(object sender, ItemTappedEventArgs e)
        {

            var item = e.Item as Steps;
            id = item.Id;


        }
    }
}
