using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;
    public Transform particulas;
    public Transform particulasRojas;
    private ParticleSystem systemaParticulas;
    private ParticleSystem systemaParticulasRojas;

    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        systemaParticulas = particulas.GetComponent<ParticleSystem> ();
        systemaParticulas.Stop();

        rb = GetComponent<Rigidbody> ();
        systemaParticulasRojas = particulasRojas.GetComponent<ParticleSystem> ();
        systemaParticulasRojas.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate (){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movimiento = new Vector3 (moveHorizontal, 0.0f, moveVertical); 

        rb.AddForce (movimiento*speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Amarillo")){
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            systemaParticulas.Play();
            other.gameObject.SetActive(false);
        } else if (other.gameObject.CompareTag("Rojo")){
            posicion = other.gameObject.transform.position;
            particulasRojas.position = posicion;
            systemaParticulasRojas = particulasRojas.GetComponent<ParticleSystem> ();
            systemaParticulasRojas.Play();
            other.gameObject.SetActive(false);
        }
    }
}
