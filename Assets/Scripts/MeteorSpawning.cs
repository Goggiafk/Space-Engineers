using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject meteor;
    public GameObject player;
    Vector3 spawnPosition;
    public float timeOnTask;
    public float repeatTime;
    public bool spawningOfMeteors;
    public GameObject startButton;
    public GameObject healthBar;
    public Text scores;
    bool scoreGaining = false;
    public static int scoreCount;
    public GameObject reactors;
    public Text rewardText;

    void Update()
    {
        if (scoreGaining)
        {
            scores.text = "Score: " + scoreCount.ToString();
        }
    }

    public void invokeSpawning()
    {
        rewardText.text = "";
        reactors.SetActive(true);
        scoreGaining = true;
        startButton.SetActive(false);
        healthBar.SetActive(true);
        InvokeRepeating("spawnGameObject", timeOnTask, repeatTime);
    }

    public void cancelSpawning()
    {
        reactors.SetActive(false);
        scoreCount = 0;
        scoreGaining = false;
        CancelInvoke("spawnGameObject");
        healthBar.SetActive(false);
        startButton.SetActive(true);
    }
   void spawnGameObject()
    {
        spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), player.transform.position.y + 10f, 0f);
        Instantiate(meteor, spawnPosition, Quaternion.Euler(Random.Range(1, 90), Random.Range(1, 90), Random.Range(1, 90)));
        scoreCount += 10;
        Vector3 customScale = new Vector3 (Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));
        meteor.transform.localScale = customScale;
    }
}
