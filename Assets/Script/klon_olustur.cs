using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon_olustur : MonoBehaviour
{
    public GameObject altin;
    public GameObject jeep;
    public GameObject tas;
    public GameObject kutuk;
    public GameObject miknatis;

    public Transform oyuncu;

    float silinme_zamani = 5.0f;

    float sol_X_koordinati = -1.27f;
    float sol_Y_koordinati = .4f;
    float sag_X_koordinati = 1.27f;
    float sag_Y_koordinati = -0.4f;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("nesne_klonla", 0, 0.5f);

        
    }

    void nesne_klonla()
    {
        int rastsayi = Random.Range(0, 100);

        if(rastsayi>0 && rastsayi < 80)
        {
            klonla(altin, 1.0f);
        }
        if(rastsayi>80 && rastsayi < 85)
        {
            klonla(kutuk, 0f);
        }
        if (rastsayi > 85 && rastsayi < 90)
        {
            klonla(tas, 0f);
        }
        if (rastsayi > 90 && rastsayi < 95)
        {
            klonla(jeep, 0.05f);
        }
        if (rastsayi > 95 && rastsayi < 100)
        {
            if (oyuncu.gameObject.GetComponent<oyuncu>().miknatis_alindi == false)
            {
                klonla(miknatis, .4f);
            }
        }
    }   

    void klonla(GameObject nesne, float Y_koordinat)
    {
        GameObject yeni_klon = Instantiate(nesne);

        int rastsayi = Random.Range(0, 100);

        if (nesne == jeep)
        {
            yeni_klon.transform.Rotate(new Vector3(0f, 180f, 0f));
        }

        if (rastsayi < 50)
        {
            Debug.Log("sol obje olusturuluyor");
            yeni_klon.transform.position = new Vector3(sol_X_koordinati, Y_koordinat, oyuncu.position.z + 20.0f);

        }
        else if (rastsayi > 50)
        {
            Debug.Log("sag obje olusturuluyor");
            yeni_klon.transform.position = new Vector3(sag_X_koordinati, Y_koordinat, oyuncu.position.z + 20.0f);

        }
        Destroy(yeni_klon, silinme_zamani);
    }


}
