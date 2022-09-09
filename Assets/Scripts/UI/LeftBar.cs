using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeftBar : MonoBehaviour
{
    [Header("LeftBar")]
    [SerializeField] private GameObject _gameObjectLeftBar;
    [SerializeField] private Vector2 _startLeftBarPositionValue = new Vector2(-400, 0);
    [SerializeField] private Vector2 _endLeftBarPositionValue = new Vector2(0, 0);
    [SerializeField] private float _durationShowAndHideBar;
    [SerializeField] private Ease _ease;
    private bool isActivateLeftBar = true;
    
    [Space]
    [SerializeField] private GameObject _gameObjectControlPanel;
    [SerializeField] private GameObject _gameObjectPlayerListPanel;

    [Space]
    [SerializeField] private GameObject _gameObjectAskToQuit;

    [Header("Buttons")]
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonJoin;

    void Update()
    {
        ShowOrHideLeftBar();
    }

    private void ShowOrHideLeftBar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var rectTransform = _gameObjectLeftBar.GetComponent<RectTransform>();

            if(isActivateLeftBar == false)
            {
                _gameObjectLeftBar.SetActive(true);

                DOTween.To(() => rectTransform.offsetMin, x => rectTransform.offsetMin = x,
                    _endLeftBarPositionValue, _durationShowAndHideBar);
                
                isActivateLeftBar = true;
            }
            else 
            {
                DOTween.Sequence().Join(DOTween.To(() => rectTransform.offsetMin, x => rectTransform.offsetMin = x,
                    _startLeftBarPositionValue, _durationShowAndHideBar).OnComplete(() => _gameObjectLeftBar.SetActive(false)));
                
                isActivateLeftBar = false;
            }
        }
    }

    public void ShowControlsPanel()
    {
        _gameObjectControlPanel.SetActive(true);
    }

    public void ShowPlayerListPanel()
    {
        _gameObjectPlayerListPanel.SetActive(true);
    }

    public void HidePanels()
    {
        //_gameObjectPlayerListPanel?.SetActive(false);
        //_gameObjectControlPanel?.SetActive(false);

        _gameObjectPlayerListPanel?.SetActive(!_gameObjectPlayerListPanel.activeSelf);
        _gameObjectControlPanel?.SetActive(!_gameObjectControlPanel.activeSelf);
    }

    public void StartGameOnClick()
    {
        _buttonStart.interactable = false;
        _buttonJoin.interactable = false;
        StartCoroutine(GameManager.Instance.StartGame());
    }

    public void JoinOnClick()
    {
        _buttonJoin.interactable = false;
        var chatPlayerMessage = new ChatPlayerMessage(PlayerPrefs.GetString("username"), "!j");
        GameManager.Instance.PlayersManager.JoinPlayerToTheGame(chatPlayerMessage);
    }

    public void QuitOnClick()
    {
        _gameObjectAskToQuit.SetActive(true);
    }
}
