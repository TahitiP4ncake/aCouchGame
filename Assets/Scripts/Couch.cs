using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Couch {
    // 0 = left armrest, 1 = left cushion, 2 = right cushion, 3 = right armrest
    public List<Body> cushions;

    public Couch (List<Body> cushions) {
        this.cushions = cushions;
    }

    public Couch (int nothing) {
        this.cushions = new List<Body> () {
            new Body (0),
            new Body (0),
            new Body (0),
            new Body (0)
        } ;
    }

    private Body Cushion (int n) {
        if (cushions.Count > n) return cushions[n];
        return null;
    }

    public Body leftArmRest { get { return Cushion(0); } }
    public Body leftCushion { get { return Cushion(1); } }
    public Body rightCushion { get { return Cushion(2); } }
    public Body rightArmRest { get { return Cushion(3); } }
}