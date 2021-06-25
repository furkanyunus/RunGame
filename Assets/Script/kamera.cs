using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{


    public Transform takip_edilen_kup;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, takip_edilen_kup.position, Time.deltaTime * 3.0f);
        //şimdiki pozisyon(kameraPozis.) =(şimdki pozisyonundan,takipedilenkupn  posizyonuna dogru hareket edeccek zamana baglı olarak 3 adm geriden geleck
    }
}
