using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        // ������� ���� ��������

            GameObject gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager>();
            DontDestroyOnLoad(gameManager); // ������ GameManager ������������� ��� �������� ����� ����

        // ������� ����� ��������

            GameObject inputManager = new GameObject("InputManager");
            inputManager.AddComponent<InputManager>();
            DontDestroyOnLoad(inputManager); // ������ InputManager ������������� ��� �������� ����� ����

    }
}
