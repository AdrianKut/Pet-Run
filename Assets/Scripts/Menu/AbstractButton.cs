using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour
{
    private Button _button;
    private void OnEnable()
    {
        _button.onClick.AddListener(Method);
    }

    private void Awake()
    {
        _button = this.gameObject.GetComponent<Button>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Method);
    }

    public virtual void Method() { }
}
