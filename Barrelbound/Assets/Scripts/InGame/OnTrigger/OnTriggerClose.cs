using UnityEngine;

public class OnTriggerClose : MonoBehaviour
{
    public Animator CloseAnimator;

    void Start()
    {
        if (CloseAnimator == null || CloseAnimator.runtimeAnimatorController == null) return;

        bool isOpen = CloseAnimator.GetBool("Open");
        bool isClose = CloseAnimator.GetBool("Close");

        if (!isOpen && !isClose)
        {
            CloseAnimator.SetBool("Close", true);
            CloseAnimator.SetBool("Open", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (CloseAnimator == null || CloseAnimator.runtimeAnimatorController == null) return;
        if (CloseAnimator.GetBool("Close")) return;

        CloseAnimator.SetBool("Close", true);
        CloseAnimator.SetBool("Open", false);
        CloseAnimator.SetTrigger("TrClose");
    }
}