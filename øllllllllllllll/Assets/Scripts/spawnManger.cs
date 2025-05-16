using UnityEngine;

public class spawnManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int[] spawnPos = { -8, -6, -4, -2, 0, 2, 4, 6, 8 };
    private int Husker = 0;
    private AudioSource DeadAudio;
    public int score;
    public int checkifDead = 0;
    public GameObject Enemy;
    public GameObject parentEnemy;
    public UI UI;
    public AudioClip dead;

    private void Start()
    {
        //sætter audioen når spillet starter
        DeadAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
       // checker om værdien er ændret samt den ikke er ligeså lang som længden pga. ellers dobbelt tæller den.
        if (Husker != checkifDead && checkifDead !=spawnPos.Length)
        {
            //ændrer huskeren, samt updatere UI og spiller en lyd
            Husker = checkifDead;
            UI.Score();
            DeadAudio.PlayOneShot(dead);
        }
        //den der spawner nye enemies når alle er døde.
        if (checkifDead == spawnPos.Length)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                Instantiate(Enemy, new Vector3(spawnPos[i], transform.position.y, transform.position.z), transform.rotation, parentEnemy.transform);
            }
                checkifDead = 0;
        }
    }
}
