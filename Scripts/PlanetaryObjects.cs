using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PlanetaryObjects : MonoBehaviour, IPlanetaryObjects
{
    /// <summary>
    /// Клас планети
    /// </summary>
    public MassClassEnum massClass { get; private set; }

    private double _mass;
    /// <summary>
    /// Маса планети
    /// </summary>
    public double mass
    {
        get => _mass;
        set
        {
            _mass = value;
            if (mass > 0 && mass <= 0.00001)
            {
                Radius = Random.Range(0, 0.03f);
                massClass = MassClassEnum.Asteroidan;
            }
            else if (mass > 0.00001 && mass <= 0.1)
            {
                Radius = Random.Range(0.03f, 0.7f);
                massClass = MassClassEnum.Mercurian;
            }
            else if (mass > 0.1 && mass <= 0.5)
            {
                Radius = Random.Range(0.5f, 1.2f);
                massClass = MassClassEnum.Subterran;
            }
            else if (mass > 0.5 && mass <= 2)
            {
                Radius = Random.Range(0.8f, 1.9f);
                massClass = MassClassEnum.Terran;
            }
            else if (mass > 2 && mass <= 10)
            {
                Radius = Random.Range(1.3f, 3.3f);
                massClass = MassClassEnum.Superterran;
            }
            else if (mass > 10 && mass <= 50)
            {
                Radius = Random.Range(2.1f, 5.7f);
                massClass = MassClassEnum.Neptunian;
            }
            else if (mass > 50 && mass <= 5000)
            {
                Radius = Random.Range(3.5f, 27);
                massClass = MassClassEnum.Jovian;
            }
            else throw new Exception("Mass Out Of Range. Enter mass up to 5000."); //TODO} 
        }
    }
    /// <summary>
    /// Радіус планети
    /// </summary>
    public float Radius { get; private set; }
    /// <summary>
    /// Радіус зірки
    /// </summary>
    public static float StarRadius { get; set; } //INIT

}
