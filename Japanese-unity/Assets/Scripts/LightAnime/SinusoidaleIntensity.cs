using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidaleIntensity : MonoBehaviour
{

public float strength = 1f;
public float frequency = 3f;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Light>().intensity = Mathf.Sin((Time.fixedTime * frequency) + 5f) + strength;
    }
}
