using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface IPlanetarySystem
{
    static List<IPlanetaryObjects> PlaneteryObjects { get; }

    void Init(ref double mass, int i);
}
