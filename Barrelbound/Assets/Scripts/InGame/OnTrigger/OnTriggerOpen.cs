using UnityEngine;

public class OnTriggerOpen : MonoBehaviour
{
    public Animator OpenAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (OpenAnimator == null || OpenAnimator.runtimeAnimatorController == null) return;
        if (OpenAnimator.GetBool("Open")) return;

        OpenAnimator.SetBool("Open", true);
        OpenAnimator.SetBool("Close", false);
        OpenAnimator.SetTrigger("TrOpen");
    }
}