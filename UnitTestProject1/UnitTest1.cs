﻿using System;
//using ClassLibrary1;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    

    [TestClass]
    public class UnitTest1
    {
        private ClassLibrary1.Person _p;

        [TestInitialize]
        public void BeginTest()
        {
            _p = new Person("Magne");
        }

        [TestMethod]
        public void TestAdult()
        {
            // Under 18 should return false
            _p.Age = 17.99;
            bool result = _p.isAdult();
            Assert.IsFalse(result);

            // Equal to 18 should return true
            _p.Age = 18.00;
            result = _p.isAdult();
            Assert.IsTrue(result);

            // Over 18 should return true
            _p.Age = 18.01;
            result = _p.isAdult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEquality()
        {
            Person p = new Person();
            p.Name = "Bølle";
            p.Age = 24;

            Person otherP = new Person("Bølle");
            otherP.Age = 24;

            
            Assert.AreEqual(p, otherP);
        }

        [TestMethod]
        public void TestInequality()
        {
            Person g = new Person();
            g.Name = "Bølle";
            g.Age = 24;

            Person otherG = new Person("Bølle");
            otherG.Age = 22;
            
            Assert.AreNotEqual(g, otherG);
        }

        
        [TestMethod]

        public void TestAgeException()
        {
            Person p = new Person();
            p.Name = "Bølle";

            p.Age = 35;

            try
            {
                p.Age = -24;
                Assert.Fail();
            }

            catch (AgeException ae)
            {
                Assert.AreEqual("Alder for lav", ae.Message);
            }

            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
