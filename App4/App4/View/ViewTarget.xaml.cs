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
using static Java.Text.Normalizer;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTarget : ContentPage
    {
        int id = 0;
        MyViewModel viewModel;
        public ViewTarget()
        {
            viewModel = new MyViewModel();
            Title = "View Targets";
            InitializeComponent();
            viewModel.LoadTarget();
            Thread.Sleep(100);


            
            myListTarget.ItemsSource = viewModel.getTargetList();

        }
        void Loadtarget(object sender, EventArgs e)
        {
            viewModel.LoadTarget();
            Thread.Sleep(100);

            myListTarget.ItemsSource = viewModel.getTargetList();
        }
        
              void Deletetarget(object sender, EventArgs e)
        {
            if (id !=0) {
                viewModel.deleteTarget(id);
                move();
            }

            
        }
        private async void move()
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void targetItem(object sender, ItemTappedEventArgs e)
        {

            var item = e.Item as Target;
            id = item.Id;
            

        }
    }
}