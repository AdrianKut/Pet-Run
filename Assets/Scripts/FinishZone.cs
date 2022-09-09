using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectFinishRaceVFX;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            GameManager.Instance.Winner(collider.gameObject);
            var gameObject = Instantiate(_gameObjectFinishRaceVFX, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }
}
