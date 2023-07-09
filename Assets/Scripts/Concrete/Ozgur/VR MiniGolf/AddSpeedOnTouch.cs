using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOnTouch : MonoBehaviour
{
    public string targetTag;
    public GameManager gameManager;

    private Vector3 prevPos;
    private Vector3 velocity;
    private Collider clubCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        clubCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = (transform.position - prevPos) / Time.deltaTime;
        //prevPos = transform.position;
    }

    private void FixedUpdate()
    {
        velocity = (transform.position - prevPos) / Time.deltaTime;
        prevPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            Debug.Log("Colliding...");

            Vector3 collisionPos = clubCollider.ClosestPoint(other.transform.position);
            Vector3 collisionNorm = other.transform.position - collisionPos;
            

            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNorm);

            Rigidbody rb = other.attachedRigidbody;
            rb.velocity = projectedVelocity;
            other.GetComponent<GolfBall>().PlayHitSound(); //Test edilmedi. Hataya sebep verebilir.

            gameManager.currentHitNumber++;
        }
    }
}
