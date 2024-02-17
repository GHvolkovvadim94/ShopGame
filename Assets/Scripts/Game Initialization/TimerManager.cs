using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;

    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(TimerManager).Name);
                instance = singletonObject.AddComponent<TimerManager>();
            }
            return instance;
        }
    }

    public void Init()
    {
        Debug.Log("TimerManager инициализирован!");
    }

    // Добавьте здесь любую другую логику TimerManager

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

    private List<Timer> timers = new List<Timer>();

    public Timer GetTimer()
    {
        Timer newTimer = new Timer();
        timers.Add(newTimer);
        return newTimer;
    }

    public void RemoveTimer(Timer timer)
    {
        timers.Remove(timer);
    }
}

public class Timer
{
    private float duration;
    private float currentTime;
    private bool isRunning;

    public event Action OnTimerStart;
    public event Action OnTimerUpdate;
    public event Action OnTimerComplete;

    public Timer()
    {
        duration = 0f;
        currentTime = 0f;
        isRunning = false;
    }

    public void StartTimer(float duration)
    {
        this.duration = duration;
        currentTime = 0f;
        isRunning = true;
        OnTimerStart?.Invoke();
    }

    public void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            OnTimerUpdate?.Invoke();

            if (currentTime >= duration)
            {
                StopTimer();
                OnTimerComplete?.Invoke();
            }
        }
    }

    public void StopTimer() => isRunning = false;
    public bool IsRunning() => isRunning;
}
