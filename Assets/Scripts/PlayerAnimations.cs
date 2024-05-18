using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;

    readonly string houseDancing = "houseDancing";
    readonly string waveHipHopDance = "waveHipHopDance";
    readonly string macarenaDance = "macarenaDance";
    readonly string stopAnimations = "stopAnimations";
    readonly string playerPrefCurrentAnimation = "PlayerCurrentAnimation";

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

        LoadCurrentAnimation();
    }

    void LoadCurrentAnimation()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString(playerPrefCurrentAnimation)))
        {
            return;
        }

        SetAnimationByAnimatorParameter(PlayerPrefs.GetString(playerPrefCurrentAnimation));
    }

    public void StopAllAnimations()
    {
        animator.SetBool(houseDancing, false);
        animator.SetBool(waveHipHopDance, false);
        animator.SetBool(macarenaDance, false);
        animator.SetBool(stopAnimations, true);
    }

    void SetAnimationByAnimatorParameter(string animationParameter)
    {
        StartAnimation();
        SaveCurrentAnimation(animationParameter);
        animator.SetBool(animationParameter, true);
    }

    public void SetActiveHouseDancing(bool activeAnimation)
    {
        StartAnimation();
        SaveCurrentAnimation(houseDancing);
        animator.SetBool(houseDancing, activeAnimation);
    }

    public void SetActiveWaveHipHopDance(bool activeAnimation)
    {
        StartAnimation();
        SaveCurrentAnimation(waveHipHopDance);
        animator.SetBool(waveHipHopDance, activeAnimation);
    }

    public void SetActiveMacarenaDance(bool activeAnimation)
    {
        StartAnimation();
        SaveCurrentAnimation(macarenaDance);
        animator.SetBool(macarenaDance, activeAnimation);
    }

    void StartAnimation()
    {
        animator.SetBool(stopAnimations, false);
    }

    void SaveCurrentAnimation(string animationParameter)
    {
        PlayerPrefs.SetString(playerPrefCurrentAnimation, animationParameter);
    }
}
