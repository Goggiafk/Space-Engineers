using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerManager : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3944554";
#elif UNITY_ANDROID
    private string gameId = "3944555";
#endif
    public bool isTestBool;
    // Start is called before the first frame update
    void Start()
    {
        advertismentInitialize();
        if (!PlayerPrefs.HasKey("removeAds"))
        {
            if (!(PlayerPrefs.GetInt("removeAds") == 1))
            {
                StartCoroutine(showBannerOnInitialization());
            }
        }
    }

    public void showVideo()
    {
        if (!PlayerPrefs.HasKey("removeAds"))
        {
            if (!(PlayerPrefs.GetInt("removeAds") == 1))
            {
                if (Advertisement.IsReady("video"))
                {
                    StartCoroutine(Timer(0.5f, () => { Advertisement.Show("video"); }));
                }
            }
        }
    }

    void advertismentInitialize()
    {
        Advertisement.Initialize(gameId, isTestBool);
    }
    IEnumerator showBannerOnInitialization()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show("banner");
    }

    IEnumerator Timer(float time, System.Action action)
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}
