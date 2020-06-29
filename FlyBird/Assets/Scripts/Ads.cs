using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Ads : MonoBehaviour
{
    private BannerView bannerView;

    // Start is called before the first frame update
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-4475227603439511~9540871920";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-4475227603439511~9540871920";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4475227603439511/7867508239";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4475227603439511/7867508239";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}