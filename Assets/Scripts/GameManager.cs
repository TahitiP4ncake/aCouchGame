using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int amountOfPlayers;
    public Couch couch = instance.GetCouch();
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

    private Couch GetCouch () {
        return Split(RandomBody(0, amountOfPlayers*6));
    }

    // Generates a random body containing min to max bodyparts
    // TODO : add rules for max value for each bodypart
    private Body RandomBody (int minParts, int maxParts) {
        Body body = new Body (0, 2, 0, 0); //2 feet for stability

        int parts = Random.Range (minParts, maxParts+1);
        for (int i=0; i<parts; i++) {
            body.parts[Random.Range(0, 4)].amount ++;
        }

        return body;
    }
    // Repartit au hasard une liste de bodypart dans un couch
    private Couch Split (Body allParts) { 
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