using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    /// <summary>
    /// Target for rotation
    /// </summary>
    [SerializeField] private Transform target;
    /// <summary>
    /// Rotation speed
    /// </summary>
    public int speed;
    public static int CountOfPlaneteryObjects { get; set; }

    private static List<IPlanetaryObjects> _planeteryObjects = new();
    /// <summary>
    /// List of planets
    /// </summary>
    public static List<IPlanetaryObjects> PlaneteryObjects => _planeteryObjects;
    /// <summary>
    /// Initializer of planets
    /// </summary>
    /// <param name="totalMass">Total mass</param>
    /// <param name="i">The counter from the loop in which this method is called</param>
    public void Init(ref double totalMass, int i)
    {
        PlanetaryObjects planet = new();
        if (i == CountOfPlaneteryObjects) // If the object is the last
        {
            if (totalMass > 5000) // If the mass is still too much
            {
                CountOfPlaneteryObjects++;
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, 5000);
                totalMass -= planet.mass;
            }
            else if (totalMass < 5000)
            {
                PlaneteryObjects.Add(planet);

                planet.mass = totalMass;
            }
        }
        else
        {
            if (totalMass > 5000) // If the mass is greater than the Jovian mass
            {
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, 5000);
                totalMass -= planet.mass;
            }
            else
            {
                PlaneteryObjects.Add(planet);

                planet.mass = Random.Range(0, (float)totalMass);
                totalMass -= planet.mass;
            }
        }
    }
    void Start()
    {
        if (target == null)
        {
            target = gameObject.transform;
            Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
        }
    }
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}