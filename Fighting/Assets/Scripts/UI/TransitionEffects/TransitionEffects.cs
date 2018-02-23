using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransitionEffects : MonoBehaviour {
    private Image panel;
    private Color pInitColor;
    
    void Start() {
        panel = GetComponent<Image>();
        pInitColor = panel.color;
    }

    public void Effect(string effect_name) {
        StartCoroutine(effect_name);
    }

    IEnumerator DoFade(float time = 1.0f) {
        float delta_accum = 0.0f;

        while(delta_accum < time)
        {
            panel.color = Color.Lerp(pInitColor, Color.clear, delta_accum / time);
            delta_accum += Time.deltaTime;
            yield return null;
        }

        panel.color = Color.clear;
    }

    IEnumerator DoUnFade(float time = 1.0f) {
        float delta_accum = 0.0f;

        while(delta_accum < time)
        {
            panel.color = Color.Lerp(Color.clear, pInitColor, delta_accum / time);
            delta_accum += Time.deltaTime;
            yield return null;
        }

        panel.color = pInitColor;
    }
}