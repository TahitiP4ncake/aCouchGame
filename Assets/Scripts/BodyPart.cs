using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartType { HANDS, FEET, BUTTS, HEADS }

[System.Serializable]
public class BodyPart {
    public BodyPartType type;
    [Range(0,6)]
    public int amount;

    public BodyPart (BodyPartType type, int amount) {
        this.type = type;
        this.amount = amount;
    }

    //Rend le bodyPart sous forme de texte (p.e. "4 feet")
    public string Display () {
        string result = "";

        if (amount > 0) {
            result = amount + " ";
            if (amount == 1) {
                if (type == BodyPartType.HANDS) result += " hand";
                if (type == BodyPartType.FEET) result += " foot";
                if (type == BodyPartType.BUTTS) result += " butt";
                if (type == BodyPartType.HEADS) result += " head";
            } else {
                if (type == BodyPartType.HANDS) result += " hands";
                if (type == BodyPartType.FEET) result += " feet";
                if (type == BodyPartType.BUTTS) result += " butts";
                if (type == BodyPartType.HEADS) result += " heads";
            }
        }

        return result;
    }
}