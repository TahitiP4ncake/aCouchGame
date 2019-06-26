using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New", menuName = "New", order = 1)]
public class Difficulty : ScriptableObject{
    [Range(0,1)]
    public float minParts, maxParts;

    public Cushion partWeight = new Cushion();
}