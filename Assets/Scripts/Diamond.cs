using UnityEditor.UIElements;
using UnityEngine;

public class Diamond : Target
{
    float time;
    float startingRotationAmount;
    float rotationAmount;

    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        startingRotationAmount = 10f;
        rotationAmount = startingRotationAmount;

        SetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        target.transform.Rotate(rotation * time);

        if(rotationAmount > startingRotationAmount)
        {
            IncRotation(-0.5f);
        }
    }

    void IncRotation(float delta)
    {
        rotationAmount += delta;
        SetRotation();
    }

    void SetRotation()
    {
        rotation = new Vector3(rotationAmount, rotationAmount, rotationAmount);
    }

    public override void Process(RaycastHit hit)
    {
        IncRotation(250);
        audioSource.PlayOneShot(hitSound);
        effectScript.Play(hit, hitSound, hitEffect, effectDuration);
    }
}
