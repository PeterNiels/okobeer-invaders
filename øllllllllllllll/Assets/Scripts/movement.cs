using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
    public float speed = 3;
    public float spawnIntervalNedre = 2f;
    public float spawnIntervalovre = 8f;
    public Vector3 start;
    public Vector3 target;
    public Vector3 d;
    public GameObject frugt;

    private void Start()
    {
        d = target;
        StartCoroutine(SkudDelayRutine());
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, d, speed *  Time.deltaTime);

        if (0.0001f >= Vector3.Distance(transform.position, target))
        {
            d = start;
        }
        if (0.0001f >= Vector3.Distance(transform.position, start)) 
        {
            d = target;
        }
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
