using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OOOOOOOUTROOOO : MonoBehaviour
{
      public float Duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Fade();
    }

    // Update is called once per frame
    public void Fade() {
      var canvaGroup = GetComponent<CanvasGroup>();

      StartCoroutine(DoFade(canvaGroup, canvaGroup.alpha, 1.0f ));
    }

    public IEnumerator DoFade(CanvasGroup canvaGroup, float start, float end) {
        float counter = 0f;

        while (counter < Duration) {
            counter += Time.deltaTime;
            canvaGroup.alpha = Mathf.Lerp(start, end, easeInOutSine(counter / Duration));

            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync("BasicScene");
        AsyncOperation asyncLoad1 = SceneManager.UnloadSceneAsync("Scene3_house");
        AsyncOperation asyncLoad2 = SceneManager.UnloadSceneAsync("Scene4_tori");
        AsyncOperation asyncLoad3 = SceneManager.UnloadSceneAsync("Intro");
        AsyncOperation asyncLoad4 = SceneManager.UnloadSceneAsync("Welcome");

        AsyncOperation asyncLoad5 = SceneManager.LoadSceneAsync("End", LoadSceneMode.Additive);

        while (counter > 0) {
            counter -= Time.deltaTime;
            canvaGroup.alpha = Mathf.Lerp(start, end, easeInOutSine(counter / Duration));

            yield return null;
        }

        yield break;
    }

    float easeInOutSine(float x) {
        return -(Mathf.Cos(Mathf.PI * x) - 1f) / 2f;
    }
}
