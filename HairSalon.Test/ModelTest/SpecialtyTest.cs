using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {
        public void Dispose()
        {
            Specialty.ClearAll();
        }
        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id =root;password=root;port=8889;database=jimmy_zebroski_test;";
        }

        [TestMethod]
        public void SpecialtyConstructer_CreatesInstanceOfClass_Specialty()
        {
            Specialty newSpecialty = new Specialty("buzz head", 0);
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }
        [TestMethod]
        public void GetSpecialty_ReturnsSpecialtyName_String()
        {
            string specialty = "shave";
            int id = 0;
            Specialty newSpecialty = new Specialty(specialty, id);
            string result = newSpecialty.GetSpecialty();
            Assert.AreEqual(specialty, result);
        }
    }
  }
