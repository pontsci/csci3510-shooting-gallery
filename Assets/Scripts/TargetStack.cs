using UnityEngine;

public class TargetStack : Target
{
    public float impactForce;

    Rigidbody targetRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        targetRigidBody = target.GetComponent<Rigidbody>();
    }

    public override void Process(RaycastHit hit)
    {
        audioSource.PlayOneShot(hitSound);
        targetRigidBody.AddForce(-hit.normal * impactForce);
        effectScript.Play(hit, hitSound, hitEffect, effectDuration);
    }
}
