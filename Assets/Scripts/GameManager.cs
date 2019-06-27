using System.Collections;
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
    public static readonly int maxBodyParts = 4;
    public static readonly int maxCushions = 4;
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
}