using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using RestaurantList.Models;

namespace RestaurantList.Tests
{
     [TestClass]
     public class RestaurantListTest : IDisposable
     {
        public RestaurantListTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=restaurants_list_test;";
        }

        public void Dispose()
        {
            Restaurant.ClearAll();
        }

        [TestMethod]
        public void RestaurantConstructer_CreatesInstanceOfRestaurant_Restaurant()
        {
            Restaurant newRestaurant = new Restaurant("test restaurant");
            Assert.AreEqual(typeof(Restaurant), newRestaurant.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            string name = "Test RestaurantList";
            Restaurant newRestaurant = new Restaurant(name);
            string result = newRestaurant.GetName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllRestaurantObjects_RestaurantList()
        {
            string name01 = "Work";
            string name02 = "School";
            Restaurant newRestaurant1 = new Restaurant(name01);
            newRestaurant1.Save();
            Restaurant newRestaurant2 = new Restaurant(name02);
            newRestaurant2.Save();
            List<Restaurant> newList = new List<Restaurant> { newRestaurant1, newRestaurant2 };
            List<Restaurant> result = Restaurant.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCategoryInDatabase_Restaurant()
        {
            Restaurant testRestaurant = new Restaurant("Household chores");
            testRestaurant.Save();
            Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());
            Assert.AreEqual(testRestaurant, foundRestaurant);
        }

        //All above methods are for Categories
     }
}