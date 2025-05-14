using UnityEngine;

public class ol_nedad : MonoBehaviour
{
    public float speed = 1.0f;
    private float outOfBounds = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);

        if (transform.position.z < outOfBounds)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }

    }

}
