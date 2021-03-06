// <copyright file="CommandsTest.cs">Copyright ©  2015</copyright>
using System;
using EditContent;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EditContent.Tests
{
    /// <summary>This class contains parameterized unit tests for Commands</summary>
    [PexClass(typeof(Commands))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CommandsTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Commands ConstructorTest()
        {
            Commands target = new Commands();
            return target;
            // TODO: add assertions to method CommandsTest.ConstructorTest()
        }
    }
}
