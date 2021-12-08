using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition2_3 : MonoBehaviour
{
    public GameObject Floor;
    public GameObject WallLeft;
    public GameObject WallRight;
    public GameObject WallForward;
    public GameObject WallBack;
    public GameObject Plafond;
    public Material Material;

    public float Speed = 0.5f;
    public float TimeInBlack = 3.0f;

    //COLORS
    private Color ColorIn = new Color(0f, 0f, 0f, 1f);
    private Color ColorOut = new Color(0f, 0f, 0f, 0f);
    private string CurrentColor = "IN";
    private float StartTime = 0f;
    private bool isEntered = false;

    void Start()
    {
        Material.color = ColorOut;
    }

    void OnTriggerEnter(Collider ColorOut) {
        if (StartTime != 0 || CurrentColor != "IN") return;
        Debug.Log("ENTER");

        // set StartTime
        StartTime = Time.fixedTime;

        // set collider on wall back
        WallBack.GetComponent<BoxCollider>().enabled = true;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (StartTime == 0) return;
        
        if (CurrentColor == "IN"){
            float t = (Time.time - StartTime) * Speed;
            Material.color = Color.Lerp(ColorOut, ColorIn, t);

            if(t > TimeInBlack - 0.2f && isEntered == false)
            {
                isEntered = true;
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene3_house", LoadSceneMode.Additive);
                AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Scene4_tori", LoadSceneMode.Additive);
                AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("Scene2_flowers");
                Fade();
            }

            if (t > TimeInBlack)
            {
                // enelver les collider
                WallLeft.GetComponent<BoxCollider>().enabled = false;
                WallRight.GetComponent<BoxCollider>().enabled = false;
                WallForward.GetComponent<BoxCollider>().enabled = false;

                StartTime = Time.fixedTime;
                CurrentColor = "OUT";
            }
        } else{
            float t = (Time.time - StartTime) * Speed;
            Material.color = Color.Lerp(ColorIn, ColorOut, t);

            if (t > TimeInBlack)
            {
                StartTime = 0;
                CurrentColor = "";
            }
        }
    }

    public void Fade() {
      var audio = GetComponent<AudioSource>();

      StartCoroutine(DoFade(audio, audio.volume, 0 ));

    }

    public IEnumerator DoFade(AudioSource audio, float start, float end) {
        float counter = 0f;

        while (counter < 1f) {
            counter += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, end, easeInOutSine(counter / 1f));
            Debug.Log($"{counter} {audio.volume}");
            yield return null;
        }
    }

    float easeInOutSine(float x) {
        return -(Mathf.Cos(Mathf.PI * x) - 1f) / 2f;
    }
    
}
