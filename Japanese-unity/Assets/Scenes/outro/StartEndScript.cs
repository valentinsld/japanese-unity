using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Outro", LoadSceneMode.Additive);
    }
}
