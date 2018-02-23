using UnityEngine;
using UnityEngine.Events;

public class BtnSinglePlayer : UnityEvent {
    public BtnSinglePlayer() {
        this.AddListener(SetupSinglePlayer);
    }
    public void SetupSinglePlayer() {

    }
}