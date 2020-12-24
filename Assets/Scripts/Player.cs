using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject menuOfDeath;
    public int healthOfRocket;
    public int maxNumberOfHealth;

    public Image[] hearts;
    public Sprite heartSprite;
    public Sprite emptySprite;

    public Text text;
    public Text scoreText;
    public Image timerForVideo;
    public static float timeForTask = 100;
    float timeForTaskBar = 0;
    bool checkDeath = false;
    public Button restoreButton;
    public Text moneyText;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("highestScore").ToString();
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
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
            StartCoroutine(Timer(0f, () => { text.text = "Ouch!"; }));
            StartCoroutine(Timer(0.8f, () => { text.text = ""; }));

            if (healthOfRocket > 0)
            {
                healthOfRocket--;
            }
            if(healthOfRocket <= 0)
            {
                menuOfDeath.SetActive(true);
                if (MeteorSpawning.scoreCount > PlayerPrefs.GetInt("highestScore"))
                {
                    PlayerPrefs.SetInt("highestScore", MeteorSpawning.scoreCount);
                    scoreText.text = "Highest Score:\n" + PlayerPrefs.GetInt("highestScore").ToString();
                }
                checkDeath = true;
                Time.timeScale = 0.05f;
            }
        }
    }

    void Update()
    {
        if (healthOfRocket > maxNumberOfHealth)
        {
            healthOfRocket = maxNumberOfHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthOfRocket)
            {
                hearts[i].sprite = heartSprite;
            }
            else
            {
                hearts[i].sprite = emptySprite;
            }
            if (i < maxNumberOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

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
