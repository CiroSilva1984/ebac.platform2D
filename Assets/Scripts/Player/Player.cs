using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 friction = new Vector2(-.1f, 0);

    [Header("MOVIMENTO PLAYER")]
    public float speed = 10f;
    public float speedRun = 5f;

    //private bool _isRunning = false;

    private float _currentSpeed;

    [Header("CONTROLE JUMP")]
    public float forceJump = 10f;

    [Header("ANIMATION SETUP")]
    public float scaleJumpY = 1.5f;
    public float scaleJumpX = .5f;
    public float duratioAnim = .3f;
    public float delayAnim = .2f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    void Start()
    {
        
    }

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
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
            _currentSpeed = speedRun;
            animator.speed = 2;

        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }
        
        //Andar para frente com a tecla D
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);

            if(rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }

        //Andar para trás com a tecla A
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

            if(rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        //Friction sides
        if(rb.velocity.x > 0)
        {
            rb.velocity += friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity -= friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
            rb.transform.localScale = Vector2.one;

            //animator.SetBool(boolJump, true);

            DOTween.Kill(rb.transform);

            HandleScaleJump();
        }
    }
    private void HandleScaleJump()
    {
        rb.transform.DOScaleY(scaleJumpY, duratioAnim).SetEase(ease).SetDelay(delayAnim).SetLoops(2, LoopType.Yoyo);
        rb.transform.DOScaleX(scaleJumpX, duratioAnim).SetEase(ease).SetDelay(delayAnim).SetLoops(2, LoopType.Yoyo);
    }
}
