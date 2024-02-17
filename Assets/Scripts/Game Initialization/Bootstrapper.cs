using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        // Создаем и инициализируем экземпляр GameManager
        GameManager.Instance.Init();
        // Вызываем метод для начала игры, если необходимо

        // Создаем и инициализируем экземпляр InputManager
        InputManager.Instance.Init();

        // Создаем и инициализируем экземпляр TimerManager
        TimerManager.Instance.Init();
    }
}
