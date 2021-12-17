using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UniFindr_V2.Models;
using UniFindr_V2.ViewModels;
using UniFindr_V2.Services;
using Autofac.Extras.Moq;
using UniFindr_V2.Views;
using Xamarin.Forms;

namespace UniFindr_Test
{
    [TestClass]
    public class UniversityTests
    {
        /*[TestMethod]
        public void TestMethod1()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var repository = mock.Create<Repository>();
            Repository repository = new Repository();
            List<University> universities = repository.SendFullApiRequest();

                List<University> universitiesWithoutAreasOrWebpages = new List<University>();

                for (int i = 0; i < universities.Count; i++)
                {
                    if (universities[i].UniversityArea == null && universities[i].UniversityWebsite == null)
                    {
                        universitiesWithoutAreasOrWebpages.Add(universities[i]);
                    }
                }

                Assert.IsNull(universitiesWithoutAreasOrWebpages, "Universities found without area or website. Please consult relevant list.");
            }
        }*/

        [TestMethod]
        public void TestSelectedUniversityMethod()
        {
            ApplicationData data = new ApplicationData();
            SearchResultsViewModel_Home viewModel = new SearchResultsViewModel_Home();

            University testUni = new University
            {
                UniversityName = "Syddansk Erhvervsskole - SDE",
                UniversityCountry = "Denmark",
                UniversityArea = "Southern Denmark",
                UniversityWebsite = "https://sde.dk"
            };
            viewModel.selectedUniversity = testUni;
            data.LastSelectedUniversity = viewModel.selectedUniversity;
            Assert.AreEqual(testUni, data.LastSelectedUniversity);
        }

        [TestMethod]
        public void TestCountrySelectionMethod()
        {
            ApplicationData data = new ApplicationData();
            CountrySelectionViewModel viewModel = new CountrySelectionViewModel();

            Country testCountry = new Country()
            {
                CountryName = "Sweden"
            };
            viewModel.SelectedCountry = testCountry;
            data.PreferredCountry = viewModel.selectedCountry.CountryName;
            Assert.AreEqual(testCountry.CountryName, data.PreferredCountry);
        }
    }
}
