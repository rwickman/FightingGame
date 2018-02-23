using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMultiplayer : MonoBehaviour {
    public void SetupMultiPlayer() {
        //Presently stubbed so that a scene transition can be played
        SceneManager.LoadSceneAsync("Multiplayer");
    }
}