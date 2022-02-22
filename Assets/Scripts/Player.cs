using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _knifePrefab;
    private float _moveSpeed = 1500;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _inpX;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _inpX = Input.GetAxis("Horizontal");
        RunAnimation();
        Invoke("SpawnKnife", 0);
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if(GameManager.Instance.IsgameOver != true)
        {
            _rb.velocity = new Vector2(_moveSpeed * _inpX * Time.deltaTime, _rb.velocity.y);
        }
    }
    private void RunAnimation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && GameManager.Instance.IsgameOver != true)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsRun", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && GameManager.Instance.IsgameOver != true)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
            
        }
    }

    private void SpawnKnife()
    {
        if (Input.GetKeyDown(KeyCode.Space) & GameManager.Instance.IsgameOver != true)
        {
            var pos = new Vector3(transform.position.x, -4f, 0);
            Instantiate(_knifePrefab, pos, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BigBubble")|| collision.gameObject.CompareTag("MediumBubble")|| collision.gameObject.CompareTag("SmallBubble"))
        {
            GameManager.Instance.Life--;
        }
    }
    private void GameoverEffect()
    {
        /* is game over then Particals */ 
    }
}
