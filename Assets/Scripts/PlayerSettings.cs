using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {
    public static PlayerSettings instance;
    private GameManager gm { get { return GameManager.instance; } }

    public Couch players;

    public Difficulty easy;
    public Difficulty medium;
    public Difficulty hard;

    [HideInInspector]
    public Difficulty difficulty;

    public void InitiatePlayers () {
        players = new Couch (gm.amountOfPlayers);
    }

    public void DecreasePlayerBodyPart (int playerIndex, BodyPartType type) {
        BodyPart part = gm.couch.Cushion(playerIndex).Part(type);
        if (part.amount > 0) part.amount --;
    }

    public void IncreasePlayerBodyPart (int playerIndex, BodyPartType type) {
        BodyPart part = gm.couch.Cushion(playerIndex).Part(type);
        if (part.amount < Body.classicHuman.Part(part.type).amount) part.amount ++;
    }
}