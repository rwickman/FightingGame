using UnityEngine;
using UnityEngine.Events;

public class BtnMultiPlayer : UnityEvent {
    public BtnMultiPlayer() {
        this.AddListener(SetupMultiPlayer);
    }
    public void SetupMultiPlayer() {

    }
}