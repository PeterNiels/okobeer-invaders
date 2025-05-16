using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class playerController : MonoBehaviour
{
    private float horizantalInput;
    private bool klar = true;
    private AudioSource playerAudio;
    private bool isDead = false;
    public float speed = 1f;
    public float range = 10f;
    public float delay = 2f;
    public GameObject ol;
    public int health = 3;
    public UI UI;
    public AudioClip kast;
    public GameObject Menu;
    public GameObject playerUI;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //s�tter lyd og deaktivere menusk�rmen.
        playerAudio = GetComponent<AudioSource>();
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //styrer playeren i x aksen samt g�r den ikkek an bev�ge sig hvis den er ud over range
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
        //st�r for at skude samt spille lyd samt en cooldown med corutine.
        if (Input.GetKeyDown(KeyCode.Space) && klar)
        {
            Instantiate(ol, transform.position, transform.rotation);
            playerAudio.PlayOneShot(kast, 1f);
            StartCoroutine(SkudDelayRutine());
        }
        //st�r for genstarte spillet n�r menuen kommer fra.
        if (Input.GetKeyDown(KeyCode.Escape) && isDead)
        {
            isDead = false;
            SceneManager.LoadScene(0);
        }
        //delay rutinen til skudet
        IEnumerator SkudDelayRutine()
        {
            if (klar)
            {
                klar = false;
                yield return new WaitForSeconds(delay);
                klar = true;
            }
        }
    }
    //det der registrer n�r frugten "fjendens skud" rammer spilleren. samt holder styr p� liver og updatere UI.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frugt"))
        {
            //tjekker hvor menge liv hvis ikke s� d�d. destoyere frugten
            if (health >= 2)
            {
                health--;
                UI.UpdateHealth(health);
                Destroy(other.gameObject);
            }
            // �del�gger ogs� frugten samt aktivere menuen
            else
            {
                Destroy(other.gameObject);
                Menu.SetActive(true);
                isDead = true;
            }

        }

    }
}
