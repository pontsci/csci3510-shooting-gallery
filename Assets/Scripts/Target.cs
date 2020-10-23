using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;

    public GameObject effectsManager;
    public GameObject hitEffect;
    public float effectDuration = 0.1f;

    public AudioClip hitSound;

    protected AudioSource audioSource;

    protected Effect effectScript;

    private void Awake()
    {
        //init must occur in awake method
        effectScript = effectsManager.GetComponent<Effect>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public virtual void Process(RaycastHit hit)
    {

    }
}
