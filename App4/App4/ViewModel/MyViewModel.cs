using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using App4.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App4.ViewModel
{
    public partial class MyViewModel : ObservableObject
    {
        /*
        [ObservableProperty] public List<Calories> _caloriesList = new List<Calories>();
        [ObservableProperty] private List<Steps> _stepsList = new List<Steps>();
        [ObservableProperty] private List<Target> _targetsList = new List<Target>();
        [ObservableProperty] private List<HeartRate> _heartRateList = new List<HeartRate>();
         */
        public List<UserData> _userList = new List<UserData>();
        public List<Calories> _caloriesList = new List<Calories>();
        private List<Steps> _stepsList = new List<Steps>();
        private List<Target> _targetsList = new List<Target>();
        private List<HeartRate> _heartRateList = new List<HeartRate>();

        public MyViewModel()
        {

            AddCaloriesCommand = new RelayCommand<Calories>(AddCalories);
            AddStepsCommand = new RelayCommand<Steps>(AddSteps);
            AddTargetCommand = new RelayCommand<Target>(AddTarget);
            AddHeartRateCommand = new RelayCommand<HeartRate>(AddHeartRate);
        }
        public List<HeartRate> getHeartRateList()
        {

            return _heartRateList;
        }
        public List<Steps> getStepsList()
        {

            return _stepsList;
        }
        public List<Target> getTargetList()
        {

            return _targetsList;
        }
        public List<UserData> getUserList()
        {

            return _userList;
        }
        public RelayCommand<Calories> AddCaloriesCommand { get; }

        public async void AddCalories(Calories calories)
        {

            await App.RepositoryImp.AddCaloriesAsync(calories);

            // Add calories to list
            _caloriesList.Add(calories);
        }
        /* public async IAsyncEnumerable<Calories> getCalories()
         {

           yield return await repository.getCaloriesAsync();

         }*/

        public RelayCommand<Steps> AddStepsCommand { get; }

        public async void AddSteps(Steps steps)
        {
            // Call pre-existing method to add steps
            await App.RepositoryImp.AddStepssAsync(steps);

            // Add steps to list
            _stepsList.Add(steps);
        }

        public RelayCommand<Target> AddTargetCommand { get; }

        public async void AddTarget(Target target)
        {
            await App.RepositoryImp.AddTargetAsync(target);
            _targetsList.Add(target);
        }
        public async void AddUser(UserData user)
        {
            await App.RepositoryImp.AddUSerDataAsync(user);
              }
        public RelayCommand<HeartRate> AddHeartRateCommand { get; }

        public async void AddHeartRate(HeartRate heartRate)
        {
            // Call pre-existing method to add heart rate
            await App.RepositoryImp.AddHeartRateAsync(heartRate);

            // Add heart rate to list
            _heartRateList.Add(heartRate);
        }

        public async Task<UserData> getLatestUser() {
            Log.Debug("usr error", "i am here");
            
            return await App.RepositoryImp.GetuserDataLatestAsync();
        }
        public async void deleteUserData(int id)
        {
            await App.RepositoryImp.DeleteUser(id);
            LoadUserHistory();
        }
        public async void LoadUserHistory()
        {
            try
            {
                _userList.Clear();
                var list = await App.RepositoryImp.GetUserHistoryAsync();
                foreach (var item in list)
                {
                    _userList.Add(item);
                    Log.Debug("SO",item.name);
                 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async void LoadCalories()
        {
            try
            {
                _caloriesList.Clear();
                var list = await App.RepositoryImp.getCaloriesAsync();
                foreach (var item in list)
                {
                    _caloriesList.Add(item);
                    Log.Debug("SO", item.day);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void deleteCalories(int id)
        {
            await App.RepositoryImp.DeleteCalories(id);
            LoadCalories();
        }
   
        public async void deleteSteps(int id)
        {
            await App.RepositoryImp.DeleteSteps(id);
            LoadStepss();
        }
        public async void deleteTarget(int id)
        {
            await App.RepositoryImp.DeleteTarget(id);
            LoadTarget();
        }
        public async void deleteHeartRate(int id)
        {
            await App.RepositoryImp.DeleteHeartRate(id);
            LoadHeartRate();
        }
        public async void LoadStepss()
        {
            try
            {
                _stepsList.Clear();
                var list = await App.RepositoryImp.getStepssAsync();
                foreach (var item in list)
                {
                    _stepsList.Add(item);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void LoadHeartRate()
        {
            try
            {
                _heartRateList.Clear();
                var list = await App.RepositoryImp.getHeartRateAsync();
                foreach (var item in list)
                {
                    Log.Debug("[so]", item.day);
                    _heartRateList.Add(item);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void LoadTarget()
        {
            try
            {
                _targetsList.Clear();
                var list = await App.RepositoryImp.getTargetAsync();
                foreach (var item in list)
                {
                    _targetsList.Add(item);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
