using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class FlashColors : MonoBehaviour
{
    [Header ("COMPONENTES")]
    public List<SpriteRenderer> spriteRenderers;
    public Color colors = Color.red;
    public float duration = .3f;

    private Tween _currentTween;

    public void OnValidate()

    {
        spriteRenderers = new List<SpriteRenderer>();

        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flash();
        }
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var sprite in spriteRenderers)
        {
            sprite.DOColor(colors, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
