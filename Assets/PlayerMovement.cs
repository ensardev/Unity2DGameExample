using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private SpriteRenderer _sprite;
    private Animator _animator;

    private float _dirX = 0f;
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpForce = 14f;


    // Start is called before the first frame update
    private void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement
        _dirX = Input.GetAxisRaw("Horizontal");
        _playerRB.velocity = new Vector2(_dirX * _moveSpeed, _playerRB.velocity.y);

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            _playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpForce);
        }

        //AnimationState
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (_dirX > 0f)
        {
            _animator.SetBool("IsRunning", true);
            _sprite.flipX = false;
        }
        else if (_dirX < 0f)
        {
            _animator.SetBool("IsRunning", true);
            _sprite.flipX = true;
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

}
