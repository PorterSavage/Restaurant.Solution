using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using RestaurantList.Models;

namespace RestaurantList.Test
{
    [TestClass]
    public class CuisineTest : IDisposable
    {
        public void Dispose()
        {
            Cuisine.ClearAll();
        }
    }
}