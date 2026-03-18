using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimatior;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimatior = GetComponent<Animator>();
        myAnimatior.SetBool("move", false);

    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Door")
            Destroy(collision.gameObject);
        SceneManager.LoadScene("Scene_door1" + collision.name);
        Debug.Log("충돌 확인");
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void Update()
    {
        if(moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }

        if(moveInput.magnitude  > 0)
        {
            myAnimatior.SetBool("move", true);
        }
        else
        {
            myAnimatior.SetBool("move", false);
        }
        transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);
    }
}
