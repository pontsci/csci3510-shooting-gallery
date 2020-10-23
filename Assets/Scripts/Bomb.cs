using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Target
{
    public override void Process(RaycastHit hit)
    {
        if (gameObject.GetComponent<Renderer>() == true)
        {
            audioSource.PlayOneShot(hitSound);
            gameObject.GetComponent<Renderer>().enabled = false;
            effectScript.Play(hit, hitSound, hitEffect, effectDuration);
            if (gameObject.tag == "Head")
            {
                GameObject bombBody = GameObject.FindGameObjectWithTag("Bomb");
                bombBody.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GameObject bombHead = GameObject.FindGameObjectWithTag("Head");
                bombHead.GetComponent<Renderer>().enabled = false;
            }
        }
        Destroy(target, effectDuration);
    }
}
