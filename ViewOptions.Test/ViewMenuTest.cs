using Bizmonger.Patterns;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TestAPI.Gimme;

namespace ViewMenu.Test
{
    [TestClass]
    public class ViewMenuTest
    {
        #region Testware
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        [TestMethod]
        public void load_menu()
        {
            // Setup
            var viewModel = new ViewModel();

            // Test
            _messagebus.Publish(Messages.REQUEST_LOAD_CONTENT, new MockRepository());

            // Verify
            var expected = !string.IsNullOrEmpty(viewModel.Content1.Value) &&
                            !string.IsNullOrEmpty(viewModel.Content2.Value) &&
                            !string.IsNullOrEmpty(viewModel.Content3.Value) &&
                            !string.IsNullOrEmpty(viewModel.Content4.Value);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void select_option_with_empty_content()
        {
            // Setup
            var viewModel = new ViewModel();

            // Test
            viewModel.Content1 = null;
            viewModel.SelectedContent = viewModel.Content1;

            // Verify
            Assert.IsNull(viewModel.SelectedContent);
        }

        [TestMethod]
        public void select_option_with_content()
        {
            // Setup
            var content = new Content() { Id = SOME_ID, Value = SOME_SHORT_TEXT };
            var viewModel = new ViewModel();

            // Test
            viewModel.Content1 = content;
            viewModel.SelectedContent = viewModel.Content1;

            // Verify
            Assert.IsTrue(viewModel.SelectedContent.Value == SOME_SHORT_TEXT);
        }

        [TestMethod]
        public void select_option_and_copy_content()
        {
            // Setup
            var viewModel = new ViewModel();
            SelectSomeContent(viewModel);
           
            // Test
            _messagebus.Publish(Messages.REQUEST_SET_CLIPBOARD, viewModel.SelectedContent);

            // Verify
            Assert.IsTrue(viewModel.CopyMade);
        }

        #region Helpers
        private static void SelectSomeContent(ViewModel viewModel)
        {
            var content = new Content() { Id = SOME_ID, Value = SOME_SHORT_TEXT };
            viewModel.Content1 = content;
            viewModel.SelectedContent = viewModel.Content1;
        }
        #endregion
    }
}