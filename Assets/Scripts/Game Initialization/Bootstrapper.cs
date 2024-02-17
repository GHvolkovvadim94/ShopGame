using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        // Создаем гейм менеджер

            GameObject gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager>();
            DontDestroyOnLoad(gameManager); // Делаем GameManager неразрушаемым при загрузке новых сцен

        // Создаем инпут менеджер

            GameObject inputManager = new GameObject("InputManager");
            inputManager.AddComponent<InputManager>();
            DontDestroyOnLoad(inputManager); // Делаем InputManager неразрушаемым при загрузке новых сцен

    }
}
