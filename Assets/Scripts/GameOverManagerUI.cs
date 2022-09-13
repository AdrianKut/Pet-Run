using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManagerUI : MonoBehaviour
{
    [Header("Winner UI")]
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textSubtitle;
    [SerializeField] private GameObject _gameObjectWinnerUI;

    [Header("Highscores UI")]
    [SerializeField] private GameObject _gameObjectHighscoreUI;

    private void OnEnable()
    {
        _textSubtitle.text = GameManager.Instance.PlayersManager.GetWinnerName();
        
        if (_textSubtitle.text == "")
            _textTitle.text = "NO WINNER!";
    }

    public void CloseWindowOnClick()
    {
        _gameObjectWinnerUI.SetActive(false);   
        _gameObjectHighscoreUI.SetActive(true);
    }
}
