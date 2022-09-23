using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectFinishRaceVFX;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            GameManager.Instance.PlayersManager.DestroyPlayer(collider.gameObject,false);
            var gameObject = Instantiate(_gameObjectFinishRaceVFX, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }


        //DEBUG
        if (collider.gameObject.GetComponent<Walk>())
        {
            var gameObject = Instantiate(_gameObjectFinishRaceVFX, this.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }

    }
}
