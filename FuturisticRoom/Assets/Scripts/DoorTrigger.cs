using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private AudioSource s_slidingDoorOpen;


    [SerializeField]
    private AudioSource s_slidingDoorClose;

    [SerializeField]
    private GameObject t_openDoor;

    private bool opened = false;

    private void OnTriggerStay(Collider other)
    {
        FirstPersonController player = other.GetComponent<FirstPersonController>();

        if (player && !opened)
        {
            t_openDoor.SetActive(true);

            if (Input.GetKeyDown(KeyCode.O))
            {
                opened = true;
                s_slidingDoorOpen.Play();
                anim.Play("DoorOpen");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirstPersonController player = other.GetComponent<FirstPersonController>();

        if (player)
        {
            t_openDoor.SetActive(false);

            if (opened)
            {
                opened = false;
                s_slidingDoorClose.Play();
                anim.Play("DoorClose");
            }
        }
    }
}
