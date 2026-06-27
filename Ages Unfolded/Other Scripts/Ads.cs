using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Api.AdManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour
{
    #region ads
#if UNITY_ANDROID
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712"; // Test ID
#elif UNITY_IPHONE
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/4411468910"; // Test ID
#else
    private string interstitialAdUnitId = "unused";
#endif
    void Start()
    {

    

    }
    public void ShowAdWithDelay(float delay)
    {
        StartCoroutine(ShowAdAfterDelay(delay));
    }

    private InterstitialAd interstitialAd;
    private static bool adAlreadyShown = false;

    [Header("UI Overlay to block input while ad shows")]
    public GameObject loadingOverlay; 

    [Header("Next Scene Name")]
    public string nextScene = "MainScene";

    IEnumerator ShowAdAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!adAlreadyShown)
        {
            adAlreadyShown = true;

            MobileAds.Initialize(initStatus =>
            {
                LoadInterstitial();
            });
        }
        else
        {
            StartCoroutine(ContinueLoadingAndLoadScene());
        }
    }

    public void LoadInterstitial()
    {
        var request = new AdRequest();
        InterstitialAd.Load(interstitialAdUnitId, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                Debug.LogError("Failed to load interstitial ad: " + error);
                StartCoroutine(ContinueLoadingAndLoadScene());
                return;
            }

            interstitialAd = ad;
            RegisterAdEvents(interstitialAd);

            ShowInterstitial();
        });
    }

    public void ShowInterstitial()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            if (loadingOverlay != null)
                loadingOverlay.SetActive(true);

            interstitialAd.Show();
        }
        else
        {
            StartCoroutine(ContinueLoadingAndLoadScene());
        }
    }

     void RegisterAdEvents(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("Ad opened"); };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ad closed, continue loading...");
            if (loadingOverlay != null)
                loadingOverlay.SetActive(false);

            StartCoroutine(ContinueLoadingAndLoadScene());
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Ad failed: " + error);
            if (loadingOverlay != null)
                loadingOverlay.SetActive(false);

            StartCoroutine(ContinueLoadingAndLoadScene());
        };
    }

    IEnumerator ContinueLoadingAndLoadScene()
    {
     
        yield return new WaitForSeconds(3f); 
        SceneManager.LoadScene(nextScene);
    }
    #endregion
}

