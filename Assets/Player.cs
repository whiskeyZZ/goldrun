using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    public Rigidbody2D rb;
    public float jumpAmount;
    public Vector2 speed = new Vector2();
    bool grounded = false;
    private SpriteRenderer r;
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                r.flipX = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                r.flipX = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.LoadScene(0);
    }

}
