using UnityEngine;

public class ol_nedad : MonoBehaviour
{
    public float speed = 1.0f;
    private float outOfBounds = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    //g�r at den automatisk bev�ger sig n�r den bliver inistiated/spawned
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);

        //g�r s� den bliver �delagt hvis den er langt v�k fordi det ellers kan sakbe lag i lang tid
        if (transform.position.z < outOfBounds)
        {
            Destroy(gameObject);
        }
    }
}
