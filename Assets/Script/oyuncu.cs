using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncu : MonoBehaviour
{
    private bool _ziplama = false;

    private int suankiYol = 1;
    public Animator animasyon;

    public GameObject toz_efekti;
    public GameObject altin_efekti;

    public GameObject bitti_pnl;

    public TMPro.TextMeshProUGUI puan_txt;
    public TMPro.TextMeshProUGUI toplanan_altin_txt;
    public TMPro.TextMeshProUGUI miknatis_sure;

    public Transform yol1;
    public Transform yol2;
    public Transform yol3;

    public Rigidbody rigi;

    bool sag = true;

    int puan = 0;
    int toplanan_altin = 0;

    private int _miknatis_sure = 10;
    public bool miknatis_alindi = false;

    public AudioSource ses_dosyasi;
    public AudioSource kosma_ses_dosyasi;
    public AudioClip altin_temas_sesi;

    private void Start()
    {
        animasyon.SetBool("Grounded", true);
        animasyon.SetFloat("MoveSpeed", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SON_1" && suankiYol != 1)
        {
            Debug.Log("1. yolun başı, yol3 hareket");
            Debug.Log(yol3.position);
            yol3.position = new Vector3(yol3.position.x, yol3.position.y, yol3.position.z + 48.0f);
            Debug.Log(yol3.position);
            suankiYol = 1;
        }
        if (other.gameObject.name == "SON_2" && suankiYol != 2)
        {
            Debug.Log("2. yolun başı, yol1 hareket");
            Debug.Log(yol1.position);
            yol1.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z + 48.0f);
            Debug.Log(yol1.position);
            suankiYol = 2;
        }
        if (other.gameObject.name == "SON_3" && suankiYol != 3)
        {
            Debug.Log("3. yolun başı, yol2 hareket");
            Debug.Log(yol2.position);
            yol2.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 48.0f);
            Debug.Log(yol2.position);
            suankiYol = 3;
        }

        if (other.gameObject.tag == "engel")
        {
            Time.timeScale = 0f;
            bitti_pnl.SetActive(true);

        }

        if (other.gameObject.tag == "altin")
        {
            ses_dosyasi.PlayOneShot(altin_temas_sesi);
            GameObject yeni_altin_efekti = Instantiate(altin_efekti, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            Destroy(other.gameObject);

            toplanan_altin++;
            puan += 5;

            puan_txt.text = puan.ToString("00000");
            toplanan_altin_txt.text = toplanan_altin.ToString();

        
        }
        if (other.gameObject.tag == "miknatis")
        {
            GameObject[] tum_miknatislar = GameObject.FindGameObjectsWithTag("miknatis");
            
            foreach(GameObject miknatis in tum_miknatislar)
            {
                Destroy(miknatis);
            }
            miknatis_alindi = true;
            miknatis_sure.gameObject.SetActive(true);
            miknatis_sure.text = "10";
            _miknatis_sure = 10;
            InvokeRepeating("miknatis_sure_say", 0f, 1f);
            Invoke("miknatisi_resetle", 10.0f);
        }

    }
    void miknatisi_resetle()
    {
        miknatis_alindi = false;
        miknatis_sure.gameObject.SetActive(false);
        CancelInvoke("miknatis_sure_say");
    }

    void miknatis_sure_say()
    {
        Debug.Log("geriye saydım!");
        _miknatis_sure -= 1;
        miknatis_sure.text = _miknatis_sure.ToString();
    }

    private void OnCollisionStay(Collision collision)
    {
        toz_efekti.SetActive(true);
        kosma_ses_dosyasi.enabled = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        toz_efekti.SetActive(false);
        kosma_ses_dosyasi.enabled = false;
    }

     void Update()
    {
        hareket();

        if (miknatis_alindi)
        {
            Debug.Log("MIKNATIS POWER!!!");
        }
    }

     void hareket()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !_ziplama)
        {
            animasyon.SetBool("zipla", true);
            animasyon.SetBool("Grounded", false);
            rigi.velocity = Vector3.up * 300.0f * Time.deltaTime;
            _ziplama = true;
            Invoke("ziplama_iptal", .9f);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sag = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sag = false;

        }
        if (sag)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(1.5f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }

        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-1.5f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);

        }
        transform.Translate(0, 0, 5 * Time.deltaTime);
    }

    void ziplama_iptal()
    {
        animasyon.SetBool("zipla", false);
        animasyon.SetBool("Grounded", true);
        _ziplama = false;
    }
}
