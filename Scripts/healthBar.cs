using UnityEngine;
using System;

public class healthBar : MonoBehaviour
{
    public playerScript healthScript;
    public RectTransform background;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        int newWidth = (int)Math.Round(background.rect.width * healthScript.currentHealth / healthScript.health);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
