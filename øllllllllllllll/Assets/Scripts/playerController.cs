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
        //sætter lyd og deaktivere menuskærmen.
        playerAudio = GetComponent<AudioSource>();
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //styrer playeren i x aksen samt gør den ikkek an bevæge sig hvis den er ud over range
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
        //står for at skude samt spille lyd samt en cooldown med corutine.
        if (Input.GetKeyDown(KeyCode.Space) && klar)
        {
            Instantiate(ol, transform.position, transform.rotation);
            playerAudio.PlayOneShot(kast, 1f);
            StartCoroutine(SkudDelayRutine());
        }
        //står for genstarte spillet når menuen kommer fra.
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
    //det der registrer når frugten "fjendens skud" rammer spilleren. samt holder styr på liver og updatere UI.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frugt"))
        {
            //tjekker hvor menge liv hvis ikke så død. destoyere frugten
            if (health >= 2)
            {
                health--;
                UI.UpdateHealth(health);
                Destroy(other.gameObject);
            }
            // ødelægger også frugten samt aktivere menuen
            else
            {
                Destroy(other.gameObject);
                Menu.SetActive(true);
                isDead = true;
            }

        }

    }
}
