using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlinker : MonoBehaviour {
    //=============================================================
    private Text text;

    private Coroutine coroutine;

    //=============================================================
    private void Init () {
        text = GetComponent<Text>();
    }

    private void Awake () {
        Init();
    }

    private void OnEnable () {
        coroutine = StartCoroutine(BlinkText(0.6f,360));
    }

    private void OnDisable () {
        StopCoroutine(coroutine);
    }

    //=============================================================
    /// <summary>
    /// テキストを点滅させる
    /// </summary>
    private IEnumerator BlinkText (float power,float speed) {
        float time = 0;
        while(true) {
            time += Time.deltaTime * speed;
            text.color = new Color(0,0,0,1 - Mathf.Abs(Mathf.Sin(time * Mathf.Deg2Rad) * power));
            yield return null;
        }
    }
}