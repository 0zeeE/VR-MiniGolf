using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private int currentHoleNumber = 0;
    public List<Transform> startingPositions;
    public Rigidbody ballRigidbody;
    public GameObject Ball;

    public int currentHitNumber = 0;
    private List<int> previousHitNumbers = new List<int>();

    public TextMeshProUGUI holeText;
    public TextMeshProUGUI hitNumberTest;
    

    void Start()
    {
        //Topun konumunu en basta hesaplamak icin
        ballRigidbody.transform.position = startingPositions[currentHoleNumber].position;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScoreToTMP();
        SwitchOtherHoleDebug();
    }

    public void GoToNextHole()
    {
        currentHoleNumber += 1;

        if(currentHoleNumber >= startingPositions.Count)
        {
            Debug.Log("sona varildi");
            Ball.GetComponent<GolfBall>().DestroyWithParticleEffect();

        }
        else
        {
            ballRigidbody.transform.position = startingPositions[currentHoleNumber].position;

            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }

        previousHitNumbers.Add(currentHitNumber);
        currentHitNumber = 0;

        DisplayScore();
    }

    public void DisplayScore()
    {
        for (int i = 0; i < previousHitNumbers.Count; i++)
        {
            Debug.Log("Delik " + (i + 1) + "-" + previousHitNumbers[i]);
        }
    }

    public void DisplayScoreToTMP()
    {
        for(int i =0; i < previousHitNumbers.Count; i++)
        {
            holeText.text = "HOLE " + (i + 1);
            hitNumberTest.text = "Hit amount : " + previousHitNumbers[i];
        }
    }

    public void ReplaceBall()
    {
        ballRigidbody.transform.position = startingPositions[currentHoleNumber].position;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        Ball.GetComponent<GolfBall>().PlayPopSound(); //Test edilmedi. Hataya sebep verebilir.
    }

    public void SwitchOtherHoleDebug()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            GoToNextHole();
        }
    }

    //SceneManagement Kismi buraya gelecek

}