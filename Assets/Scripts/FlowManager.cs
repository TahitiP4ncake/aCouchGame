using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowManager : MonoSingleton<FlowManager> {
    public enum S { MENU, PLAY };
    public S state = S.MENU;

    public List<GameObject> menuTexts;
    public List<GameObject> gameTexts;

    public GameObject twoPlayerPanel, threePlayerPanel, fourPlayerPanel, fivePlayerPanel;

    private CouchManager couchManager { get { return CouchManager.instance; } }

    private void Update () {
        if (Input.touchCount == 2 || Input.GetMouseButtonUp(1)) {
            if (state == S.PLAY) {
                GoToMenu ();
            }
        }
    }

    private void GoToMenu () {
        state = S.MENU;
        SetVisible(menuTexts, true);
        SetVisible(gameTexts, false);
    }

    private void GoToPlay (int amountOfPlayers) {
        GameManager.instance.amountOfPlayers = amountOfPlayers;
        state = S.PLAY;
        couchManager.UpdatePlayCouch ();
        SetVisible(menuTexts, false);
        SetVisible(gameTexts, true);
    }

    private void SetVisible (List<GameObject> target, bool state) {
        foreach (GameObject go in target) {
            go.SetActive(state);
        }
    }

    public void TouchPlayerPanel (int playerIndex) {
        if (state == S.MENU) {
            GoToPlay (playerIndex);
        }

        if (state == S.PLAY){
            couchManager.UpdatePlayCouch ();
        }
    }
}