using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    private InputSystem_Actions controls;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player1.Restart.performed += OnRestartPerformed;
    }

    private void OnDisable()
    {
        controls.Player1.Restart.performed -= OnRestartPerformed;
        controls.Player1.Disable();
    }

    private void OnRestartPerformed(InputAction.CallbackContext context)
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
