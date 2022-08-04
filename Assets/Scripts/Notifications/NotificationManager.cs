using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Notifications
{
    WithImage
}

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    [SerializeField] Notification notificationWithText;

    Queue<NotificationData> notifications = new Queue<NotificationData>();

    Coroutine notificationsTask;
    RectTransform notificationsParent;


    void Awake()
    {
        Instance = this;
        notificationsParent = GetComponent<RectTransform>();
    }

    void AddNotification(NotificationData data)
    {
        notifications.Enqueue(data);
        if (notificationsTask == null) 
            notificationsTask = StartCoroutine(ShowNotifications());
    }

    public void CreateNotificationWithText(float time, string message)
    {
        NotificationData data = new NotificationData(notificationWithText, time, message);
        AddNotification(data);
    }

    IEnumerator ShowNotifications()
    {
        while(notifications.Count > 0)
        {
            NotificationData data = notifications.Dequeue();

            Notification notification = Instantiate(data.Prefab);
            RectTransform notificationTransform = notification.GetComponent<RectTransform>();
            notificationTransform.SetParent(notificationsParent, false);


            notification.SetData(data);
            notification.Show();
            
            yield return new WaitForSecondsRealtime(data.Time);
            Destroy(notification.gameObject);
        }
        notificationsTask = null;
    }
}
