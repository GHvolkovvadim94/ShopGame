using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<Order> acceptedOrders;
    private List<Order> pendingOrders;
    private List<Item> counter;


    private int pendingOrdersCapacity = 5;
    private int acceptedOrdersCapacity = 5;



    public Shop()
    {
        acceptedOrders = new List<Order>();
        pendingOrders = new List<Order>();
    }

    private void Start()
    {
        GameManager.Instance.OnNewOrderCreated.AddListener(GetNewPendingOrder);
    }


    public void AcceptOrder(Order order)
    {
        if (acceptedOrders.Count < acceptedOrdersCapacity)
        {
            acceptedOrders.Add(order);
            pendingOrders.Remove(order);
        }
        else
        {
            throw new Exception($"Попытка выйти за ограничение acceptedOrdersCapacity ({acceptedOrdersCapacity})");
        }
    }

    public void RejectOrder(Order order)
    {
        pendingOrders.Remove(order);
    }

    public void GetNewPendingOrder(Order order)
    {
        if (pendingOrders.Count < pendingOrdersCapacity)
        {
            pendingOrders.Add(order);
            Debug.Log($"Новый заказ добавлен в список ожидания.\nВремя на выполнение заказа {order.TimeToComplete} секунд.");
        }
        else
        {
            throw new Exception($"Попытка выйти за ограничение pendingOrdersCapacity ({pendingOrdersCapacity})");
        }


    }
}
