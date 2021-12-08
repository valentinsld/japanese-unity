using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootStep : MonoBehaviour
{
[SerializeField]
    private PlayerMovement player;

    private AudioSource audio;

    public float delay = 0.5f;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Debug.Log(audio);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.IsMoving() + " " +  player.IsGrounded());
        time += Time.deltaTime;

        if(player.IsMoving() && player.IsGrounded() && !audio.isPlaying && time > delay){
            audio.volume = Random.Range(.8f,1.0f);
            audio.pitch = Random.Range(.8f, 1.2f);
            audio.Play();
            time = 0;
        }
    }
}