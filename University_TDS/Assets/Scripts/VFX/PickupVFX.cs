using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupVFX : MonoBehaviour
{
    [Header("VFX Type")]
    public VisualStyle visualStyle;

    [Header("Spin Settings")]
    public float spinSpeed;

    [Header("Bounce VFX")]
    public float originalScale;

    //Private varialbes
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    public void Update()
    {
        if (gameManager.gameState == GameState.InProgress)
        {
            switch (visualStyle)
            {
                case VisualStyle.Spin_VFX:
                    SubscribeSpinEffect();
                    break;

                case VisualStyle.Bounce_VFX:
                    SubscribeBounceEffect();
                    break;
            }
        }
    }

    private void SubscribeSpinEffect()
    {
        this.transform.Rotate(0f, 0f, -spinSpeed);
    }

    private void SubscribeBounceEffect()
    {
        float time = Time.time;
        this.transform.localScale = new Vector3(Mathf.PingPong(time, originalScale - 3) + 3, Mathf.PingPong(time, originalScale - 3) + 3, this.transform.localScale.z);
    }
}

public enum VisualStyle
{
    Spin_VFX,
    Bounce_VFX
}
