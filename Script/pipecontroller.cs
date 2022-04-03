using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipecontroller : MonoBehaviour
{
    [SerializeField] private int speed;
    public GameMan ga; //Yazdýðýmýz diðer Script(Kod dosyasý) e ulaþmak için 
    Vector3 left;
    private void Start()
    {
        left = Vector3.left * speed;
        ga = GameObject.Find("Player").GetComponent<GameMan>();//Scriptin nerede olduðunu belirttik


    }
    void FixedUpdate()
    {
        transform.position += left*Time.deltaTime;//Borularýn sola gitmesi için
        sil();
    }
   void sil()//Sýnýr dýþýna çýkan borularýn silinmesi için
    {
        if(transform.position.x<-10)
        {
            ga.instantePipe();//Boru yaratmak için
            Destroy(gameObject);//Boruyu silme kodu
        }
    }
}
