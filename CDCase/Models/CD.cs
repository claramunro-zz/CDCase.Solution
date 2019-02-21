using System.Collections.Generic;

namespace CDCase.Models
{
  public class CD
  {
    private string _description;
    private int _id;
    private static List<CD> _instances = new List<CD> {};

    public CD (string description)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public static List<CD> GetAll()
    {
      return _instances;
    }

    public int GetId()
    {
      return _id;
    }

    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
