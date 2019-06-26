using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoSingleton<FlowManager> {
    public enum S { MENU, PLAY };
    public S state = S.MENU;

    private CouchManager couchManager { get { return CouchManager.instance; } }

    private void Update () {
        if (state == S.MENU && Input.touchCount == 1) {
            //assign number of players
            GoToPlay ();
        }

        if (state == S.PLAY && Input.touchCount == 1){
            couchManager.UpdatePlayCouch ();
        }

        if (state == S.PLAY && Input.touchCount == 2) {
            GoToMenu ();
        }
    }

    private void GoToMenu () {
        state = S.MENU;
    }

    private void GoToPlay () {
        state = S.PLAY;
        couchManager.UpdatePlayCouch ();
    }
}