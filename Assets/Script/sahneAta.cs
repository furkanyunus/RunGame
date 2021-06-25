using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sahneAta : MonoBehaviour
{
    public string bolum1;
  
    public void SahneGecis1()
    {
        SceneManager.LoadScene(bolum1);
    }
 


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("bolum2");
        }
    }


}
