using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource popSound;
    [SerializeField] private float flyAmount = 10f;

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
        StartCoroutine(DestroySequence());

    }

    private IEnumerator DestroySequence()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * flyAmount);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        //Konfetti kodunu yaz
    }
}
