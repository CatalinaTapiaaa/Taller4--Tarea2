using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Player player;
    public Transform pivotInicio;
    public ParticleSystem efectoImpacto;
    [Header("Stats")]
    public float velocidadAtaque;
    public bool stop;

    Rigidbody2D rb2D;
    CircleCollider2D circle2D;
    Vector3 touchPosition, whereToMove;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    bool isMoving = false;
    bool atacar, noAtacar;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        circle2D = GetComponent<CircleCollider2D>();
        efectoImpacto.Stop();
    }

    void Update()
    {
        if (!stop)
        {
            if (atacar)
            {
                player.ani.SetBool("Abrir", true);
                player.lenguaFinal.enabled = true;
                player.lenguaInicio.enabled = true;

                circle2D.enabled = true;
                noAtacar = true;
            }
            if (!atacar)
            {
                transform.position = Vector2.MoveTowards(transform.position, pivotInicio.position, velocidadAtaque * Time.deltaTime);
            }
            if (noAtacar)
            {
                if (transform.position == pivotInicio.position)
                {
                    player.ani.SetBool("Abrir", false);
                    player.lenguaFinal.enabled = false;
                    player.lenguaInicio.enabled = false;
                    circle2D.enabled = false;
                    noAtacar = false;
                }
            }

            if (isMoving)
            {
                currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (!noAtacar)
                    {
                        previousDistanceToTouchPos = 0;
                        currentDistanceToTouchPos = 0;
                        isMoving = true;
                        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        touchPosition.z = 0;
                        whereToMove = (touchPosition - transform.position).normalized;
                        atacar = true;
                    }
                    rb2D.velocity = new Vector2(whereToMove.x * velocidadAtaque, whereToMove.y * velocidadAtaque);
                }
            }
            if (currentDistanceToTouchPos > previousDistanceToTouchPos)
            {
                isMoving = false;
                atacar = false;
                rb2D.velocity = Vector2.zero;
            }
            if (isMoving)
            {
                previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
            }

        }
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            atacar = false;
            efectoImpacto.Play();
        }
    }
} 

