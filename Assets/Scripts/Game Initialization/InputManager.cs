using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void ProcessInput()
    {
        // Обработка ввода игрока
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Выполнить действие при нажатии клавиши Пробел
            Debug.Log("Process input called");

        }
        // Другие проверки на нажатия клавиш, клики мыши и т. д.
    }
    private void Update()
    {
        ProcessInput();
    }
}

