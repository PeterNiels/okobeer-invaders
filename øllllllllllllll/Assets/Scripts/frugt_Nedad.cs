using UnityEngine;

public class frugt_Nedad : MonoBehaviour
{
    public float speed = 1.0f;
    public float outOfBounds = -10f;
    public int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);

        if (transform.position.z < outOfBounds)
        {
            Destroy(gameObject);
        }
    }
    

}
