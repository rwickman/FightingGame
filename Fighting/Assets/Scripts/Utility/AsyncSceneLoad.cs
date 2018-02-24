using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class AsyncSceneLoad : MonoBehaviour {
    [Tooltip("The name of the scene to load when LoadScene is called.")]
    public string SceneName;
    public void LoadScene(float time = 1.0f)
    {
        StartCoroutine(LoadSceneCo(time));
    }

    IEnumerator LoadSceneCo(float time = 1.0f)
    {
        //Presently stubbed so that a scene transition can be played
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);
        float time_d = 0.0f;
        while(!async.isDone || time_d < time)
        {
            yield return null;
            time_d += Time.deltaTime;
        }
    }

}