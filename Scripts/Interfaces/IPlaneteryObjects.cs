using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetaryObjects
{
    MassClassEnum massClass { get;}

    double mass { get; set; }
    float Radius { get; }
}
