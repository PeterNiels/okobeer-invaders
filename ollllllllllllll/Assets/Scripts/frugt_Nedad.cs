using UnityEngine;
using System.Collections;

public class frugt_Nedad : MonoBehaviour
{
    public GameObject frugt;
    private float spawnIntervalNedre = 5f;
    private float spawnIntervalovre = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //starten corutinen
    private void Start()
    {
        StartCoroutine(SkudDelayRutine());
    }
    //en funktion der giver et randomt spanwinterval
    private float Skud()
    {
        float spawnInterval = Random.Range(spawnIntervalNedre, spawnIntervalovre);
        return spawnInterval;
    }
    //en corutine der først får et random value hvorfra den så venter og derefter spawner en frugt. derefter starter den sig selv igen.
    IEnumerator SkudDelayRutine()
    {
        float Delay = Skud();
        yield return new WaitForSeconds(Delay);
        Instantiate(frugt, transform.position, transform.rotation);
        StartCoroutine(SkudDelayRutine());
    }


}
