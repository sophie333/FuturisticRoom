using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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

    [SerializeField]
    private GameObject a_screwdriver;

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
        else if (player && opened)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                player.hasScrewdriver = true;
                a_screwdriver.SetActive(false);
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
