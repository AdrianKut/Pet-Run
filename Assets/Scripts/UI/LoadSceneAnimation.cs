using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAnimation : MonoBehaviour
{
    [SerializeField] private float _fadeStartFadeValue;
    [SerializeField] private float _fadeEndFadeValue;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private Ease _ease;
    
    [Space]
    [SerializeField] int _levelToLoad;

    private void OnEnable()
    {
        Fade(_fadeEndFadeValue, _fadeDuration, _ease);
    }

    private DG.Tweening.Core.TweenerCore<Color, Color, DG.Tweening.Plugins.Options.ColorOptions> Fade(float endValue, float duration, Ease ease)
    {
        return this.gameObject.GetComponent<RawImage>().DOFade(endValue, duration).SetEase(ease);
    }

    public void ChangeLevelOnClick()
    {
        Fade(_fadeStartFadeValue, _fadeDuration, _ease).OnComplete(() => SceneManager.LoadScene(_levelToLoad));
    }
}
