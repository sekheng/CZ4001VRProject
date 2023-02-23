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
        ScoreManager.instance.FinishEvent += DoneLoadingMainScene;
        ScoreManager.instance.PlayerDiedEvent+= PlayerDied;
    }

    void PlayerDied()
    {
        tweenAlpha = LeanTween.alpha(diedImage.transform as RectTransform, 1.0f, fadeTime);
        tweenAlpha.setOnComplete(() =>
        {
            ObserverSystem.Instance.TriggerEvent(FinishedTweening);
        });
    }

    private void OnDestroy()
    {
        ScoreManager.instance.FinishEvent -= DoneLoadingMainScene;
        ScoreManager.instance.PlayerDiedEvent -= PlayerDied;
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
