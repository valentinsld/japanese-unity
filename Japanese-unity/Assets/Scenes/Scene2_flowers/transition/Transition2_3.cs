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

            Debug.Log(t);

            if (t > TimeInBlack)
            {
                // enelver les collider
                WallLeft.GetComponent<BoxCollider>().enabled = false;
                WallRight.GetComponent<BoxCollider>().enabled = false;
                WallForward.GetComponent<BoxCollider>().enabled = false;
            
                // load scenes
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene3_house", LoadSceneMode.Additive);
                AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("Scene2_flowers");

                StartTime = Time.fixedTime;
                CurrentColor = "OUT";
            }
        } else{
            float t = (Time.time - StartTime) * Speed;
            Material.color = Color.Lerp(ColorIn, ColorOut, t);

            Debug.Log(t);

            if (t > TimeInBlack)
            {
                StartTime = 0;
                CurrentColor = "";
            }
        }
    }
}
