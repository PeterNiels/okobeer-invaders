using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class frugt_Nedad : MonoBehaviour
{
    public GameObject frugt;
    public float spawnIntervalNedre = 2f;
    public float spawnIntervalovre = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(SkudDelayRutine());
    }
    private float Skud()
    {
        float spawnInterval = Random.Range(spawnIntervalNedre, spawnIntervalovre);
        return spawnInterval;
    }
    IEnumerator SkudDelayRutine()
    {
        float Delay = Skud();
        yield return new WaitForSeconds(Delay);
        Instantiate(frugt, transform.position, transform.rotation);
        StartCoroutine(SkudDelayRutine());
    }


}
