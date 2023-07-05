using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource popSound;

    // Start is called before the first frame update
    public void PlayHitSound()
    {
        hitSound.Play();
    }

    public void PlayPopSound()
    {
        popSound.Play();
    }

    public void DestroyWithParticleEffect()
    {
        Debug.Log("Eklenecek");
    }
}
