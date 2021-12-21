using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTree : MonoBehaviour
{
    [Header("Tree Visual Settings")]
    public Color originalColour;
    public Color fadedColour;

    //Private Variable
    private SpriteRenderer player;

    private void Start() => player = GameObject.Find("Player").GetComponent<SpriteRenderer>();

    private void Update() => FadeEffect();

    private void FadeEffect()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().bounds.Intersects(player.bounds))
            this.GetComponent<SpriteRenderer>().color = fadedColour;
        else
            this.GetComponent <SpriteRenderer>().color = originalColour;
    }
}
