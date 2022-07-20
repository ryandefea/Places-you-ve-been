using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PlacesYouveBeen.Models;
using System;

namespace PlacesYouveBeen.Tests
{
  [TestClass]
  public class PlacesTests : IDisposable
  {

    public void Dispose()
    {
      Place.ClearAll();
    }

    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place("");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }

    [TestMethod]
    public void GetCityName_ReturnCityName_String()
    {
      //Arrange
      string cityName = "Portland.";

      //Act
      Place newPlace = new Place(cityName);
      string result = newPlace.CityName;

      //Assert
      Assert.AreEqual(cityName, result);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_PlaceList()
    {
      // Arrange
      List<Place> newPlace = new List<Place> { };

      // Act
      List<Place> result = Place.GetAll();

      // Assert
      CollectionAssert.AreEqual(newPlace, result);
    }

    [TestMethod]
    public void GetAll_ReturnPlaces_PlaceList()
    {
      //Arrange
      string cityName01 = "Portland";
      string cityName02 = "Aberdeen";
      Place newPlace1 = new Place(cityName01);
      Place newPlace2 = new Place(cityName02);
      List<Place> newPlace = new List<Place> { newPlace1, newPlace2 };

      //Act
      List<Place> result = Place.GetAll();

      //Assert
      CollectionAssert.AreEqual(newPlace, result);
    }

      [TestMethod]
  public void GetId_PlacesInstantiateWithAnIdAndGetterReturns_Int()
  {
    //Arrange
    string cityName = "Portland";
    Place newPlace = new Place(cityName);

    //Act
    int result = newPlace.Id;

    //Assert
    Assert.AreEqual(1, result);
  }

  //  [TestMethod]
  // public void Find_ReturnsCorrectItem_Item()
  // {
  //   //Arrange
  //   string description01 = "Walk the dog";
  //   string description02 = "Wash the dishes";
  //   Item newItem1 = new Item(description01);
  //   Item newItem2 = new Item(description02);

  //   //Act
  //   Item result = Item.Find(2);

  //   //Assert
  //   Assert.AreEqual(newItem2, result);
  // }
  }
}