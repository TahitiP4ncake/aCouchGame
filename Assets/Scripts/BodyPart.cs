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

    public static List<BodyPart> FullHumans (int amountOfHumans) {
        return new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, 2*amountOfHumans),
            new BodyPart (BodyPartType.FEET, 2*amountOfHumans),
            new BodyPart (BodyPartType.BUTTS, 1*amountOfHumans),
            new BodyPart (BodyPartType.HEADS, 1*amountOfHumans)
        } ;
    }
}