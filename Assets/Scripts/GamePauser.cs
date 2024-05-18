using UnityEngine;
using UnityEngine.EventSystems;

public class GamePauser : MonoBehaviour
{
    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameManager.Instance.Pause = false;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.Pause = true;
        }
    }
}
