using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TeleporterBehavior : MonoBehaviour {

    [SerializeField]
    private AudioSource s_explosion;

    [SerializeField]
    private AudioSource s_welding;

    [SerializeField]
    private AudioSource s_screwdriver;

    [SerializeField]
    private GameObject flare;

    [SerializeField]
    private GameObject bubbles;

    [SerializeField]
    private GameObject t_repairTeleporter;
    
    void Start () {
        s_explosion.Play();
        s_welding.Play();
        flare.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        FirstPersonController player = other.GetComponent<FirstPersonController>();

        if (player && player.hasScrewdriver)
        {
            t_repairTeleporter.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.hasScrewdriver = false;
                t_repairTeleporter.SetActive(false);

                s_screwdriver.Play();
                StartCoroutine(Wait(player));
            }
        }
    }

    IEnumerator Wait(FirstPersonController player)
    {
        yield return new WaitForSeconds(5);
        flare.SetActive(false);
        s_welding.Stop();
        bubbles.SetActive(true);

    }
}

