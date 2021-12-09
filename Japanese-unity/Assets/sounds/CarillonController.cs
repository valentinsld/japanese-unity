using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarillonController : MonoBehaviour
{

    public SoundData Data;
    public AudioSource Source;

    private float[] _samples;
    // private float SoundVolume;
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        _samples = new float[256];
    }

    // Update is called once per frame
    void Update()
    {
        Source.GetSpectrumData(_samples, 1, FFTWindow.Blackman);
        float Volume = 0f;
        for (int i = 0; i < _samples.Length; i++)
        {
            Volume += _samples[i];
        }
        Volume /= _samples.Length;
        Data.SoundVolume = Volume * 1000f;
    }
}
