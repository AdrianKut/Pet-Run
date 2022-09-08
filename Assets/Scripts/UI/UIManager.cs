using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectCanvas;

    [Space]
    public Timer Timer;
    public HighscoreManager HighscoreManager;
    public PopupMessageItemManager PopupMessageItemManager;
    public GameObject GameObjectPrefabTextOnScreen;

    private void Update()
    {
        HideOrShowCanvas();
    }

    private void HideOrShowCanvas()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _gameObjectCanvas.SetActive(!_gameObjectCanvas.activeSelf);
        }
    }


    public void DisplayTextOnScreen(string text)
    {
        var tempText = Instantiate(GameObjectPrefabTextOnScreen, GameObjectPrefabTextOnScreen.transform.position, Quaternion.identity)
            .transform.GetComponent<TextOnScreen>();

        tempText.SetText(text);
    }

}
