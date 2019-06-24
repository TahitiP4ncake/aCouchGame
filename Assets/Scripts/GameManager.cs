using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {
    //TODO
    //add a couchManager, split with current GameManager
    //import monosingleton
    //jeter un coup d'oeil à l'interface ?
    //Rename body to cushion
    //Playtest pour la difficulté => préparer différents niveaux ?
    //Options : faire un settingsManager, backend pour retirer des bodyParts
    //Structure dans le code......

    public int amountOfPlayers;
    public Couch couch;

    public const int maxBodyParts = 4;
    public const int maxCushions = 4;
    public Body maxParts {
        get {
            return new Body (
                2*amountOfPlayers,
                2*amountOfPlayers,
                amountOfPlayers,
                amountOfPlayers
            );
        }
    }

    private static  GameManager _instance;
    public static GameManager instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject();
                go.name = "Game Manager";
                _instance = go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake () {
        if (_instance == null) _instance = this;
        if (_instance != this) Destroy(this);
    }

    public void NewCouch () {
        instance.couch = Split(RandomBody(0, maxParts.amountOfParts));
    }

    // Generates a random body containing min to max bodyparts
    private Body RandomBody (int min, int max) {
        Body body = new Body (0, 2, 0, 0); //2 feet for stability

        if (max > maxParts.amountOfParts) {
            Debug.LogError ("Error : You're trying to put too many body parts ("+max+") in the couch ("+
            maxParts.amountOfParts+" body parts total)");
        } else {
            int amountOfPartsToSplit = Random.Range (min, max+1);

            // List is {0, 1, 2, 3... }
            List<int> possibleParts = new List<int>();
            for (int i=0; i<maxBodyParts; i++) {
                possibleParts.Add(i);
            }

            for (int i=0; i<amountOfPartsToSplit; i++) {
                int randomPartIndex = Random.Range(0, possibleParts.Count);
                BodyPart randomPart = body.parts[possibleParts[randomPartIndex]];

                randomPart.amount ++;

                if (randomPart.amount >= maxParts.AmountOf(randomPart.type)) {
                    possibleParts.RemoveAt(randomPartIndex);
                }
            }
        }

        return body;
    }
    
    // Repartit au hasard une liste de bodypart dans un couch
    private Couch Split (Body allParts) { 
        Couch tmp = new Couch (0);

        for (int i=0; i<maxBodyParts; i++) { //Pour chaque type de bodypart
            for (int j=0; j<allParts.parts[i].amount; j++) { //Pour chaque bodypart de ce type
                int ran = Random.Range(0,maxCushions);
                tmp.cushions[ran].parts[i].amount ++; //Ajouter le même bodypart a un coussin random du resultat
            }
        }

        return tmp;
    }
}