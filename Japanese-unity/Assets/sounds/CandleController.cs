using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public SoundData Data;
    public float IntensityMultiplier = 10f;
    private Light PLight;
    // Start is called before the first frame update
    void Start()
    {
        PLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float pastIntensty = PLight.intensity;
        PLight.intensity = Mathf.Lerp(pastIntensty, IntensityMultiplier * Data.SoundVolume, .99f);
    }
}
