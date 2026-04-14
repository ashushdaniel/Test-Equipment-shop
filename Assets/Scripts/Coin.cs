using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerGold>().AddGold(100);
        AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
        Destroy(gameObject);
    }
}
