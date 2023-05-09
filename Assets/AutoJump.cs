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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detekce povrchu pomocí raycastu
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, groundLayer);
        isGrounded = hit.collider != null;
    }

    void FixedUpdate()
    {   // Detekce povrchu
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Nastavení indikátoru pro skok, pokud je hráè na zemi
        if (isGrounded)
        {
            shouldJump = true;
        }
        // Skok, pokud by mìl hráè skoèit
        if (shouldJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
}
