using UnityEngine;

public class ShowAds : MonoBehaviour
{
    public Ads ad; 

    private void Start()
    {
        ad.LoadInterstitial();
        ad.ShowInterstitial();
    }

    private void Update()
    {
      
    }


}
