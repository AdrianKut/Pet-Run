using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class AskToQuitManager : MonoBehaviour
{
    [SerializeField] private float _endScaleValue;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private Ease _easeIn;
    [SerializeField] private Ease _easeOut;

    private void OnEnable()
    {
        transform.DOScale(_endScaleValue, _scaleDuration).SetEase(_easeIn);
    }

    private void OnDisable()
    {
        transform.DOScale(0f,0f);
    }

    public void NoOnClick()
    {
        DOTween.Sequence().Join(transform.DOScale(0,_scaleDuration).SetEase(_easeOut).OnComplete(() => gameObject.SetActive(false)));
    }
}
