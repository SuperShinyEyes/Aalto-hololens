using UnityEngine;

public class SphereSounds : MonoBehaviour {

    AudioSource audioSource = null;
    AudioClip impactClip = null;
    AudioClip rollingClip = null;

    bool rolling = false;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 20f;

        impactClip = Resources.Load<AudioClip>("Impact");
        rollingClip = Resources.Load<AudioClip>("Rolling");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= 0.1f)
        {
            audioSource.clip = impactClip;
            audioSource.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rigid = this.gameObject.GetComponent<Rigidbody>();

        if (!rolling && rigid.velocity.magnitude >= 0.01f)
        {
            rolling = true;
            audioSource.clip = rollingClip;
            audioSource.Play();
        }
        else if (rolling && rigid.velocity.magnitude <= 0.01f)
        {
            rolling = false;
            audioSource.Stop();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (rolling)
        {
            rolling = false;
            audioSource.Stop();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
