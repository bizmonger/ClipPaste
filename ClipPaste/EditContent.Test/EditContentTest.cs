using Bizmonger.Patterns;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TestAPI.Gimme;

namespace EditContent.Test
{
    [TestClass]
    public class EditContentTest
    {
        #region Testware
        MessageBus _messagebus = MessageBus.Instance;

        [TestCleanup]
        public void Cleanup()
        {
            _messagebus.Clear();
        }
        #endregion
        
        [TestMethod]
        public void no_edits_disables_can_save()
        {
            // Setup
            var viewModel = new ViewModel();

            // Verify
            Assert.IsTrue(!viewModel.CanSave);
        }

        [TestMethod]
        public void edits_enables_can_save()
        {
            // Setup
            var content = new Content() { Id = SOME_INTEGER_ID, Value = SOME_TEXT };
            var viewModel = new ViewModel() { Content = content };

            // Test
            viewModel.Content = content;

            // Verify
            Assert.IsTrue(viewModel.CanSave);
        }

        [TestMethod]
        public void save_edit()
        {
            // Setup
            new MockRepository(); // Initialize subscriptions
            var content = new Content() { Id = SOME_INTEGER_ID, Value = SOME_OTHER_TEXT };
            var viewModel = new ViewModel() { Content = content };
            viewModel.PreviousContent = SOME_TEXT;
            
            var save = new Commands().Save;

            // Test
            save.Execute(viewModel.Content);

            // Verify
            var changesMade = viewModel.Content.Value == SOME_OTHER_TEXT;
            Assert.IsTrue(changesMade);
        }

        [TestMethod]
        public void load_content()
        {
            // Setup
            var content = new Content() { Id = SOME_INTEGER_ID, Value = SOME_TEXT };
            var viewModel = new ViewModel() { Content = content };

            // Test
            _messagebus.Publish(Messages.REQUEST_LOAD_EDITOR, content);

            // Verify
            var expected = viewModel.Content.Value == SOME_TEXT;
            Assert.IsTrue(expected);
        }
    }
}