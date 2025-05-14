using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public int checkifDead = 0;
    void Update()
    {
       if (checkifDead == 8 )
       {
        SceneManager.LoadScene(0);
       }
        
    }
       
   
   

}
