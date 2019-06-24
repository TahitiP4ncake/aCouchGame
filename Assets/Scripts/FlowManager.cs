using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour {
    public enum S { MENU, PLAY };
    public S state = S.MENU;

    public static FlowManager instance;

    private void Update () {
        if (state == S.MENU && Input.touchCount == 1) {
            //assign number of players
            GameManager.NewCouch();
        }

        if (state == S.PLAY && Input.touchCount == 1){
            GameManager.NewCouch();
        }

        if (state == S.PLAY && Input.touchCount == 2) {
        }
    }

    private void GoToMenu () {
        state = S.MENU;
    }

    private void GoToPlay () {
        state = S.PLAY;
    }
}