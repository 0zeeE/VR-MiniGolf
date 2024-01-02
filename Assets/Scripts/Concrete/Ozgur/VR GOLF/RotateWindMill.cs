using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindMill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject windMill;
    public float rotateSpeed = 1f;

    void Update()
    {
        windMill.transform.Rotate(0, 0, rotateSpeed  * Time.deltaTime);
    }
}
