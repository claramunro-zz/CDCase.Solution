using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDCase.Models;

namespace CDCase.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      List<Artist> allArtists = Artist.GetAll();
      return View("Index", allArtists);
    }

    [HttpGet("/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<CD> categoryCD = selectedArtist.GetItems();
      model.Add("artist", selectedArtist);
      model.Add("CDs", categoryCD);
      return View(model);
    }

    // This one creates new Items within a given Category, not new Artists:
    [HttpPost("/{artistId}/CDs")]
    public ActionResult Create(int artistId, string CDDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      CD newCD = new CD(CDDescription);
      foundArtist.AddCD(newCD);
      List<CD> artistCDs = foundArtist.GetItems();
      model.Add("CDs", artistCDs);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}
