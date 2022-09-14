using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using ColorUtility = UnityEngine.ColorUtility;

public class Factory : MonoBehaviour, IPlanetarySystemFactory
{
    [SerializeField] private GameObject planetPrefab;
    [SerializeField] private GameObject starPrefab;
    /// <summary>
    /// Spawning position
    /// </summary>
    [SerializeField] private Vector3 position = new();
    [SerializeField] private double totalMass;

    private readonly List<GameObject> spawnedPlanets = new();
    /// <summary>
    /// Planetary radius scaler
    /// </summary>
    private Vector3 radiusScale;
    /// <summary>
    /// Star radius scaler
    /// </summary>
    private Vector3 starRadiusScale;

    public void CreateStar()
    {
        PlanetaryObjects.StarRadius = Random.Range(0.4f, 60f); // We set the size of the star

        // Let's make a star
        GameObject go = Instantiate(starPrefab, position, Quaternion.identity); 
        go.name = "Star"; // Name

        #region The color of the star
        var light = go.GetComponent<MeshRenderer>().sharedMaterial;
        light.SetColor("_BaseColor", StarRandomColor());
        #endregion

        #region The size of the star
        starRadiusScale = new Vector3(1 * PlanetaryObjects.StarRadius, 1 * PlanetaryObjects.StarRadius, 1 * PlanetaryObjects.StarRadius);
        go.transform.localScale = starRadiusScale;
        #endregion
    }
    public void CreatePlanets(double totalMass)
    {
        // We randomly set the number of planets
        PlanetarySystem.CountOfPlaneteryObjects = Random.Range(1, 10);

        for (int i = 0; i < PlanetarySystem.CountOfPlaneteryObjects; i++)
        {
            // We are creating a planet
            GameObject go = Instantiate(planetPrefab, position, Quaternion.identity);
            go.GetComponent<PlanetarySystem>().Init(ref totalMass, i); 

            var goRenderer = go.GetComponent<MeshRenderer>();
            spawnedPlanets.Add(go); // Add to List of planets

            go.name = PlanetarySystem.PlaneteryObjects[i].massClass.ToString();   // We set the name
            goRenderer.material.SetColor("_Color", PlanetRandomColor()); // We set the color

            #region The Size of the planet
            radiusScale = new Vector3( 1 * PlanetarySystem.PlaneteryObjects[i].Radius, 
                1 * PlanetarySystem.PlaneteryObjects[i].Radius, 1 * PlanetarySystem.PlaneteryObjects[i].Radius);

            go.transform.localScale = radiusScale;
            #endregion

            #region The position of the planet
            if (i == 0)
                go.transform.position = new Vector3(starRadiusScale.x / 2 + go.transform.localScale.x / 2 + Random.Range(1, 6), 0, 0); 
            else
                go.transform.position = spawnedPlanets[i - 1].transform.position + new Vector3(radiusScale.x / 2 + spawnedPlanets[i-1].transform.localScale.x / 2 + Random.Range(1, 6), 0, 0);
            #endregion

            #region Rotation speed
            var goOrbit = go.GetComponent<PlanetarySystem>();
            goOrbit.speed -= i * 4;
            #endregion
        }
    }

    private Color StarRandomColor()
    {
        Color color;
        List<Color> colors = new();
        string[] hexs = { "#84f5f9", "#ddd900", "eb4326", "d21d0a", "c45f2b", "d6ffff", "f2ef8e", "e74327", "d6d79d", "8af2f5", "77dadf" };

        foreach(var hex in hexs)
        {
            ColorUtility.TryParseHtmlString(hex, out color);
            colors.Add(color);
        }
        return colors[Random.Range(0, colors.Count)];
    }
    private Color PlanetRandomColor()
    {
        Color material = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return material;
    }

    private void Start()
    {
        CreateStar();
        CreatePlanets(totalMass);
    }
}
