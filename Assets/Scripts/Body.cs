using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Body {
    // 0 = hands, 1 = feet, 2 = butts, 3 = heads
    public List<BodyPart> parts;

    public Body (List<BodyPart> parts) {
        this.parts = parts;
    }

    public Body (int hands, int feet, int butts, int heads) {
        this.parts = new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, hands),
            new BodyPart (BodyPartType.FEET, feet),
            new BodyPart (BodyPartType.BUTTS, butts),
            new BodyPart (BodyPartType.HEADS, heads)
        } ;
    }

    public Body (int nothing) {
        this.parts = new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, 0),
            new BodyPart (BodyPartType.FEET, 0),
            new BodyPart (BodyPartType.BUTTS, 0),
            new BodyPart (BodyPartType.HEADS, 0)
        } ;
    }

    private BodyPart Part (int n) {
        if (parts.Count > n) return parts[n];
        return null;
    }

    public BodyPart hands { get { return Part(0); } }
    public BodyPart feet { get { return Part(1); } }
    public BodyPart butts { get { return Part(2); } }
    public BodyPart heads { get { return Part(3); } }
}