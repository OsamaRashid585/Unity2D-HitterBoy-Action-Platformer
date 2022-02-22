using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
     private float _moveSpeed = 20;
    [SerializeField] private GameObject _mediumBubblePrefab;
    [SerializeField] private GameObject _SmallBubblePrefab;
    [SerializeField] private GameObject _explosionPrefab;
    private Vector3 _MediumBallSpawnPos = new Vector3(1f,0f,0f);
    private Vector3 _SmallBallSpawnPos = new Vector3(0.5f,0f,0f);
    private Vector3 _MediumExplosionPos = new Vector3(0f, 1f, 0f);
    private Vector3 _SmallExplosionPos = new Vector3(0f, 0.5f, 0f);

    private void Start()
    {
   
    }
    private void Update()
    {
        Movement();
        OffsetDestroy();

    }
    private void Movement()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
    }
    private void OffsetDestroy()
    {
        if (transform.position.y >= 12)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Explosion"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BigBubbleHitPoint"))
        {
            Instantiate(_mediumBubblePrefab, collision.transform.position + _MediumBallSpawnPos, Quaternion.identity);
            Instantiate(_mediumBubblePrefab, collision.transform.position - _MediumBallSpawnPos, Quaternion.identity);
            Instantiate(_explosionPrefab, collision.transform.position - _MediumExplosionPos, Quaternion.identity);
            var bigBubble = collision.transform.parent.gameObject;
            Destroy(bigBubble);
            Destroy(gameObject);
            GameManager.Instance.Score++;

        }
        if (collision.gameObject.CompareTag("MediumBubbleHitPoint"))
        {
            Instantiate(_SmallBubblePrefab, collision.transform.position - _SmallBallSpawnPos, Quaternion.identity);
            Instantiate(_SmallBubblePrefab, collision.transform.position + _SmallBallSpawnPos, Quaternion.identity);
            Instantiate(_explosionPrefab, collision.transform.position - _SmallExplosionPos, Quaternion.identity);
            var mediumBubble = collision.transform.parent.gameObject;
            Destroy(mediumBubble);
            Destroy(gameObject);
            GameManager.Instance.Score++;
            
        }
        if (collision.gameObject.CompareTag("SmallBubbleHitPoint"))
        {
            GameManager.Instance.Score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            var smallBubble = collision.transform.parent.gameObject;
            Destroy(smallBubble);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.Life++;
        }
        if (collision.gameObject.CompareTag("TimeStoper"))
        {
            Debug.Log("TimeStop"); // stoptime logic
            Destroy(collision.gameObject);
        }
    }
}
