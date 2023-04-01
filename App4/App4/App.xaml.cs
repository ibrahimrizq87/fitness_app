using System;
using System.IO;
using App4.RepoFile;
using App4.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    public partial class App : Application
    {
        public static RepositoryImp repositoryImp;
      //  MyViewModel viewModel;
        public static RepositoryImp RepositoryImp
        {
            get
            {
                if (repositoryImp == null)
                {
                    repositoryImp = new RepositoryImp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FitnessAppDB.db3"));
                }
                return repositoryImp;
            }
        }
        public App()
        {
           // viewModel=new MyViewModel();
           // viewModel.LoadUserHistory();
            InitializeComponent();

            MainPage = new NavigationPage(new EnteryPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
