using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : ScriptableObject{
    [Range(0,1)]
    public float minParts, maxParts;

    public Body partWeight = new Body();
}