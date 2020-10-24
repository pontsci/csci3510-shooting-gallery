using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject fpsController;
    public GameObject terrain;
    public AudioClip portalSound;

    AudioSource audioSource;

    SpawnPoint spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        spawnPoint = new SpawnPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 position = spawnPoint.Generate(other.gameObject, terrain);
            MoveTo(other.gameObject, position);
            audioSource.PlayOneShot(portalSound);
        }
    }

    void MoveTo(GameObject player, Vector3 position)
    {
        CharacterController controllerScript = player.GetComponent<CharacterController>();
        controllerScript.enabled = false;
        player.transform.position = position;
        controllerScript.enabled = true;
    }
}
