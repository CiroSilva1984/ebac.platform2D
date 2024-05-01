using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class SOPlayerSetup : ScriptableObject
{
    public Animator playerAnimator;
    public SOString soStringName;

    [Header("MOVIMENTO PLAYER")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed = 10f;
    public float speedRun = 5f;
    public float forceJump = 10f;

    [Header("ANIMATION SETUP")]
    public float scaleJumpY = 1.5f;
    public float scaleJumpX = .5f;
    public float durationAnimation = .3f;
    public float delayAnim = .2f;
    public Ease ease = Ease.OutBack;

    [Header("ANIMATION PLAYER")]
    //public Animator animator;
    public string boolRun = "Run";
    public float playerSwipeDuration = .1f;
    public string triggerDeath = "Death";
}
