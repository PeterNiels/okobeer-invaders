using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public float speed = 3;
    public float spawnIntervalNedre = 2f;
    public float spawnIntervalovre = 8f;
    public Vector3 start;
    public Vector3 target;
    public Vector3 d;
    public GameObject frugt;

    // sætter start targetet som husker position
    private void Start()
    {
        d = target;
    }
    // Update is called once per frame
    // står for fjeneden bevæger sig frem og tilbage
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
}
