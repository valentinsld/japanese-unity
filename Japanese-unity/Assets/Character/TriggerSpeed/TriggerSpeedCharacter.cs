using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeedCharacter : MonoBehaviour
{
    private bool mFaded = false;
    public float DurationFade = 0.6f;
    public float WaitSeconds = 4f;
    private float InitSpeedCharatcer;
    public float TargetSpeedCharatcer = 2f;
    public PlayerMovement CharacterPlayer;
    public MouseLook CharacterCamera;
    public float InitMouseSensivityY;
    public float InitMouseSensivityX;
      public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        CharacterPlayer = GameObject.Find("PF_Perso").GetComponent<PlayerMovement>();
        InitSpeedCharatcer = CharacterPlayer.speed;
        CharacterCamera = GameObject.Find("MainCamera").GetComponent<MouseLook>();
        InitMouseSensivityY = CharacterCamera.mouseSensitivityY;
        InitMouseSensivityX = CharacterCamera.mouseSensitivityX;

        Door.transform.Rotate(0f, 0.0f, 0.0f, Space.World);

        if (!CharacterPlayer)
        {
            Debug.LogError("NO CharacterPlayer");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (mFaded) return;
        Debug.LogWarning($"Collid {CharacterPlayer.speed}");

        Fade();
    }

    public void Fade() {

      StartCoroutine(DoFade(InitSpeedCharatcer, TargetSpeedCharatcer));

      mFaded = !mFaded;
    }

    public IEnumerator DoFade(float start, float end) {
        float counter = 0f;

        while (counter < DurationFade) {
            counter += Time.deltaTime;
            CharacterPlayer.speed = Mathf.Lerp(start, end, counter / DurationFade);
            CharacterCamera.mouseSensitivityY = Mathf.Lerp(InitMouseSensivityY, InitMouseSensivityY / 10f, counter / DurationFade);
            CharacterCamera.mouseSensitivityX = Mathf.Lerp(InitMouseSensivityX, InitMouseSensivityX / 10f, counter / DurationFade);
            yield return null;
        }

        yield return new WaitForSeconds(WaitSeconds);
        GetComponent<ParticulesCircle>().DoPath = true;
        if (Door) StartCoroutine(OpenDoor());

        while (counter > 0) {
            counter -= Time.deltaTime;
            CharacterPlayer.speed = Mathf.Lerp(start, end, counter / DurationFade);
            CharacterCamera.mouseSensitivityY = Mathf.Lerp(InitMouseSensivityY, InitMouseSensivityY / 10f, counter / DurationFade);
            CharacterCamera.mouseSensitivityX = Mathf.Lerp(InitMouseSensivityX, InitMouseSensivityX / 10f, counter / DurationFade);
            yield return null;
        }

        yield break;
    }

        public IEnumerator OpenDoor() {
        float counter = 0f;

        yield return new WaitForSeconds(2);

        while (counter < DurationFade * 5) {
            counter += Time.deltaTime;
            Door.transform.Rotate(0f, Mathf.Lerp(0.0f, -0.5f, counter / DurationFade * 5), 0.0f, Space.World);
            yield return null;
        }

        yield break;
    }
}
