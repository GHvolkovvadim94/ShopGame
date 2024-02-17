using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        // ������� � �������������� ��������� GameManager
        GameManager.Instance.Init();
        // �������� ����� ��� ������ ����, ���� ����������

        // ������� � �������������� ��������� InputManager
        InputManager.Instance.Init();

        // ������� � �������������� ��������� TimerManager
        TimerManager.Instance.Init();
    }
}
