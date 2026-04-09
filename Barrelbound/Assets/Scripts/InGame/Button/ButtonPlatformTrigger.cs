using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonPlatformTrigger : MonoBehaviour, IInteractable
{
    public enum ButtonAction { Rise, Fall, Toggle }

    public Animator animator;
    public bool startRisen = false;
    public ButtonAction action = ButtonAction.Toggle;
    public bool useOnce = false;
    public bool cycleRiseFall = false;
    public float waitTime = 2f;
    public List<Animator> firstBatch = new List<Animator>();
    public List<Animator> secondBatch = new List<Animator>();

    private bool used = false;
    private Coroutine _cycleCoroutine;

    private void Start()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
            SetState(startRisen);

        InitializeBatches();
    }

    private void InitializeBatches()
    {
        foreach (var anim in firstBatch)
            if (anim != null)
            {
                anim.SetBool("Risen", false);
                anim.SetBool("Fallen", true);
            }

        foreach (var anim in secondBatch)
            if (anim != null)
            {
                anim.SetBool("Risen", false);
                anim.SetBool("Fallen", true);
            }
    }

    public void Interact(PlayerController player)
    {
        if (used && useOnce) return;

        if (animator != null && animator.runtimeAnimatorController != null)
        {
            bool isRisen = animator.GetBool("Risen");
            bool isFallen = animator.GetBool("Fallen");

            switch (action)
            {
                case ButtonAction.Rise:
                    if (!(isRisen && !isFallen)) Rise(animator);
                    break;
                case ButtonAction.Fall:
                    if (!(isFallen && !isRisen)) Fall(animator);
                    break;
                case ButtonAction.Toggle:
                    if (isRisen && !isFallen) Fall(animator);
                    else Rise(animator);
                    break;
            }
        }

        if (cycleRiseFall)
        {
            if (_cycleCoroutine != null) StopCoroutine(_cycleCoroutine);
            _cycleCoroutine = StartCoroutine(CycleRoutine());
        }

        used = true;
    }

    private IEnumerator CycleRoutine()
    {
        AnimateBatch(firstBatch, true);
        AnimateBatch(secondBatch, true);
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            AnimateBatch(firstBatch, false);
            yield return new WaitForSeconds(waitTime);
            AnimateBatch(firstBatch, true);
            yield return new WaitForSeconds(waitTime);

            AnimateBatch(secondBatch, false);
            yield return new WaitForSeconds(waitTime);
            AnimateBatch(secondBatch, true);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void AnimateBatch(List<Animator> batch, bool rise)
    {
        foreach (var anim in batch)
        {
            if (anim == null) continue;
            anim.SetBool("Risen", rise);
            anim.SetBool("Fallen", !rise);
            anim.SetTrigger(rise ? "TrRise" : "TrFall");
        }
    }

    private void Rise(Animator anim)
    {
        if (anim == null) return;
        anim.SetBool("Risen", true);
        anim.SetBool("Fallen", false);
        anim.SetTrigger("TrRise");
    }

    private void Fall(Animator anim)
    {
        if (anim == null) return;
        anim.SetBool("Risen", false);
        anim.SetBool("Fallen", true);
        anim.SetTrigger("TrFall");
    }

    private void SetState(bool risen)
    {
        if (animator == null) return;
        animator.SetBool("Risen", risen);
        animator.SetBool("Fallen", !risen);
    }

    public void StopCycle()
    {
        if (_cycleCoroutine != null)
            StopCoroutine(_cycleCoroutine);
        _cycleCoroutine = null;
    }
}