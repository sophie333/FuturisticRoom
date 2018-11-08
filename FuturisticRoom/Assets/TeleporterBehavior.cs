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

    // Use this for initialization
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
                s_screwdriver.Play();
                StartCoroutine(Wait());
                flare.SetActive(false);
                bubbles.SetActive(true);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}

