using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    private Camera fpsCamera;
    private float nextTimeToFire;

    public ParticleSystem muzzleFlash;

    public AudioClip[] gunshots = new AudioClip[4];
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        fpsCamera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        nextTimeToFire = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool ready = Time.time >= nextTimeToFire;
        if(ready && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        int rand = Random.Range(0, 4);
        Debug.Log("Gunshot at index: " + rand);
        audioSource.PlayOneShot(gunshots[rand]);
        
        if(muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log("hit: " + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Process(hit);
            }

            nextTimeToFire = Time.time + 1f;
        }
    }
}
