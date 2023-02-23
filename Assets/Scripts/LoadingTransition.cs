using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Loading scene transition
/// </summary>
public class LoadingTransition : MonoBehaviour
{
    [SerializeField, Tooltip("image to fade")]
    Image diedImage;
    [SerializeField, Tooltip("Time taken to fade in/out")]
    float fadeTime = 0.5f;
    [SerializeField, Tooltip("camera to make it still visible")]
    Camera myCam;
    LTDescr tweenAlpha = null;

    public const string FinishedTweening = "DONE FADING";

    // Start is called before the first frame update
    void Start()
    {
        tweenAlpha = LeanTween.alpha(diedImage.transform as RectTransform, 1.0f, fadeTime);
        tweenAlpha.setOnComplete(() =>
        {
            ObserverSystem.Instance.TriggerEvent(FinishedTweening);
            myCam.gameObject.SetActive(true);
        });
        ScoreManager.instance.FinishEvent += DoneLoadingMainScene;
    }

    private void OnDestroy()
    {
        ScoreManager.instance.FinishEvent -= DoneLoadingMainScene;
    }

    void DoneLoadingMainScene()
    {
        // fade it back to translucent
        tweenAlpha = LeanTween.alpha(diedImage.transform as RectTransform, 0.0f, fadeTime);
        tweenAlpha.setOnComplete(() =>
        {
            ObserverSystem.Instance.TriggerEvent(FinishedTweening);
            myCam.gameObject.SetActive(false);
        });
    }
}
