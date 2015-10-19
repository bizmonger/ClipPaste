using System;
using Android.App;
using Android.Views;
using Pickup;
using Pickup.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Maps;
using static Bizmonger.Patterns.MessageBus;
using Mediation;
using Android.Gms.Maps.Model;

[assembly: ExportRenderer(typeof(CustomPage),
                          typeof(MapPageRenderer))]
namespace Pickup.Droid
{
    public class MapPageRenderer : PageRenderer
    {
        Core.Location _location;
        Android.Views.View _view;
        GoogleMap _map;

        public MapPageRenderer()
        {
            Subscribe(Messages.LOCATION_CHANGED, obj =>
                {
                    _location = obj as Core.Location;

                    LatLng location = new LatLng(_location.Latitude, _location.Longitude);
                    CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                    builder.Target(location);
                    builder.Zoom(18);
                    CameraPosition cameraPosition = builder.Build();
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

                    var activity = this.Context as Activity;
                    MapFragment mapFrag = (MapFragment)activity.FragmentManager.FindFragmentById(Resource.Id.map);
                    _map = mapFrag.Map;
                    _map?.MoveCamera(cameraUpdate);

                    var textview = _view.FindViewById<Android.Widget.TextView>(Resource.Id.textView);
                    textview.Text = $"{_location.Latitude} , {_location.Longitude}";
                });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;
            _view = activity.LayoutInflater.Inflate(Resource.Layout.MapLayout, this, false);

            var mapFragment = activity.FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);

            var codeButton = _view.FindViewById<Android.Widget.Button>(Resource.Id.button_code);
            codeButton.Click += OnButtonTapped;

            AddView(_view);
        }

        void OnButtonTapped(object sender, EventArgs e)
        {
            var locationService = new LocationService();
            locationService.GetLocation();
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            _view.Measure(msw, msh);
            _view.Layout(0, 0, r - l, b - t);
        }
    }
}