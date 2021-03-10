using UnityEngine;
using TMPro;

public class generalmanager : MonoBehaviour
{
    public Animator obsAnim;

    [Header("Attachments")]
    public TextMeshProUGUI max;
    public TextMeshProUGUI time;
    public GameObject lostPanel;
    public GameObject winpanel;

    [Header("Generals")]
    public float timeTowin;

    private float currentTime;
    private float startTime;
    private float timeSpent;

    public bool won;
    public bool isGameOver;

    void Start()
    {
        startTime = Time.time;
        currentTime = Time.time;

        timeSpent = currentTime - startTime;

        isGameOver = false;
        won = false;

        max.text = timeTowin.ToString();
    }

    void Update()
    {
        currentTime = Time.time;

        if (timeSpent < timeTowin)
        {
            timeSpent = currentTime - startTime;
            time.text = timeSpent.ToString("f0");
        }
        else
        {
            if (!won && !isGameOver)
            {
                Vector2 pos = new Vector2(0,0);
                Quaternion rot = Quaternion.Euler(0,0,0);
                GameObject go = Instantiate(winpanel,pos,rot);
            }

            won = true;
            isGameOver = true;
        }

        obsAnim.speed = currentTime/timeTowin + 0.3f;
    }
}
