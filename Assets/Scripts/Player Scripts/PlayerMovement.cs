using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody Player_Body;

    void Start()
    {
        Player_Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }


    public float normal_speed = 5f;
    public float slow_speed = 3f;
    private float speed;
    private void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = slow_speed;
        }
        else
        {
            speed = normal_speed;
        }
        Player_Body.transform.localScale = new Vector3(Player_Body.transform.localScale.x * 1, Player_Body.transform.localScale.y * 1, Player_Body.transform.localScale.z * 1);
        Player_Body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Player_Body.velocity.y, Input.GetAxis("Vertical") * speed);
    }


    private bool onGround;
    private float groundConnection = 0.8f;
    public LayerMask layerOnGround;
    public float Jump_Power = 600f;
    private void Jump()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, groundConnection, layerOnGround.value);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            Player_Body.AddForce(new Vector3(0, Jump_Power, 0));
    }
}
