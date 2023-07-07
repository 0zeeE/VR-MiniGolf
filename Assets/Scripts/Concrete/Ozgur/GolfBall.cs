using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource popSound;
    [SerializeField] private float flyAmount = 10f;
    [SerializeField] private GameObject confettiParticle;
    [SerializeField] private Vector3 ballPos;
    [SerializeField] private Quaternion ballQuaternion;
    

    // Start is called before the first frame update

    private void Start()
    {
        
    }

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
        //bitmedi
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * flyAmount);
        yield return new WaitForSeconds(1);
        Instantiate(confettiParticle, this.gameObject.transform);
        //this.gameObject.GetComponent<MeshRenderer>().
        yield return new WaitForSeconds(1);
        
    }


    private void AA()
    {
        Destroy(this.gameObject);
    }
}
