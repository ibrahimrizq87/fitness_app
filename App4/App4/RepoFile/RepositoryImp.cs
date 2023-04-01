using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using App4.Model;
using Android.Util;

namespace App4.RepoFile
{
    public class RepositoryImp : RepositoryInterface
    {
        public SQLiteAsyncConnection databse;
        public RepositoryImp(string dbPath)
        {
            databse = new SQLiteAsyncConnection(dbPath);
            databse.CreateTableAsync<Target>().Wait();
            databse.CreateTableAsync<HeartRate>().Wait();
            databse.CreateTableAsync<Steps>().Wait();
            databse.CreateTableAsync<Calories>().Wait();
            databse.CreateTableAsync<UserData>().Wait();
            databse.CreateTableAsync<RunData>().Wait();

        }

        public async Task<bool> AddCaloriesAsync(Calories calories)
        {
            if (await GetTodayCaloriesAsync(calories.day) != null)
            {
                var newStep = calories;

                var current = await GetTodayCaloriesAsync(calories.day);
                newStep.calories += current.calories;
                await DeleteCalories(current.Id);
                await databse.InsertAsync(newStep);
            }
            else
            {
                await databse.InsertAsync(calories);
            }
            return await Task.FromResult(true);
        }


        public async Task<UserData> GetuserDataLatestAsync()
        {
            Log.Debug("REPO","i am here");
            return await databse.Table<UserData>().Where(p => p.state == "Latest").FirstOrDefaultAsync();
        }


        public async Task<bool> AddUSerDataAsync(UserData data)
        {
            if (await GetuserDataLatestAsync() != null)
            {
                Log.Debug("Repo","I am here");
                var current = await GetuserDataLatestAsync();
                await DeleteUser(current.Id);
                current.state = "History";
                await databse.InsertAsync(current);
                await databse.InsertAsync(data);
            
        }
            else
            {
                Log.Debug("Repo22222222", "I am here");
                await databse.InsertAsync(data);
            }
            return await Task.FromResult(true);
        }
        public async Task<bool> AddTargetAsync(Target target)
        {


            await databse.InsertAsync(target);

            return await Task.FromResult(true);
        }



        public async Task<bool> AddHeartRateAsync(HeartRate heartRate)
        {
            if (heartRate.Id > 0)
            {
                await databse.UpdateAsync(heartRate);
            }
            else
            {
                await databse.InsertAsync(heartRate);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> AddStepssAsync(Steps steps)
        {

            if (await GetTodayStepsAsync(steps.day) != null)
            {
                var newStep = steps;
                
                var current = await GetTodayStepsAsync(steps.day);
                newStep.steps += current.steps;
                await DeleteSteps(current.Id);
                await databse.InsertAsync(newStep);
                
            }
            else
            {
                await databse.InsertAsync(steps);
            }
            return await Task.FromResult(true);
        }

    
        public async Task<Target> GetTodayTargetAsync(string day)
        {
            return await databse.Table<Target>().Where(p => p.day == day).FirstOrDefaultAsync();
        }
        public async Task<RunData> GetTodayRunDataAsync(string day)
        {
            return await databse.Table<RunData>().Where(p => p.day == day).FirstOrDefaultAsync();
        }
        public async Task<Calories> GetTodayCaloriesAsync(string day)
        {
            return await databse.Table<Calories>().Where(p => p.day == day).FirstOrDefaultAsync();
        }
        public async Task<Steps> GetTodayStepsAsync(string day)
        {
            return await databse.Table<Steps>().Where(p => p.day == day).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteCalories(int id)
        {
            await databse.DeleteAsync<Calories>(id);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteSteps(int id)
        {
            await databse.DeleteAsync<Steps>(id);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteTarget(int id)
        {
            await databse.DeleteAsync<Target>(id);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteHeartRate(int id)
        {
            await databse.DeleteAsync<HeartRate>(id);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteUser(int id)
        {
            await databse.DeleteAsync<UserData>(id);
            return await Task.FromResult(true);
        }
        public async Task<IEnumerable<Calories>> getCaloriesAsync()
        {
            return await Task.FromResult(await databse.Table<Calories>().ToListAsync());
        }
        public async Task<IEnumerable<UserData>> GetUserHistoryAsync()
        {
            return await Task.FromResult(await databse.Table<UserData>().ToListAsync());
        }

        public async Task<IEnumerable<HeartRate>> getHeartRateAsync()
        {
            return await Task.FromResult(await databse.Table<HeartRate>().ToListAsync());

        }

        public async Task<IEnumerable<Steps>> getStepssAsync()
        {
            return await Task.FromResult(await databse.Table<Steps>().ToListAsync());
        }

        public async Task<IEnumerable<RunData>> getRundataAsync()
        {
            return await Task.FromResult(await databse.Table<RunData>().ToListAsync());
        }

        public async Task<IEnumerable<Target>> getTargetAsync()
        {
            return await Task.FromResult(await databse.Table<Target>().ToListAsync());
        }

    }
}