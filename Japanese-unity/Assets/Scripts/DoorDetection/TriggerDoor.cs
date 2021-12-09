using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    [SerializeField] private Animator myDoorController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) {
            myDoorController.SetBool("playSpin2" , true);
        }
    }
}
