using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour {

    [Header("Flicker Options:")]
    [Range(0, 100)]
    public float flickerTimer;
    public int onOff;

    public void Start() {
        StartCoroutine(Flicker(flickerTimer));
    }

    public void Update() {
        onOff = Random.Range(0, 2);
    }

    public IEnumerator Flicker(float time) {
        yield return new WaitForSeconds(time);
        if(onOff == 0) {
            gameObject.GetComponent<Light>().enabled = false;
        } else {
            gameObject.GetComponent<Light>().enabled = true;
        }
        StartCoroutine(Flicker(flickerTimer));
    }
}
