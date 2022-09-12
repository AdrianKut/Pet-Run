using TMPro;
using UnityEngine;

public class PlayerListManager : MonoBehaviour, IItemManager
{
    [SerializeField] private GameObject _gameObjectPlayerListItem;
    [SerializeField] private GameObject _playerListParent;

    public void InstantiateItem(string message)
    {
            var item = Instantiate(_gameObjectPlayerListItem);
            item.transform.SetParent(_playerListParent.transform);
            item.name = message;
            item.GetComponent<TextMeshProUGUI>().SetText(message);       
    }

    public void ChangeColorHighscoreItem(string nameOfGameObject, Color color)
    {
        for (int i = 0; i < _playerListParent.transform.childCount; i++)
        {
            var player = _playerListParent.transform.GetChild(i);
            if (player.name.Contains(nameOfGameObject))
            {
                player.GetComponent<TextMeshProUGUI>().color = color;
                break;
            }
        }
    }
}
