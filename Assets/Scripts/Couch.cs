using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Couch {
    // 0 = left armrest, 1 = left cushion, 2 = right cushion, 3 = right armrest
    public List<Cushion> cushions;
    private GameManager gm { get { return GameManager.instance; } }

    public Couch () {
        this.cushions = new List<Cushion> ();
        Debug.LogError("sdzcfvd");
        for (int i=0; i<gm.maxBodyParts; i++) {
            cushions.Add(new Cushion ());
        }
    }

    public Couch (int players) {
        this.cushions = new List<Cushion> ();
        for (int i=0; i<players; i++) {
            cushions.Add(new Cushion ());
        } 
    }

    public Couch (Cushion body) {
        this.cushions = new List<Cushion> ();
        for (int i=0; i<gm.maxBodyParts; i++) {
            cushions.Add(body); 
        } 
    }

    public Cushion Cushion (int n) {
        if (cushions.Count > n) return cushions[n];
        return null;
    }

    public Cushion leftArmRest { get { return Cushion(0); } }
    public Cushion leftCushion { get { return Cushion(1); } }
    public Cushion rightCushion { get { return Cushion(2); } }
    public Cushion rightArmRest { get { return Cushion(3); } }

    //Returns a list of descriptions for each cushion
    public List<string> Display () {
        return cushions.Select(x => x.Display()).ToList();
    }

    //Every cushion gathered in one
    public Cushion Aggregate () {
        Cushion result = new Cushion ();

        for (int i=0; i<gm.maxBodyParts; i++) {
            result.Part(i).amount += cushions.Select(x => x.Part(i).amount).ToList().Sum();
        }

        return result;
    }
}