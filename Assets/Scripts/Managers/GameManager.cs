using System;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public UnityEvent<Order> OnNewOrderCreated = new UnityEvent<Order>();
    GameObject shopGameObject;
    private Shop shop;
    private InputManager inputManager;


    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            // Если экземпляр еще не был создан, создаем его
            if (instance == null)
            {
                // Создаем новый объект GameManager и добавляем к нему компонент
                GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                instance = singletonObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    // Метод для инициализации
    public void Init()
    {

        Debug.Log("GameManager инициализирован!");
    }

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        shopGameObject = new GameObject("Shop");
        shopGameObject.AddComponent<Shop>();
        shop = shopGameObject.GetComponent<Shop>();

        inputManager = FindObjectOfType<InputManager>();

        if (inputManager != null)
        {
            // Передача метода HandleSpaceKeyPress в InputManager
            inputManager.SetSpaceAction(CreateNewOrder);
            Debug.Log("SpaceAction назначен");
        }
        Debug.Log("Игра начата!");
    }



    private void Awake()
    {
        // Проверяем дублирование экземпляра и обеспечиваем его единственность
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


    public void Update()
    {
        // Обновление игры

    }


    private void CreateNewOrder()
    {
        OnNewOrderCreated.Invoke(new Order(new Item("Меч", 30), 360f));
    }
}

