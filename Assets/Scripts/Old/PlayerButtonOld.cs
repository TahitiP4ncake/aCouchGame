using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerButtonOld : MonoBehaviour {
    [Range(0,5)]
    public int amountOfPlayers;
    public EventTrigger eventTrigger;

    private void Start() {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData data) {
        GameManager.instance.amountOfPlayers = amountOfPlayers;
    }
}