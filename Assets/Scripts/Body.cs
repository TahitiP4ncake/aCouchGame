using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Cushion {
    // 0 = hands, 1 = feet, 2 = butts, 3 = heads
    public List<BodyPart> parts;
    private GameManager gm { get { return GameManager.instance; } }

    public Cushion (int hands, int feet, int butts, int heads) {
        this.parts = new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, hands),
            new BodyPart (BodyPartType.FEET, feet),
            new BodyPart (BodyPartType.BUTTS, butts),
            new BodyPart (BodyPartType.HEADS, heads)
        } ;
    }

    public Cushion () {
        this.parts = new List<BodyPart> () {
            new BodyPart (BodyPartType.HANDS, 0),
            new BodyPart (BodyPartType.FEET, 0),
            new BodyPart (BodyPartType.BUTTS, 0),
            new BodyPart (BodyPartType.HEADS, 0)
        } ;
    }

    public  BodyPart Part (int n) {
        if (parts.Count > n) return parts[n];
        return null;
    }

    public BodyPart Part (BodyPartType type) {
        if (type == BodyPartType.HANDS) return hands;
        if (type == BodyPartType.FEET) return feet;
        if (type == BodyPartType.BUTTS) return butts;
        if (type == BodyPartType.HEADS) return heads;
        Debug.LogError("Error : type not found");
        return null;
    }

    public BodyPart hands { get { return Part(0); } }
    public BodyPart feet { get { return Part(1); } }
    public BodyPart butts { get { return Part(2); } }
    public BodyPart heads { get { return Part(3); } }

    //The total amount of parts in this Body
    public int amountOfParts { get { return parts.Select(x => x.amount).ToList().Sum(); } }

    //Returns a classic human body (2 hands, 2 feet, 1 head, 1 butt)
    public static Cushion classicHuman { get { return new Cushion (2, 2, 1, 1); } }

    //Display the list of all BodyParts (1 per line)
    public string Display () {
        string result = "";

        for (int i=0; i<gm.maxBodyParts; i++) {
            string part = Part(i).Display();
            if (result != "" && part != "") result += "\n";
            result += part;
        }

        return result;
    }

    //Shortcut to the amount of a certain BodyPart
    public int AmountOf (BodyPartType type) {
        if (type == BodyPartType.HANDS) return hands.amount;
        if (type == BodyPartType.FEET) return feet.amount;
        if (type == BodyPartType.BUTTS) return butts.amount;
        if (type == BodyPartType.HEADS) return heads.amount;
        Debug.LogError("Error : type not found");
        return -1;
    }
}