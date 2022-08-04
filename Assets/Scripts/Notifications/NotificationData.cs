using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationData
{
    public float Time { get; private set; }
    public string Message { get; private set; }
    public Notification Prefab { get; private set; }

    public NotificationData(Notification prefab,float time, string message)
    {
        Time = time;
        Message = message;
        Prefab = prefab;
    }
}
