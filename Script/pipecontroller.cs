using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipecontroller : MonoBehaviour
{
    [SerializeField] private int speed;
    public GameMan ga; //Yazd���m�z di�er Script(Kod dosyas�) e ula�mak i�in 
    Vector3 left;
    private void Start()
    {
        left = Vector3.left * speed;
        ga = GameObject.Find("Player").GetComponent<GameMan>();//Scriptin nerede oldu�unu belirttik


    }
    void FixedUpdate()
    {
        transform.position += left*Time.deltaTime;//Borular�n sola gitmesi i�in
        sil();
    }
   void sil()//S�n�r d���na ��kan borular�n silinmesi i�in
    {
        if(transform.position.x<-10)
        {
            ga.instantePipe();//Boru yaratmak i�in
            Destroy(gameObject);//Boruyu silme kodu
        }
    }
}
