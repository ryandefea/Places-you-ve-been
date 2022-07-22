using Microsoft.AspNetCore.Mvc;
using PlacesYouveBeen.Models;
using System.Collections.Generic;

namespace PlacesYouveBeen.Controllers
{
  public class PlaceController : Controller
  {
    
    [HttpGet("/states/{stateId}/places/new")]
    public ActionResult New(int stateId)
    {
      State state = State.Find(stateId);
      return View(state);
    }

    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }

    [HttpGet("/states/{stateId}/places/{placeId}")]
    public ActionResult Show(int stateId, int placeId)
    {
      Place place = Place.Find(placeId);
      State state = State.Find(stateId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("place", place);
      model.Add("state", state);
      return View(model);
    }
  }
}