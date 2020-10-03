using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _controlls;

    private float _axis;

    private Rigidbody2D _rb;

    public float speed;
    public float jumpSpeed;

    private bool _jumping;

    public float cooldownTime;
    private float _cooldown;

    private bool _onGround;

    public Transform origin;
    public float radius;

    public LayerMask ground;

    void Awake()
    {
        _controlls = new PlayerControls();
    }

    void OnEnable()
    {
        _controlls.Enable();
    }

    void OnDisable()
    {
        _controlls.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _axis = _controlls.Player.Horizontalmovement.ReadValue<float>();

        _rb.velocity = new Vector2(_axis * speed, _rb.velocity.y);

        _jumping = _controlls.Player.Jump.ReadValue<float>() > 0;

        _cooldown -= Time.deltaTime;

        if (GetComponentInChildren<CircleCollider2D>().IsTouchingLayers(ground))
        {
            _onGround = true;
        }
        else
        {
            _onGround = false;
        }

        if (_jumping)
        {
            if (_onGround)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
                _cooldown = cooldownTime;
            }
            else if(_cooldown >= 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            }
        }
    }
}
