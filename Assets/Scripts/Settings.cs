using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioOfGame;
    public GameObject interfaceOfGame;
    public GameObject settingsOfGame;
    public Slider volumeSlider;
    public GameObject purchaceMenu;
    public Text purchaceText;
    public Button removeAdsButton1;
    public Button removeAdsButton2;
    public GameObject firstScreen;
    public GameObject modificationMenu;
    public GameObject firstSection;
    public GameObject secondSection;
    public GameObject thirdSection;

    void Start()
    {
        if (PlayerPrefs.HasKey("removeAds"))
        {
            if(PlayerPrefs.GetInt("removeAds") == 1)
            {
                removeAdsButton1.interactable = false;
                removeAdsButton2.interactable = false;
            }
        }
        if (PlayerPrefs.HasKey("volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        } else
        {
            SetVolume(0.45f);
            volumeSlider.value = 0.45f;
        }
    }

    public void closeFirstScreen()
    {
        firstScreen.SetActive(false);
    }
    public void openSettings()
    {
        settingsOfGame.SetActive(!settingsOfGame.activeInHierarchy);
        interfaceOfGame.SetActive(!interfaceOfGame.activeInHierarchy);
    }

    public void openPurchaces()
    {
        purchaceMenu.SetActive(!purchaceMenu.activeInHierarchy);
        interfaceOfGame.SetActive(!interfaceOfGame.activeInHierarchy);
        purchaceText.text = "";
    }

    public void openModifications()
    {
        modificationMenu.SetActive(!modificationMenu.activeInHierarchy);
        interfaceOfGame.SetActive(!interfaceOfGame.activeInHierarchy);
        firstSection.SetActive(false);
        secondSection.SetActive(false);
        thirdSection.SetActive(false);
    }

    public void resetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        float masterVolume = Mathf.Lerp(-40, 10, volume);
        if(volume == 0)
        {
            masterVolume = -80;
        }
        audioOfGame.SetFloat("volumeOfGame", masterVolume);
    }
}
