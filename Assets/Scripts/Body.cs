﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Body {
    // 0 = hands, 1 = feet, 2 = butts, 3 = heads
    public List<BodyPart> parts;

    public Body (int hands, int feet, int butts, int heads) {
        this.parts = new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, hands),
            new BodyPart (BodyPartType.FEET, feet),
            new BodyPart (BodyPartType.BUTTS, butts),
            new BodyPart (BodyPartType.HEADS, heads)
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

    public int amountOfParts { get { return parts.Select(x => x.amount).ToList().Sum(); } }

    public string Display () {
        string result = "";

        for (int i=0; i<4; i++) {
            string part = Part(i).Display();
            if (result != "" && part != "") result += "\n";
            result += part;
        }

        return result;
    }

    public int AmountOf (BodyPartType type) {
        if (type == BodyPartType.HANDS) return hands.amount;
        if (type == BodyPartType.FEET) return feet.amount;
        if (type == BodyPartType.BUTTS) return butts.amount;
        if (type == BodyPartType.HEADS) return heads.amount;
        Debug.LogError("Error : type not found");
        return -1;
    }
}