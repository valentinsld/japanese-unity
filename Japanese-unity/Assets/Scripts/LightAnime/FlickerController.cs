using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public float minDelay = 0.01f;
    public float maxDelay = 0.2f;
    void Update()
    {
        if(isFlickering == false) {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight() {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
