using UnityEngine;

public class ButtonExit : MonoBehaviour {
    public void SetupExit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}