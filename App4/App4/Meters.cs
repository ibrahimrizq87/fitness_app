using System;
using System.Collections.Generic;
using System.Text;
using Android.Media;
using Google.Type;

namespace App4
{
    public static class Meters
    {
        const double EARTH_RADIUS = 6371009;

        static double ToRadians(double input)
        {
            return input / 180.0 * Math.PI;
        }

        static double DistanceRadians(double lat1, double lng1, double lat2, double lng2)
        {
            double Hav(double x)
            {
                double sinHalf = Math.Sin(x * 0.5);
                return sinHalf * sinHalf;
            }
            double ArcHav(double x)
            {
                return 2 * Math.Asin(Math.Sqrt(x));
            }
            double HavDistance(double lat1b, double lat2b, double dLng)
            {
                return Hav(lat1b - lat2b) + Hav(dLng) * Math.Cos(lat1b) * Math.Cos(lat2b);
            }
            return ArcHav(HavDistance(lat1, lat2, lng1 - lng2));
        }

        public static double ComputeDistanceBetween(LatLng from, LatLng to)
        {
            double ComputeAngleBetween(LatLng From, LatLng To)
            {
                return DistanceRadians(ToRadians(from.Latitude), ToRadians(from.Longitude),
                                              ToRadians(to.Latitude), ToRadians(to.Longitude));
            }
            return ComputeAngleBetween(from, to) * EARTH_RADIUS;
        }

     
    }
}
