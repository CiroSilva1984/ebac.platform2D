using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public HealthBase healthBase;
    private FlashColors flashColors;
    private float _currentSpeed;

    private Animator _currentPlayer;
    //public Animator animator; //Faz parte do Header (ANIMATION PLAYER)

    /*[Header("MOVIMENTO PLAYER")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed = 10f;
    public float speedRun = 5f;

    //private bool _isRunning = false;


    [Header("CONTROLE JUMP")]
    public float forceJump = 10f;

    [Header("ANIMATION SETUP")]
    //public float scaleJumpY = 1.5f;
    public float scaleJumpX = .5f;
    //public float durationAnimation = .3f;
    public float delayAnim = .2f;
    public Ease ease = Ease.OutBack;
    public SOFloat SoScaleJumpY;
    //public SOFloat SoScaleJumpX;
    public SOFloat SoDurationAnimation;

    [Header("ANIMATION PLAYER")]
    public string boolRun = "Run";
    public float playerSwipeDuration = .1f;
    public string triggerDeath = "Death";*/

    [Header("SETUP")]
    public SOPlayerSetup soPlayerSetup;

    private void OnValidate()
    {
        if (_currentPlayer == null) _currentPlayer = GetComponent<Animator>();
    }

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
        _currentPlayer = Instantiate(soPlayerSetup.playerAnimator, transform);
        _currentPlayer.GetComponentInChildren<GunBase>().playerSideReference = transform;
        _currentPlayer.GetComponentInChildren<PlayerDestroyHelper>().player = this;
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {

        //_isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 2;

        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }
        
        //Andar para frente com a tecla D
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);

            if(rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
                _currentPlayer.SetBool(soPlayerSetup.boolRun, true);;
        }

        //Andar para trás com a tecla A
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

            if(rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration); ;
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        //Friction sides
        if(rb.velocity.x > 0)
        {
            rb.velocity += soPlayerSetup.friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity -= soPlayerSetup.friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * soPlayerSetup.forceJump;
            //rb.transform.localScale = Vector2.one;


            DOTween.Kill(rb.transform);

            HandleScaleJump();
        }
            if(rb.transform.position.y > .1f)
            {
                _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
            }
    }
    private void HandleScaleJump()
    {
        rb.transform.DOScaleY(soPlayerSetup.scaleJumpY, soPlayerSetup.durationAnimation).SetEase(soPlayerSetup.ease).SetDelay(soPlayerSetup.delayAnim).SetLoops(2, LoopType.Yoyo);
        //rb.transform.DOScaleX(scaleJumpX, durationAnimation).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}