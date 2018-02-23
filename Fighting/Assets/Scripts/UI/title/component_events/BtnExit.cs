using UnityEngine;
using UnityEngine.Events;

public class BtnExit : UnityEvent {
    public BtnExit() {
        this.AddListener(SetupExit);
    }
    public void SetupExit() {
#if UNITY_EDITOR
        Debug.Break();
#else
        Application.Quit();
#endif
    }
}