using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void SpaceAction();
    private SpaceAction spaceAction;


    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(InputManager).Name);
                instance = singletonObject.AddComponent<InputManager>();
            }
            return instance;
        }
    }

    public void Init()
    {
        Debug.Log("InputManager инициализирован!");
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Пробел нажат");
            if (spaceAction != null) spaceAction();
        }
    }

    public void SetSpaceAction(SpaceAction action)
    {
        spaceAction = action;
    }


}

