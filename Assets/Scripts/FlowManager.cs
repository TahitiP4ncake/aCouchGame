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
        if (state == S.MENU && Touch ()) {
            GoToPlay ();
        }

        if (state == S.PLAY && Touch ()){
            couchManager.UpdatePlayCouch ();
        }

        if (state == S.PLAY && DoubleTouch ()) {
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

    private bool Touch () {
        return (Input.touchCount == 1 || Input.GetMouseButtonDown(0));
    }

    private bool DoubleTouch () {
        return (Input.touchCount == 2 || Input.GetMouseButtonDown(1));
    }
}