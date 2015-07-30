using Bizmonger.Patterns;
using DataAccessMediator;
using Entities;
using Xamarin.Forms;

namespace Bizmonger
{
    public class App : Application
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        public App()
        {
            // The root page of your application
            var homePage = new ViewMenu.View();
            this.MainPage = new NavigationPage(homePage);

            InitializeData();

            _messagebus.Subscribe(ViewMenu.Messages.REQUEST_EDIT,
                async obj => { await MainPage.Navigation.PushAsync(new EditContent.View(obj as Content), animated: true); });

            _messagebus.Subscribe("REQUEST_PREVIOUS_VIEW",
                async obj => await MainPage.Navigation.PopAsync(animated: true));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #region Helpers
        private void InitializeData()
        {
            new Repository();
        }
        #endregion
    }
}