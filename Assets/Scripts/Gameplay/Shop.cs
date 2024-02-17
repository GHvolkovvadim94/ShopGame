using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<Order> acceptedOrders;
    private List<Customer> customers;
    private List<Item> counter;



    public Shop()
    {
        acceptedOrders = new List<Order>();
        customers = new List<Customer>();
    }

    private void Start()
    {
        GameManager.Instance.OnNewCustomerCome.AddListener(WelcomeNewCostomer);
    }


    public void AcceptOrder(Customer customer)
    {
        acceptedOrders.Add(customer.Order);
        customers.Remove(customer);
    }

    public void RejectOrder(Customer customer)
    {
        customers.Remove(customer);
    }

    public void WelcomeNewCostomer(Customer customer)
    {
        customers.Add(customer);
        Debug.Log($"Добро пожаловать{customer.Name}");
    }
}
