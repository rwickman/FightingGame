using UnityEngine;
using UnityEngine.Events;

public class BtnSettings : UnityEvent {
    public BtnSettings() {
        this.AddListener(SetupSettings);
    }
    public void SetupSettings() {

    }
}