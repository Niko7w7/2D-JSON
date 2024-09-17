using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [Header("Velocidad y salto")]
    public float velMovement = 5f;
    public float fuerzaJump = 7f;

    [Header("Rigidbody y animator")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movimiento player")]
    public float movimientoH;

    [Header("Posicion player")]
    public Transform playerTransform;

    public bool enPiso = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.Log("No se encontro RigidBody2d en " + gameObject.name);
        }
        if(animator == null)
        {
            Debug.Log("no se encontro animator en " + gameObject.name);
        }
    }

    void Update()
    {
        movimientoH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));

        //flip
        if (movimientoH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  //Derecha
        }
        else if (movimientoH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Izquierda
        }

        //Salto
                
        if (Input.GetButton("Jump") && enPiso)
        {
            animator.SetBool("Jump", true);
            //Debug.Log("Se ejecuta");
            rb.AddForce(new Vector2(0, fuerzaJump), ForceMode2D.Impulse);
            enPiso = false;
        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            enPiso = true;
            animator.SetBool("Jump", false); 
            Debug.Log("Estas en el piso");
        }
    }
    //Salto

    //Daño Enemigo 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Este eh Sech");
            //gameObject.SetActive(false);
            PlayerDeath();
        }
        Debug.Log("El pepe");
    }
    public void PlayerDeath()
    {
        RespawnCheckpoint();
    }

    public void RespawnCheckpoint()
    {
        if (CheckPoint.instance !=null)
        {
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");

            Vector3 respawnPosition = new Vector3(playerPosX, playerPosY, playerTransform.position.z);
            playerTransform.position = respawnPosition;
        }
    }

}
