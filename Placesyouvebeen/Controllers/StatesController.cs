using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlacesYouveBeen.Models;

namespace PlacesYouveBeen.Controllers
{
    public class StatesController : Controller
    {
        [HttpGet("/states")]
        public ActionResult Index()
        {
            List<State> allState = State.GetAll();
            return View(allState);
        }

        [HttpGet("/states/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/states")]
        public ActionResult Create(string stateName)
        {
            State newState = new State(stateName);
            return RedirectToAction("Index");
        }

        [HttpGet("/states/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            State selectedState = State.Find(id);
            List<Place> statePlaces = selectedState.Places;
            model.Add("state", selectedState);
            model.Add("places", statePlaces);
            return View(model);
        }
        // This one creates new Places within a given Category, not new Categories:
        [HttpPost("/states/{stateId}/places")]
        public ActionResult Create(int stateId, string placeCityName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            State foundState = State.Find(stateId);
            Place newPlace = new Place(placeCityName);
            foundState.AddPlace (newPlace);
            List<Place> statePlaces = foundState.Places;
            model.Add("places", statePlaces);
            model.Add("state", foundState);
            return View("Show", model);
        }
    }
}