using System;
using UnityEngine;
using UnityEngine.UI;

public class DancingAnimationView : MonoBehaviour
{
    [SerializeField] Toggle stopDancingButton;
    [SerializeField] Toggle houseDancingButton;
    [SerializeField] Toggle macarenaDanceButton;
    [SerializeField] Toggle waveHipHopDanceButton;

    void Awake()
    {
        stopDancingButton.onValueChanged.AddListener((value) => StopDancing());
        houseDancingButton.onValueChanged.AddListener(StartHouseDance);
        waveHipHopDanceButton.onValueChanged.AddListener(StartWaveHipHopDance);
        macarenaDanceButton.onValueChanged.AddListener(StartHMacarenaDance);
    }

    public void StopDancing()
    {
        PlayerAnimations.Instance.StopDancing();
    }

    public void StartHouseDance(bool active)
    {
        PlayerAnimations.Instance.SetActiveHouseDancing(active);
    }

    public void StartWaveHipHopDance(bool active)
    {
        PlayerAnimations.Instance.SetActiveWaveHipHopDance(active);
    }

    public void StartHMacarenaDance(bool active)
    {
        PlayerAnimations.Instance.SetActiveMacarenaDance(active);
    }
}
