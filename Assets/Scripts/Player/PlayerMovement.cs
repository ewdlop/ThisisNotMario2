using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    stand,
    jump,
    walk,
    grab,
    grabbed,
    death,
    freeze
};

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private SFX deathSound;
    [SerializeField]
    private float inputX;
    [SerializeField]
    private float facing;
    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    private bool invokedPlayerRespawned;
    public bool IsGrounded{
        get {
            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;

            var hit = Physics2D.Raycast(position, direction, GroundDistance, GroundLayer);
            if (hit.collider != null && Rb.velocity.y <= 0f) {
                return true;
            }
            return false;
        }
        private set => isGrounded = value;
    }
    public Rigidbody2D Rb { get => rb; private set => rb = value; }
    public Animator Animator { get => animator; private set => animator = value; }
    public float SpeedX { get => speedX; private set => speedX = value; }
    public LayerMask GroundLayer { get => groundLayer; private set => groundLayer = value; }
    public float GroundDistance { get => groundDistance; private set => groundDistance = value; }
    public SFX DeathSound { get => deathSound; private set => deathSound = value; }
    public float InputX {
        get => inputX;
        private set {
            inputX = value;
            if (Math.Abs(InputX) < Mathf.Epsilon) {
                Animator.SetInteger("walk", 0);
            } else {
                Facing = InputX / Mathf.Abs(InputX);
                Flip(Facing);
            }
        }
    }
    public float Facing { get => facing; private set => facing = value; }
    public PlayerState PlayerState {
        get => playerState;
        private set {
            playerState = value;
        }
    }
    public bool InvokedPlayerRespawned { get => invokedPlayerRespawned; private set => invokedPlayerRespawned = value; }
    public float SpeedY { get => speedY; private set => speedY = value; }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        PlayerState = PlayerState.jump;
        SubscribeGameEvent();
    }

    void Update()
    {
        if (!InvokedPlayerRespawned)
        {
            InvokedPlayerRespawned = true;
            GameEventBroker.PlayerRespawned(gameObject);
        }
        InputX = Input.GetAxis("Horizontal");
        
        switch (PlayerState)
        {
            case PlayerState.stand:
                if (Math.Abs(InputX) > Mathf.Epsilon) {
                    PlayerState = PlayerState.walk;
                    SetHorizontalMovemnet();
                } else {
                    Rb.velocity = new Vector2(0f, Rb.velocity.y);
                }
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Jump();
                }
                break;
            case PlayerState.walk:
                if (Math.Abs(InputX) > Mathf.Epsilon)
                    SetHorizontalMovemnet();
                else {
                    PlayerState = PlayerState.stand;
                    Animator.SetInteger("walk", 0);
                    Rb.velocity = new Vector2(0f, Rb.velocity.y);
                }
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Jump();
                }
                break;
            case PlayerState.jump:
                if (Math.Abs(InputX) > Mathf.Epsilon)
                    SetHorizontalMovemnet();
                if (IsGrounded) {
                    PlayerState = PlayerState.stand;
                    Animator.SetBool("isOnTheGorund", true);
                }
                break;
            case PlayerState.death:
                if (Input.GetKeyDown(KeyCode.Z))
                    Respawn();
                break;
            case PlayerState.freeze:
                break;
            default:
                break;
        }
    }
    void KillPlayerHandler()
    {
        Death();
    }

    void FreezePlayerHandler() {
        Freeze();
    }
    void SetHorizontalMovemnet()
    {
        Animator.SetInteger("walk", (int)(InputX / Mathf.Abs(InputX)));
        Rb.velocity = new Vector2(SpeedX * InputX, Rb.velocity.y);

    }
    void Jump()
    {
        Animator.SetBool("isOnTheGorund", false);
        PlayerState = PlayerState.jump;
        Rb.AddForce(new Vector2(0f, Rb.mass * SpeedY), ForceMode2D.Impulse);
    }
    void Flip(float facing)
    {
        transform.localScale = new
           Vector3(facing * Mathf.Abs(transform.localScale.x),
           transform.localScale.y,
           transform.localScale.z);
    }
    void Death()
    {
        if(PlayerState != PlayerState.death)
        {
            SoundController.Play(DeathSound);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
            Animator.SetBool("isDeath", true);
            Rb.velocity = new Vector2(0f, 0f);
            Rb.AddForce(new Vector2(0, Rb.mass * 40f), ForceMode2D.Impulse);
            foreach (CapsuleCollider2D capsuleCollider in GetComponents<CapsuleCollider2D>())
            {
                capsuleCollider.enabled = false;
            }
            UnsubscribeGameEvent();
            GameEventBroker.PlayerDeath();
            PlayerState = PlayerState.death;
        }
    }
    void Freeze()
    {
        PlayerState = PlayerState.freeze;
    }
    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SubscribeGameEvent()
    {
        GameEventBroker.OnKillPlayer += KillPlayerHandler;
        GameEventBroker.OnFreezePlayer += FreezePlayerHandler;
    }
    void UnsubscribeGameEvent() 
    {
        GameEventBroker.OnKillPlayer -= KillPlayerHandler;
        GameEventBroker.OnFreezePlayer -= FreezePlayerHandler;
    }
}

