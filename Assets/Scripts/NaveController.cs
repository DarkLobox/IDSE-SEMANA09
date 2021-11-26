using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveController : MonoBehaviour
{
    public Text texto;
    private bool up = false;
    private bool down = false;
    private bool left = false;
    private bool right = false;
    private bool shoot = false;
    private float playerSpeed = 5f;
    
    public GameObject bala;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            up = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            down = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot = true;
        }
    }
    private void FixedUpdate()
    {
        if (up)
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            up = false;
        }

        if (down)
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
            down = false;
        }

        if (left)
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            left = false;
        }

        if (right)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            right = false;
        }

        if (shoot)
        {
            GameObject b = Instantiate(bala,transform.position,transform.rotation);
            b.SetActive(true);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,15,0), ForceMode2D.Impulse);
            Destroy(b, 3);
            shoot = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "portal")
        {
            this.gameObject.SetActive(false);
            texto.text = "GANASTE";
        }
        if (collision.gameObject.tag == "enemigo")
        {
            GameObject efecto = Instantiate(explosion,transform.position,transform.rotation);
            efecto.SetActive(true);
            this.gameObject.SetActive(false);
            texto.text = "PERDISTE";
        }
    }
}
