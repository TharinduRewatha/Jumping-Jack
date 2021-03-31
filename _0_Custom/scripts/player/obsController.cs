using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour
{
    [Header("Attachments")]
    public GameObject point01;
    public GameObject point02;

    [Header("Generals")]
    public float[] speedRange;
    public float timeToChange;

    public float speed;

    private Vector3 desiredPos;

    private float currentTime;
    private float startTime;
    private float timeSpent;

    private void Start()
    {
        currentTime = Time.time;
        startTime = Time.time;

        changePos();
    }

    void Update()
    {
        currentTime = Time.time;
        timeSpent = currentTime - startTime;

        if (timeSpent >= timeToChange)
        {
            changePos();
            startTime = Time.time;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position,desiredPos,step);
    }

    private void changePos()
    {
        if (desiredPos == point01.transform.position)
        {
            desiredPos = point02.transform.position;
        }
        else
        {
            desiredPos = point01.transform.position;
        }

        setSpeed();
    }

    private void setSpeed()
    {
        float fspeed = Random.Range(speedRange[0],speedRange[1]);
        speed = Mathf.RoundToInt(fspeed);
    }
}
