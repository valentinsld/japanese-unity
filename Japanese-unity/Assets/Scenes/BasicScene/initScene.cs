using UnityEngine;
using UnityEngine.SceneManagement;

// This script is on an object in the "Core" scene that
// we load initially.

public class initScene : MonoBehaviour
{
    private void Awake()
    {
        AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Additive);
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Scene1_room", LoadSceneMode.Additive);
    }

}
