using Microsoft.AspNetCore.Mvc;
using CDCase.Models;
using System.Collections.Generic;

namespace CDCase.Controllers
{
  public class CDsController : Controller
  {

    [HttpGet("/{artistId}/CD/new")]
    public ActionResult New(int artistId)
    {
       Artist artist = Artist.Find(artistId);
       return View(artist);
    }

    [HttpGet("/{artistId}/CDs/{CDId}")]
    public ActionResult Show(int artistId, int CDId)
    {
      CD cd = CD.Find(CDId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      model.Add("CD", cd);
      model.Add("artist", artist);
      return View(model);
    }

  }
}
