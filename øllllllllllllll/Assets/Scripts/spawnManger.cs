using UnityEngine;

public class spawnManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int[] spawnPos = { -8, -6, -4, -2, 0, 2, 4, 6, 8 };
    private int Husker = 0;
    public int score;
    public int checkifDead = 0;
    public GameObject Enemy;
    public GameObject parentEnemy;
    public UI UI;
    void Update()
    {
       
        if (Husker != checkifDead && checkifDead !=spawnPos.Length)
        {
            Husker = checkifDead;
            UI.Score();
        }
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
