using UnityEngine;
using DG.Tweening;


public class QuestionDialogueWindow : MonoBehaviour
{
    [SerializeField] private float _endScaleValue;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private Ease _easeInScale;
    [SerializeField] private Ease _easeOutScale;

    private void OnEnable()
    {
        transform.DOScale(_endScaleValue, _scaleDuration).SetEase(_easeInScale);
    }

    private void OnDisable()
    {
        transform.DOScale(0f,0f);
    }

    public void NoOnClick()
    {
        DOTween.Sequence().Join(transform.DOScale(0,_scaleDuration).SetEase(_easeOutScale).OnComplete(() => gameObject.SetActive(false)));
    }
}
