using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject menuOfDeath;
    public static int healthOfRocket = 3;
    public Text text;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Text scoreText;
    public Image timerForVideo;
    public static float timeForTask = 100;
    float timeForTaskBar = 0;
    bool checkDeath = false;
    public Button restoreButton;

    void Start()
    {
        scoreText.text = "Highest Score:\n" + PlayerPrefs.GetInt("highestScore").ToString();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            MeshRenderer rocketRendered = GetComponent<MeshRenderer>();
            Collider rockCollider = GetComponent<Collider>();
            StartCoroutine(Timer(0f, () => {rockCollider.enabled = false; }));
            StartCoroutine(Timer(0f, () => { rocketRendered.enabled = false; }));
            StartCoroutine(Timer(0.5f, () => { rocketRendered.enabled = true; }));
            StartCoroutine(Timer(1f, () => { rocketRendered.enabled = false; }));
            StartCoroutine(Timer(1.5f, () => { rocketRendered.enabled = true; }));
            StartCoroutine(Timer(1.5f, () => { rockCollider.enabled = true; }));

            healthOfRocket--;
            StartCoroutine(Timer(0f, () => { text.text = "Ouch!"; }));
            StartCoroutine(Timer(0.8f, () => { text.text = ""; }));

            switch (healthOfRocket)
            {
                case 0:
                    heart1.SetActive(false);
                    menuOfDeath.SetActive(true);
                        if (MeteorSpawning.scoreCount > PlayerPrefs.GetInt("highestScore"))
                        {
                        PlayerPrefs.SetInt("highestScore", MeteorSpawning.scoreCount);
                        scoreText.text = "Highest Score:\n" + PlayerPrefs.GetInt("highestScore").ToString();
                        }
                    checkDeath = true;
                    Time.timeScale = 0.05f;
                    break;
                case 1:
                    heart2.SetActive(false);
                    break;
                case 2:
                    heart3.SetActive(false);
                    break;
            }
        }
    }

    void Update()
    {
        if (checkDeath)
        {
            timeForTask -= Time.timeScale * 2;
            timeForTaskBar = Mathf.Clamp(timeForTask, 0f, 100f) / 100;
            timerForVideo.fillAmount = timeForTaskBar;
            if (timerForVideo.fillAmount <= 0)
            {
                checkDeath = false;
                restoreButton.interactable = false;
                if (AdManager.checkWatched)
                {
                    AdManager.checkWatched = false;
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
    public void restorePlayer()
    {
        restoreButton.interactable = true;
        AdManager.checkWatched = false;
        checkDeath = false;
        timeForTask = 100;
        timerForVideo.fillAmount = 1;
        Time.timeScale = 1;
        menuOfDeath.SetActive(false);
        healthOfRocket = 3;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
    }

    IEnumerator Timer(float time, System.Action action)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}
