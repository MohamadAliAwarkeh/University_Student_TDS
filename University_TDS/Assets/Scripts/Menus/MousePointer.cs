using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [Header("Mouse Settings")]
    public Vector3 offsetPos;

    [Header("Sprites")]
    public Sprite menuCursor;
    public Sprite baseInGameCursor;
    public Sprite cursorOverEnemy;

    [Header("References")]
    public GameManager gameManager;
    public GameObject enemyParentObj;

    //Private Variables
    private SpriteRenderer mySR;

    private void Start()
    {
        //Set reference
        mySR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Simply sets the objects position to the mouse
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offsetPos;
    }

    private void HandleCursorSprites()
    {
        if (gameManager.gameState != GameState.InProgress)
            mySR.sprite = menuCursor;
        else
        {
            if (enemyParentObj.transform.childCount > 0 && )

        }
    }
}
