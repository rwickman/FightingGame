using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonSingleplayer : MonoBehaviour {
    public void SetupSinglePlayer() {
        SceneManager.LoadSceneAsync("Singleplayer");
    }
}