using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerButton : MonoBehaviour, IPointerClickHandler {
    public int playerIndex;

    public void OnPointerClick (PointerEventData ped) {
        if (ped.button == PointerEventData.InputButton.Left) {
            FlowManager.instance.TouchPlayerPanel(playerIndex);
        }
    }
}