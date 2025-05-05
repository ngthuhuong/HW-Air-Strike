using System;
using UnityEngine;

public class GUIBase : MonoBehaviour
{
    public GameObject uiElement;

    private void Start()
    {
        Hide();
    }

    public virtual void Show()
    {
        uiElement.SetActive(true);
    }

    public virtual void Hide()
    {
        uiElement.SetActive(false);
    }


}