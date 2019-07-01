using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CouchManager : MonoSingleton<CouchManager> {
    public Couch playCouch;
    public List<TextMeshProUGUI> texts;

    private GameManager gm { get { return GameManager.instance; } }

    private PlayerSettings settings { get { return PlayerSettings.instance; } }

    public void UpdatePlayCouch () {
        //int partAmount = settings.players.Select(x => x.ToCushion().amountOfParts).ToList().Sum();
        int partAmount = gm.maxParts.amountOfParts;
        Difficulty dif = settings.difficulty;


        playCouch = Split(RandomBody((int)(partAmount*dif.minParts), (int)(partAmount*dif.maxParts)));
        List<string> textsList = playCouch.Display();
        for (int i=0; i<texts.Count; i++) {
            texts[i].text = textsList[i];
        }
    }

    // Generates a random body containing min to max bodyparts
    private Cushion RandomBody (int min, int max) {
        Cushion body = new Cushion (0, 2, 0, 0); //2 feet for stability

        if (max > gm.maxParts.amountOfParts) {
            Debug.LogError ("Error : You're trying to put too many body parts ("+max+") in the couch ("+
            gm.maxParts.amountOfParts+" body parts total)");
        } else {
            int amountOfPartsToSplit = Random.Range (min, max+1) - body.amountOfParts;

            // List is {0, 1, 2, 3... }
            List<int> possibleParts = new List<int>();
            for (int i=0; i<GameManager.maxBodyParts; i++) {
                possibleParts.Add(i);
            }

            for (int i=0; i<amountOfPartsToSplit; i++) {
                int randomPartIndex = Random.Range(0, possibleParts.Count);
                BodyPart randomPart = body.parts[possibleParts[randomPartIndex]];

                randomPart.amount ++;

                if (randomPart.amount >= gm.maxParts.AmountOf(randomPart.type)) {
                    possibleParts.RemoveAt(randomPartIndex);
                }
            }
        }

        return body;
    }
    
    // Repartit au hasard une liste de bodypart dans un couch
    private Couch Split (Cushion allParts) { 
        Couch tmp = new Couch ();

        for (int i=0; i<GameManager.maxBodyParts; i++) { //Pour chaque type de bodypart
            for (int j=0; j<allParts.parts[i].amount; j++) { //Pour chaque bodypart de ce type
                int ran = Random.Range(0,GameManager.maxCushions);
                tmp.cushions[ran].parts[i].amount ++; //Ajouter le même bodypart a un coussin random du resultat
            }
        }

        return tmp;
    }

}