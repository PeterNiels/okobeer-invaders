using UnityEngine;
public class ol_speed : MonoBehaviour
{
    private float speed = 10.0f;
    private float outOfBounds = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    // Update is called once per frame
    void Update()
    //gør så den bevæger sig automatisk når den er i scenen
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // ødelægger hvis den er for lagtvæk pga. lag
        if (transform.position.z > outOfBounds)
        {
            Destroy(gameObject);
        }
    }
    //ødelægger sig selv og "Other" hvis den rammer et object med tagget "enemy"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //siger til spawnmangeren at der en der død.
            other.gameObject.transform.parent.GetComponent<spawnManger>().checkifDead++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }

}
