using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 3;
    public Vector3 start;
    public Vector3 target;

    public Vector3 d;

    private void Start()
    {
        d = target;
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

}
