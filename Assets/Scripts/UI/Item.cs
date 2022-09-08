using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshItem;
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private Texture _textureImage;
    
    private void OnEnable()
    {
        if (_rawImage != null)
        {
            _rawImage.texture = _textureImage;
        }
    }

    public virtual void SetText(string message)
    {
        _textMeshItem.text = message;
    }

    public void SetColorText(Color color)
    {
        _textMeshItem.color = color;
    }
}
