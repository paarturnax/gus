using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;

	private void Awake()
	{
        _rb = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
        if (DialogManager.GetInstance()._dialogIsPlaying)
        {
            return;
        }

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = -_rb.gravityScale;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);
    }
}
