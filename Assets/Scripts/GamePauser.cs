using UnityEngine;
using UnityEngine.EventSystems;

public class GamePauser : MonoBehaviour
{
    [SerializeField] GameObject crossHair;

    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            crossHair.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            GameManager.Instance.Pause = false;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            crossHair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.Pause = true;
        }
    }
}
