using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _controls;

    private float _axis;

    private Rigidbody2D _rb;

    public float speed;
    public float jumpSpeed;

    private bool _jumping;

    public float cooldownTime;
    private float _cooldown;

    private bool _onGround;

    public CircleCollider2D groundCheck;

    public LayerMask ground;

    public GameObject PauseCanvas;
    private bool _paused = false;

    void Awake()
    {
        _controls = new PlayerControls();
    }

    void OnEnable()
    {
        _controls.Enable();
    }

    void OnDisable()
    {
        _controls.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _controls.Player.Pause.performed += _ => Pause();
    }

    void Update()
    {
        _axis = _controls.Player.Horizontalmovement.ReadValue<float>();

        _rb.velocity = new Vector2(_axis * speed, _rb.velocity.y);

        _jumping = _controls.Player.Jump.ReadValue<float>() > 0;

        _cooldown -= Time.deltaTime;

        if (groundCheck.IsTouchingLayers(ground))
        {
            if(_onGround == false)
            {
                GetComponentInChildren<ParticleSystem>().Play();
            }

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

    void Pause()
    {
        if (_paused)
        {
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            _paused = false;
        }
        else
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            _paused = true;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        _paused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        _paused = false;
        SceneManager.LoadScene("Menu");
    }
}
