using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Order
{
    public Item DesiredItem { get; private set; }
    private float timeToComplete;
    private Timer timer;


    public Order(Item item, float timeToComplete)
    {
        this.DesiredItem = item;
        this.timeToComplete = timeToComplete;
    }
    private void Start()
    {
        timer = TimerManager.Instance.GetTimer();
        timer.StartTimer(timeToComplete);
        timer.OnTimerComplete += RemoveOrder;
    }


    public void FulfillOrder(List<Item> counter)
    {
        // Убрать товар с прилавка
        counter.Remove(DesiredItem);

        // Уведомить игрока о выполненном заказе
        Debug.Log("Order fulfilled: " + DesiredItem.ItemName);
    }

    public void RemoveOrder()
    {

    }

}
