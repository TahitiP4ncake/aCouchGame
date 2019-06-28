using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartType { HANDS, FEET, BUTTS, HEADS }

[System.Serializable]
public class BodyPart {
    public BodyPartType type;
    [Range(0,6)]
    public int amount;

    private GameManager gm { get { return GameManager.instance; } }

    public BodyPart (BodyPartType type, int amount) {
        this.type = type;
        this.amount = amount;
    }

    //Rend le bodyPart sous forme de texte
    //p.e. "4 feet" si unlateralized, "butt butt butt" ou "left hand, left hand, right hand" si lateralized
    public string Display () {
        if (gm.lateralize) return LateralizedDisplay ();
        else return UnlateralizedDisplay ();
    }

    private string LateralizedDisplay () {
        string result = "";

        for (int i=0; i<amount; i++) {
            if (result != "") result += "\n";

            if (type == BodyPartType.BUTTS) result += "butt";
            else if (type == BodyPartType.HEADS) result += "head";
            else {
                if (Random.value > 0.5f) result += "left";
                else result += "right";

                result += " ";
                if (type == BodyPartType.HANDS) result += "hand";
                if (type == BodyPartType.FEET) result += "foot";
            }
        }

        return result;
    }

    private string UnlateralizedDisplay () {
        string result = "";

        if (amount > 0) {
            result = amount + " ";
            if (amount == 1) {
                if (type == BodyPartType.HANDS) result += "hand";
                if (type == BodyPartType.FEET) result += "foot";
                if (type == BodyPartType.BUTTS) result += "butt";
                if (type == BodyPartType.HEADS) result += "head";
            } else {
                if (type == BodyPartType.HANDS) result += "hands";
                if (type == BodyPartType.FEET) result += "feet";
                if (type == BodyPartType.BUTTS) result += "butts";
                if (type == BodyPartType.HEADS) result += "heads";
            }
        }

        return result;
    }
}