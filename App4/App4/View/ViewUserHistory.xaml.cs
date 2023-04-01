using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App4.Model;
using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUserHistory : ContentPage
    {
        int id = 0;
        string state = "";
        MyViewModel viewModel;

        public ViewUserHistory()
        {
            InitializeComponent();
            
                viewModel = new MyViewModel();
                Title = "View User History ";
                viewModel.LoadUserHistory();
                Thread.Sleep(100);
                userList.ItemsSource = viewModel.getUserList();

            }

        private async void move()
        {
            await Navigation.PushAsync(new RunningOnTreadmill());
        }
        void DeleteUser(object sender, EventArgs e)
            {
            if (id != 0 && state != "Latest")
            {
                viewModel.deleteUserData(id);
                move();
            }
            else {
                DeleteUserData.Text = "cannot delete latest\nor make sure to choose item ";
                
            }


            }
            private void userItem(object sender, ItemTappedEventArgs e)
            {
            DeleteUserData.Text = "delete";

               var item = e.Item as UserData;
                id = item.Id;
            state = item.state;


            }
        }
    }