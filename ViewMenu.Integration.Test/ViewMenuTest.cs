using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bizmonger.Patterns;

namespace ViewMenu.Integration.Test
{
    [TestClass]
    public class ViewMenuTest
    {
        #region Testware
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        //[TestMethod]
        //public void load_menu()
        //{
        //    // Setup
        //    var viewModel = new ViewModel();

        //    // Test
        //    _messagebus.Publish(Messages.REQUEST_LOAD_CONTENT, new Repository());

        //    // Verify
        //    var expected = !string.IsNullOrEmpty(viewModel.Content1) &&
        //                    !string.IsNullOrEmpty(viewModel.Content2) &&
        //                    !string.IsNullOrEmpty(viewModel.Content3) &&
        //                    !string.IsNullOrEmpty(viewModel.Content4);

        //    Assert.IsTrue(expected);
        //}
    }
}