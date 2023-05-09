using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    public float jumpForce = 10f; // Síla skoku
    public LayerMask groundLayer; // Vrstva povrchu
    public Transform groundCheck; // Bod pro detekci povrchu
    public float groundCheckRadius = 0.01f; // Polomìr kruhu pro detekci povrchu
    public bool isGrounded; // Indikátor, zda je hráè na zemi
    public GameObject platform;

    private Rigidbody2D rb; // Komponenta Rigidbody2D
    private bool shouldJump; // Indikátor, zda by mìl hráè skoèit

    public Joystick joy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(joy.Horizontal*Time.deltaTime * 3, 0, 0);
      
    }

    void FixedUpdate()
    {   // Detekce povrchu
         RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        isGrounded = hit.collider != null;
      

        if (isGrounded)
        {
          
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        // Skok, pokud by mìl hráè skoèit
   

    }
}
