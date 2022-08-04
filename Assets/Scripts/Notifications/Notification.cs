using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField] TMP_Text messageText;

    Animator animator;
    NotificationData data;
    
    int hide = Animator.StringToHash("Hide");

    public virtual void SetData(NotificationData data)
    {
        this.data = data;
        messageText.text = data.Message;
    }

    public void Show()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ShowCoroutine());
    }

    IEnumerator ShowCoroutine()
    {
        yield return new WaitForSecondsRealtime(data.Time - 0.5f);
        animator.SetTrigger(hide);
    }
}
