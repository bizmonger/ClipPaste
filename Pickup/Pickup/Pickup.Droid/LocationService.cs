using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Mediation;
using static Bizmonger.Patterns.MessageBus;

namespace Pickup.Droid
{
    public class LocationService : Java.Lang.Object, ILocationListener
    {
        LocationManager _locationManager = null;

        public void GetLocation()
        {
            _locationManager = Application.Context.GetSystemService(Context.LocationService) as LocationManager;

            var locationCriteria = new Criteria();

            locationCriteria.Accuracy = Accuracy.Coarse;
            locationCriteria.PowerRequirement = Power.Medium;

            var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);

            if (locationProvider != null)
            {
                _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
            }
        }

        public void OnLocationChanged(Location location) =>
            Publish(Messages.LOCATION_CHANGED, new Core.Location(location.Latitude, location.Longitude));

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }
}