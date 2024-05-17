using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    readonly string houseDancing = "houseDancing";
    readonly string waveHipHopDance = "waveHipHopDance";
    readonly string macarenaDance = "macarenaDance";
    readonly string stopAnimations = "stopAnimations";

    public static PlayerAnimations Instance { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        animator = GetComponent<Animator>();    
    }

    public void SetActiveHouseDancing(bool activeAnimation)
    {
        StartAnimation();
        animator.SetBool(houseDancing, activeAnimation);
    }

    public void SetActiveWaveHipHopDance(bool activeAnimation)
    {
        StartAnimation();
        animator.SetBool(waveHipHopDance, activeAnimation);
    }

    public void SetActiveMacarenaDance(bool activeAnimation)
    {
        StartAnimation();
        animator.SetBool(macarenaDance, activeAnimation);
    }

    public void StopDancing()
    {
        animator.SetBool(stopAnimations, true);
    }

    void StartAnimation()
    {
        animator.SetBool(stopAnimations, false);
    }
}
