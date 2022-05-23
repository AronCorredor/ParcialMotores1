using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    [Header("Informacion Desplazamiento")]
    public float rapidezDesplazamiento = 10.0f;

    [Header("Informacion Partida")]
    public Camera camaraPP;
    public CapsuleCollider col;
    public float magnitudSalto;
    public LayerMask capaPiso;
    private Rigidbody rb;
    public GameObject nena;
    public Text contadorMuñecas;
    public GameObject ParedNena;
    public Text ganaste;

    [Header("Informacion Saltos")]
    public int maxSaltos = 2;
    public int saltoActual = 0;
    private bool enElSuelo = true;
    public int cont;

    [Header("Coordenadas")]
    float x;
    float y;
    float z;

    [Header("Sonido")]
    public AudioSource controlSonido;
    public AudioSource controlSonidoDerrumbe;
    public AudioSource controlSonidoNena;
    public AudioClip sonidoMusica;
    public AudioClip sonidoNena;
    public AudioClip sonidoDerrumbe;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        col = GetComponent<CapsuleCollider>();
        cont = 0;
        Time.timeScale = 1;
        controlSonido.PlayOneShot(sonidoMusica);
    }
    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space) && EstaEnPiso())
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);

        }

        if (Input.GetButtonDown("Jump") && (enElSuelo || maxSaltos > saltoActual))
        {
            rb.velocity = new Vector3(0f, magnitudSalto, 0f * Time.deltaTime);
            enElSuelo = false;
            saltoActual++;
        }
        if (Input.GetKey("p"))
        {
            Application.Quit();
        }

    }
    private bool EstaEnPiso()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, capaPiso);
    }

    private void OnCollisionEnter(Collision collision)
    {
        enElSuelo = true;
        saltoActual = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Muñeca") == true)
        {
            cont = cont + 1;
            contarMuñecas();
            other.gameObject.SetActive(false);
        }
        if (cont == 4)
        {
            Destroy(ParedNena, 2);
            controlSonidoNena.PlayOneShot(sonidoNena);
            controlSonidoDerrumbe.PlayOneShot(sonidoDerrumbe);
        }
        
        if (other.gameObject.CompareTag("Nena"))
        {
            SceneManager.LoadScene("Ganaste");
        }
    }
    private void contarMuñecas()
    {
        contadorMuñecas.text = "MUÑECAS RECOLECTADAS: " + cont.ToString();
    }

}

