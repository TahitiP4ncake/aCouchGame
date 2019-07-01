using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoSingleton<GameManager> {
    public int amountOfPlayers;
    public static readonly int maxBodyParts = 4;
    public static readonly int maxCushions = 4;
    public bool lateralize;
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