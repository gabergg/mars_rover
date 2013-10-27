using marsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace marsRoverTesting
{
    
    
    /// <summary>
    ///This is a test class for RoverTest and is intended
    ///to contain all RoverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RoverTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        //I've only included a few test cases; I would expand on these given enough time.

        //Testing a regular working testcase: the one given.
        [TestMethod]
        public void TestMethod1()
        {

            IMap map = new Grid("5 5");
            Rovers rovers = new Rovers(map);

            rovers.newRover("1 2 N", "LMLMLMLMM");
            rovers.newRover("3 3 E", "MMRMMRMRRM");

            Assert.IsTrue(rovers.Count == 2, "Number of rovers does not match!");

            IRover firstRover = rovers[0];
            IRover secondRover = rovers[1];

            Assert.IsTrue(firstRover.direction == 'N', "Rover 1 facing wrong direction!");
            Assert.IsTrue(secondRover.direction == 'E', "Rover 2 facing wrong direction!");

            Assert.IsTrue(firstRover.xCoordinate == 1, "Rover 1 x-coordinate should be 1");
            Assert.IsTrue(secondRover.xCoordinate == 5, "Rover 2 x-coordinate should be 5");

            Assert.IsTrue(firstRover.yCoordinate == 3, "Rover 1 y-coordinate should be 3");
            Assert.IsTrue(secondRover.yCoordinate == 1, "Rover 2 y-coordinate should be 1");
        }

        //Testing going off of the grid, move past y max. Should throw IndexOutOfRangeException
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod2()
        {
            IMap map = new Grid("2 2");
            Rovers rovers = new Rovers(map);

            rovers.newRover("1 1 N", "MMMLRLLMMMM");
        }

        //Testing invalid argument. Should throw ArgumentException
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            IMap map = new Grid("2 2");
            Rovers rovers = new Rovers(map);

            rovers.newRover("1 1 N", "LRQLL");
        }
    }
}
