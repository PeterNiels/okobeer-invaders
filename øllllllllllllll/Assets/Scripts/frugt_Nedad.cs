using UnityEngine;
using System.Collections;

public class frugt_Nedad : MonoBehaviour
{
    public GameObject frugt;
    private float spawnIntervalNedre = 5f;
    private float spawnIntervalovre = 15f;

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
