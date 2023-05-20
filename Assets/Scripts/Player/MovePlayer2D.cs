using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2D : MonoBehaviour
{
    //Data
    [SerializeField] private PlayerData2D playerData2D;

    private float axisHorizontal;
    private bool isOnGround = true;
    private float currentSpeed;
    private bool isRunning = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = playerData2D._walkSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * playerData2D._jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            Run();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
            StopRunning();
        }

        if (axisHorizontal < 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-1, 1, 1), 0.1f);
        }
        else if (axisHorizontal > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), 0.1f);
        }
    }

    private void FixedUpdate()
    {
        axisHorizontal = Input.GetAxis("Horizontal");

        rb.transform.Translate(Vector2.right * axisHorizontal * currentSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (isRunning)
                Run();
            else
                StopRunning();
        }
    }

    private void Run()
    {
        if (isOnGround)
        {
            currentSpeed = playerData2D._runSpeed;
        }
    }

    private void StopRunning()
    {
        if(isOnGround)
        {
            currentSpeed = playerData2D._walkSpeed;
        }
    }
}
