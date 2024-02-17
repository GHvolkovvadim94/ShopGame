using System;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public UnityEvent<Customer> OnNewCustomerCome = new UnityEvent<Customer>();
    GameObject shopGameObject;
    private Shop shop;
    private InputManager inputManager;


    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            // ���� ��������� ��� �� ��� ������, ������� ���
            if (instance == null)
            {
                // ������� ����� ������ GameManager � ��������� � ���� ���������
                GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                instance = singletonObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    // ����� ��� �������������
    public void Init()
    {

        Debug.Log("GameManager ���������������!");
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
            // �������� ������ HandleSpaceKeyPress � InputManager
            inputManager.SetSpaceAction(CreateNewCustomer);
            Debug.Log("SpaceAction ��������");
        }
        Debug.Log("���� ������!");
    }



    private void Awake()
    {
        // ��������� ������������ ���������� � ������������ ��� ��������������
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
        // ���������� ����

    }

    private void CreateNewCustomer()
    {
        Customer newCustomer = new Customer(CreateNewOrder(), "����");
        OnNewCustomerCome.Invoke(newCustomer);
        Debug.Log($"���������� {newCustomer.Name} ������. �� ����� ������ {newCustomer.Order.DesiredItem.ItemName} � �������� �� ���� {newCustomer.Order.DesiredItem.Price} �����");
    }

    private Order CreateNewOrder()
    {
        return new Order(new Item("���", 30), 360f);
    }
}

