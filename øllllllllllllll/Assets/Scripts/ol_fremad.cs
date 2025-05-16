using UnityEngine;
public class ol_speed : MonoBehaviour
{
    private float speed = 10.0f;
    private float outOfBounds = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    // Update is called once per frame
    void Update()
    //g�r s� den bev�ger sig automatisk n�r den er i scenen
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // �del�gger hvis den er for lagtv�k pga. lag
        if (transform.position.z > outOfBounds)
        {
            Destroy(gameObject);
        }
    }
    //�del�gger sig selv og "Other" hvis den rammer et object med tagget "enemy"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //siger til spawnmangeren at der en der d�d.
            other.gameObject.transform.parent.GetComponent<spawnManger>().checkifDead++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }

}
