using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float moveSpeed;

    [Header("References")]
    public TankBodyRotation tankBody;
    public TankTurretRotation tankTurret;

    //Private variables
    private GameManager gameManager;

    private void Start()
    {
        //Get reference
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //Call based on game state
        if (gameManager.gameState == GameState.InProgress)
        {
            //Call functions
            PlayerMovement();
            SetBounds();
            //Call functions from references
            tankBody.RotateBody();
            tankTurret.RotateTurret();
        }
    }

    private void PlayerMovement()
    {
        //Move forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        }
        //Move backwards
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        }
        //Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
        //Mofe Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void SetBounds()
    {
        if (this.transform.position.x < -17.3f)
            this.transform.position = new Vector3(-17.3f, this.transform.position.y, this.transform.position.z);

        if (this.transform.position.x > 17.3f)
            this.transform.position = new Vector3(17.3f, this.transform.position.y, this.transform.position.z);

        if (this.transform.position.y < -9.55f)
            this.transform.position = new Vector3(this.transform.position.x, -9.55f, this.transform.position.z);

        if (this.transform.position.y > 9.55f)
            this.transform.position = new Vector3(this.transform.position.x, 9.55f, this.transform.position.z);
    }
}
