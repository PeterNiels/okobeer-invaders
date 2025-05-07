using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    private float horizantalInput;
    private bool klar = true;
    public float speed = 1f;
    public float range = 10f;
    public float delay = 2f;
    public GameObject ol;
    public int health = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizantalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizantalInput * speed * Time.deltaTime);

        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && klar)
        {
            Instantiate(ol, transform.position, transform.rotation);
            StartCoroutine(SkudDelayRutine());
        }
        

    }
    IEnumerator SkudDelayRutine()
    {
        if (klar)
        {
            klar = false;
            yield return new WaitForSeconds(delay);
            klar = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frugt"))
        {
            if (health >= 0)
            {
                health--;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }

        }

    }
}
