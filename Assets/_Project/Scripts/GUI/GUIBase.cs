using System;
using UnityEngine;

public class GUIBase : MonoBehaviour
{
   
    private void Start()
    {
        Hide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }


}