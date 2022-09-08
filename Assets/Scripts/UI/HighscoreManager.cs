using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour, IItemManager
{
    [SerializeField] private GameObject _gameObjectItem;
    [SerializeField] private List<GameObject> _listGameObjectItem = new List<GameObject>();

    public void InstantiateItem(string message)
    {
        if (_listGameObjectItem.Count < 10)
        {
            var item = Instantiate(_gameObjectItem);
            item.transform.SetParent(this.gameObject.transform);
            item.name = message;
            item.GetComponent<Item>().SetText($"{_listGameObjectItem.Count + 1}. {message}");
            
            _listGameObjectItem.Add(item);
        }
    }

    public void ChangeColorHighscoreItem(string nameOfGameObject, Color color)
    {
        foreach (var item in _listGameObjectItem)
        {
            if (item.name == nameOfGameObject)
            {
                item.GetComponent<Item>().SetColorText(color);
                break;
            }
        }
    }
}