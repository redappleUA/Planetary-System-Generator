using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    /// <summary>
    /// ÷≥ль дл€ обертанн€
    /// </summary>
    [SerializeField] private Transform target;
    /// <summary>
    /// Ўвидк≥сть обертанн€
    /// </summary>
    public int speed;
    public static int CountOfPlaneteryObjects { get; set; }

    private static List<IPlanetaryObjects> _planeteryObjects = new();
    /// <summary>
    /// —писок планет
    /// </summary>
    public static List<IPlanetaryObjects> PlaneteryObjects => _planeteryObjects;
    /// <summary>
    /// ≤н≥ц≥ал≥затор планет
    /// </summary>
    /// <param name="totalMass">«агальна маса</param>
    /// <param name="i">Ћ≥чильник з циклу, в €кому викликаЇтьс€ цей метод</param>
    public void Init(ref double totalMass, int i)
    {
        PlanetaryObjects planet = new();
        if (i == CountOfPlaneteryObjects) // якщо об'Їкт останн≥й
        {
            if (totalMass > 5000) // якщо маси ще забагато
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
            if (totalMass > 5000) // якщо маса б≥льше маси Jovian'а
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
            target = this.gameObject.transform;
            Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
        }
    }
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}