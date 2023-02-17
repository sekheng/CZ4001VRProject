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

    LTDescr tweenAlpha = null;

    public const string FinishedTweening = "DONE FADING";

    // Start is called before the first frame update
    void Start()
    {
        tweenAlpha = LeanTween.alpha(diedImage.transform as RectTransform, 1.0f, fadeTime);
        tweenAlpha.setOnComplete(() =>
        {
            ObserverSystem.Instance.TriggerEvent(FinishedTweening);
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
        });
    }
}
