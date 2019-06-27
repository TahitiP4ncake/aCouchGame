using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoSingleton<FlowManager> {
    public enum S { MENU, PLAY };
    public S state = S.MENU;

    public List<GameObject> menuTexts;
    public List<GameObject> gameTexts;

    private CouchManager couchManager { get { return CouchManager.instance; } }

    private void Update () {
        if (state == S.PLAY && DoubleTap ()) {
            GoToMenu ();
        }
    }

    private void GoToMenu () {
        state = S.MENU;
        SetVisible(menuTexts, true);
        SetVisible(gameTexts, false);
    }

    private void GoToPlay () {
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

    private bool DoubleTap () {
        return (Input.touchCount == 2 || Input.GetMouseButtonUp(1));
    }

    public void TwoPlayerTouch () { Touch (2); }
    public void ThreePlayerTouch () { Touch (3); }
    public void FourPlayerTouch () { Touch (4); }
    public void FivePlayerTouch () { Touch (5); }

    public void Touch (int amountOfPlayers) {
        if (state == S.MENU) {
            GameManager.instance.amountOfPlayers = amountOfPlayers;
            GoToPlay ();
        }

        if (state == S.PLAY){
            couchManager.UpdatePlayCouch ();
        }
    }
}