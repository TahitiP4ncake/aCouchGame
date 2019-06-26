﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoSingleton<GameManager> {
    //TODO
    //add a couchManager, split with current GameManager
    //jeter un coup d'oeil à l'interface ?
    //Playtest pour la difficulté => préparer différents niveaux ?
    //Options : faire un settingsManager, backend pour retirer des bodyParts
    //Structure dans le code......
    //Class body : bools leftArm, rightArm..

    public int amountOfPlayers;
    public int maxBodyParts = 4;
    public int maxCushions = 4;
    public Cushion maxParts {
        get {
            return new Cushion (
                2*instance.amountOfPlayers,
                2*instance.amountOfPlayers,
                instance.amountOfPlayers,
                instance.amountOfPlayers
            );
        }
    }

    public void TwoPlayers () { SetPlayers(2); }
    public void ThreePlayers () { SetPlayers(3); }
    public void FourPlayers () { SetPlayers(4); }
    public void FivePlayers () { SetPlayers(5); }

    public void SetPlayers (int amount) {
        amountOfPlayers = amount;
    }
}