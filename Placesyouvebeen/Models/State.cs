using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
    public class State
    {
        private static List<State> _instances = new List<State> {};

        public string Name { get; set; }

        public int Id { get; }

        public List<Place> Places{ get; set; }

        public State(string stateName)
        {
            Name = stateName;
            _instances.Add(this);
            Id = _instances.Count;
            Places = new List<Place>{};
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<State> GetAll()
        {
            return _instances;
        }

        public static State Find(int searchId)
        {
            return _instances[searchId - 1];
        }

        public void AddPlace(Place place)
        {
            Places.Add(place);
        }
    }
}