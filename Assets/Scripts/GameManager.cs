using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int amountOfPlayers;
    public Couch couch;

    private static  GameManager _instance;
    public static GameManager instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject();
                go.name = "Game Manager";
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake () {
        if (_instance == null) _instance = this;
        if (_instance != this) Destroy(this);
    }

    private void GetCouch () {
        Body allPlayers = new Body (BodyPart.FullHumans(2));
    }

    private Couch Split (Body allParts) {
        Couch tmp = new Couch (0);

        return tmp;
    }
}