using DG.Tweening;
using UnityEngine;

public enum ItemType
{
    Death,
    NewPlayer,
    Winning
}

public class PopupMessageItemManager : MonoBehaviour, IItemManager
{
    [SerializeField] private GameObject _gameObjectItemDeath;
    [SerializeField] private GameObject _gameObjectItemNewPlayer;
    [SerializeField] private GameObject _gameObjectItemWinning;

    public void InstantiateItem(string message, ItemType itemType)
    {
        GameObject gameObject = null;

        switch (itemType)
        {
            case ItemType.Death:
                gameObject = Instantiate(_gameObjectItemDeath);
                break;
            case ItemType.NewPlayer:
                gameObject = Instantiate(_gameObjectItemNewPlayer);
                break;
            case ItemType.Winning:
                gameObject = Instantiate(_gameObjectItemWinning);
                break;
        }

        gameObject.transform.SetParent(this.gameObject.transform);
        gameObject.GetComponent<Item>().SetText($"{message}");
        gameObject.transform.DOScale(1f, 0.25f);

        Destroy(gameObject.gameObject, 3f);
    }
}
