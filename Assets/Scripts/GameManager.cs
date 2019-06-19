using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int amountOfPlayers;
    public Couch couch;
    private int maxBodyParts = 4;

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
        Body allPlayers = new Body (
            2*amountOfPlayers, 
            2*amountOfPlayers, 
            1*amountOfPlayers, 
            1*amountOfPlayers
        );
        couch = Split(allPlayers);
    }

    private Couch Split (Body allParts) { //Repartit au hasard une liste de bodypart dans un couch
        Couch tmp = new Couch (0);

        for (int i=0; i<maxBodyParts; i++) { //Pour chaque type de bodypart
            for (int j=0; j<allParts.parts[i].amount; j++) { //Pour chaque bodypart de ce type dans l'argument
                int ran = Random.Range(0,maxBodyParts);
                tmp.cushions[ran].parts[i].amount ++; //Augmenter de 1 le nb de bodyparts d'un coussin random
            }
        }

        return tmp;
    }
}