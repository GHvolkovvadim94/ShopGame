using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void ProcessInput()
    {
        // ��������� ����� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��������� �������� ��� ������� ������� ������
            Debug.Log("Process input called");

        }
        // ������ �������� �� ������� ������, ����� ���� � �. �.
    }
    private void Update()
    {
        ProcessInput();
    }
}

