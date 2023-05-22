using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoJump : MonoBehaviour
{
    public float jumpForce = 10f; // S�la skoku
    public LayerMask groundLayer; // Vrstva povrchu
    public Transform groundCheck; // Bod pro detekci povrchu
    public float groundCheckRadius = 0.01f; // Polom�r kruhu pro detekci povrchu
    public bool isGrounded; // Indik�tor, zda je hr�� na zemi
    public GameObject platform;

    private Rigidbody2D rb; // Komponenta Rigidbody2D
    private bool shouldJump; // Indik�tor, zda by m�l hr�� sko�it

    private bool isFalling; // Indikátor, zda hráč padá

    public string gameOverSceneName = "GameOverScene"; // Název scény, která se má načíst po pádu hráče

    public float moveSpeed = 5f; // Rychlost pohybu postavy
    public float tiltMultiplier = 2f; // Násobitel pro zvýšení náklonu zařízení

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float tilt = Input.acceleration.x * tiltMultiplier; // Získání hodnoty náklonu zařízení v ose X a aplikace násobitel

        // Pohyb postavy na základě naklánění zařízení
        Vector3 movement = new Vector3(tilt, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Detekce pádu
        if (transform.position.y < -3.5f) // Přizpůsob hodnotu -10f dle svých potřeb
        {
            isFalling = true;
            // Sem přidej kód pro zpracování pádu, například prohrání zvuku, ukončení hry, atd.

            // Přepnutí na jinou scénu
            SceneManager.LoadScene(gameOverSceneName);
        }
      
    }

    void FixedUpdate()
    {   // Detekce povrchu
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        isGrounded = hit.collider != null;
      

        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isFalling = false; // Resetuje se indikátor pádu, pokud hráč dosáhne povrchu
            
        }
        // Skok, pokud by m�l hr�� sko�it
   

    }
}
