using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            GameManager.Instance.PlayersManager.DestroyPlayer(collision.gameObject, true);
        }
    }
}