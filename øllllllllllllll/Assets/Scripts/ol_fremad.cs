using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ol_speed : MonoBehaviour
{
    private float speed = 10.0f;
    private float outOfBounds = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (transform.position.z > outOfBounds)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.transform.parent.GetComponent<spawnManger>().checkifDead++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }

}
