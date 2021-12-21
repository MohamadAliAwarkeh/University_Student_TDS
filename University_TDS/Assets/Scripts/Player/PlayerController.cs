using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float moveSpeed;

    #region Unity Functions
    private void Update()
    {
        PlayerMovement();
    }
    #endregion

    #region Private Functions
    private void PlayerMovement()
    {
        //Move forward
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        }
        //Move backwards
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
        }
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
        //Mofe Right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void PlayerBounds()
    {
        if (this.transform.position.x < -17.3f)
            this.transform.position = new Vector3(-17.3f, this.transform.position.y, this.transform.position.z);

        if (this.transform.position.x > 17.3f)
            this.transform.position = new Vector3(17.3f, this.transform.position.y, this.transform.position.z);
    }
    #endregion
}
