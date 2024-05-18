using UnityEngine;
using UnityEngine.UI;

public class DancingAnimationView : MonoBehaviour
{
    [SerializeField] Toggle houseDancingToggle;
    [SerializeField] Toggle macarenaDanceToggle;
    [SerializeField] Toggle waveHipHopDanceToggle;
    [SerializeField] Button startSelectedAnimationButton;

    void Start()
    {
        SetAnimationButtonsActions();
        SetDefaultAnimation();
    }

    void SetDefaultAnimation()
    { 
        waveHipHopDanceToggle.Select();
        waveHipHopDanceToggle.onValueChanged.Invoke(true);
    }

    void SetAnimationButtonsActions()
    {
        houseDancingToggle.onValueChanged.AddListener(PlayerAnimations.Instance.SetActiveHouseDancing);
        waveHipHopDanceToggle.onValueChanged.AddListener(PlayerAnimations.Instance.SetActiveWaveHipHopDance);
        macarenaDanceToggle.onValueChanged.AddListener(PlayerAnimations.Instance.SetActiveMacarenaDance);
        startSelectedAnimationButton.onClick.AddListener(StartSelectedAnimation);
    }

    public void StartSelectedAnimation()
    {
        GameManager.Instance.LoadShootingScene();
    }
}
