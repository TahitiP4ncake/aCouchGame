using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Couch {
    // 0 = left armrest, 1 = left cushion, 2 = right cushion, 3 = right armrest
    public List<Body> cushions;

    public Couch (int nothing) {
        this.cushions = new List<Body> () {
            new Body (0, 0, 0, 0),
            new Body (0, 0, 0, 0),
            new Body (0, 0, 0, 0),
            new Body (0, 0, 0, 0)
        } ;
    }

    public Body Cushion (int n) {
        if (cushions.Count > n) return cushions[n];
        return null;
    }

    public Body leftArmRest { get { return Cushion(0); } }
    public Body leftCushion { get { return Cushion(1); } }
    public Body rightCushion { get { return Cushion(2); } }
    public Body rightArmRest { get { return Cushion(3); } }

    //Returns a list of descriptions for each cushion
    public List<string> Display () {
        return cushions.Select(x => x.Display()).ToList();
    }

    //Every cushion gathered in one
    public Body Aggregate () {
        Body result = new Body (0, 0, 0, 0);

        for (int i=0; i<GameManager.maxBodyParts; j++) {
            result.parts(i).amount += cushions.Select(x => x.parts(i).amount).ToList().Sum();
        }
    }
}