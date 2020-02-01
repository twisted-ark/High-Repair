using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World Active { get; private set; }

    [SerializeField] private Rigidbody ground;
    private List<House> houses = new List<House> ();

    public Rigidbody Ground => ground;
    public IReadOnlyList<House> Houses => houses;

    private void Awake ()
    {
        if (Active != null)
        {
            Debug.LogError ("Multiple worlds registered");
        }

        Active = this;
    }

    public void AddHouse (House house)
    {
        houses.Add (house);
    }

    public void RemoveHouse (House house)
    {
        houses.Remove (house);
    }
}
