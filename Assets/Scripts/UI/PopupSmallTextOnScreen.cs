using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopupSmallTextOnScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Vector3 _endScaleValue;
    [SerializeField] private float _scaleDuration;

    void OnEnable()
    {
        _textMesh.gameObject.transform.DOScale(_endScaleValue, _scaleDuration);
        Destroy(this.gameObject, 1f);
    }

    public void SetText(string text)
    {
        _textMesh.text = text;
    }
}
