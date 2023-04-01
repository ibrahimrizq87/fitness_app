using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App4.Model;

namespace App4.RepoFile
{
    public interface RepositoryInterface
    {

        Task<bool> AddCaloriesAsync(Calories calories);
        Task<bool> AddStepssAsync(Steps steps);
        Task<bool> AddHeartRateAsync(HeartRate heartRate);
        Task<bool> AddTargetAsync(Target target);
        Task<IEnumerable<Calories>> getCaloriesAsync();
        Task<IEnumerable<Steps>> getStepssAsync();
        Task<IEnumerable<HeartRate>> getHeartRateAsync();
        Task<IEnumerable<Target>> getTargetAsync();

    }
}
