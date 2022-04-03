using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text gameobjesine kodlarla eriþmek için gerekli olan kütüphane

public class Player : MonoBehaviour
{
    
    private bool ispress => Input.anyKeyDown; // Herhangi bir tuþa basýldýðýnda ispress'i o anlýk true yapan 'fonksion'
    [SerializeField]private int speed;//Unity üzerinde speed deðerini verdim '6'
    private Rigidbody2D rb;
    public Text txt;//Unity üzerinden text objsini belirttim
    public GameObject panel;//Unity üzerinden text objsini belirttim
    public Text txt_LastSkor;
    public Text txt_Best;
    private int skor;
    private int bestSkor;
    private void Start()//Baþladýðýnda bir kere çalýþýr
    {
        rb = transform.GetComponent<Rigidbody2D>(); //Rigidbody2D nin hangi Rigidbody2D olduðunu belirttim
        if(PlayerPrefs.HasKey("BestSkor")) bestSkor=PlayerPrefs.GetInt("BestSkor");

    }
    void Update()//Döngü halinde çalýþýr. Döngü bittiðinde anýnda tekrar baþa dönüp çalýþýr
    {
        if (ispress)     Jump();//ispress true ise Jump void'i çaðrýlýr

    }
    private void FixedUpdate()//Döngü halinde çalýþýr. Döngü bittiðinde zamana baðlý olarak tekrar baþa dönüp çalýþýr
    {
        max_min();  
        donmeanim(); 
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //Çarpýþma gerçekleþtiði an 1 kere çalýþýr. Hangi Collider'a çarparsa onu 'collision' olarak döndürür. 
    {
        if (collision.collider.tag == "Yapý")  //TO DO GAMEOVER--------------------------------------------------------------------------
        {
            gameover();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Collider'da isTrigger tikli ise; Çarpýþma gerçekleþtiði an 1 kere çalýþýr. Hangi Collider'a çarparsa onu 'collision' olarak döndürür. 
    {
        if (collision.tag == "Gecit")    skoryaz();

    }
    void Jump()//Gerçek Flappy Birde benzesin diye detaylý uçma
    {
        if (rb.velocity.y + speed > 10) //Hýzý istediðim deðerin üstüne çýkmasýn diye kontrol if'i
            rb.velocity = new Vector2(0, 7);
        else//Yukarý yönlü hýz ekleme 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, speed * 40));
        }
            
        transform.rotation=Quaternion.Euler(0,0,45); //Kuþun baþýný yukarý kaldýrma
    }
    void donmeanim()//Kuþ aþaðý bakma olayý
    {
        if(transform.rotation.eulerAngles.z <= 90 || transform.rotation.eulerAngles.z>300)//Kuþ aþaðý bakma sýnýrý
            transform.Rotate(new Vector3(0,0,-100)*Time.deltaTime, Space.World); //Özel Fonk Rotate gameobj verilen deðere doðru döner
    }
    void max_min()//Kuþun aþaðý düþme hýzýný sýnýrlamak için
    {
        if (rb.velocity.y < -8) rb.velocity = new Vector2(0, -8);
    }
    void skoryaz()//Text deðiþtirmek için
    {
        skor++;
        txt.text = skor.ToString();
    }
    void gameover()
    {
        Time.timeScale = 0;
        txt_LastSkor.text = skor.ToString();
        if(skor>bestSkor)
        {
            bestSkor = skor;
            PlayerPrefs.SetInt("BestSkor", bestSkor);
        }
        txt_Best.text = bestSkor.ToString();
        panel.active = !panel.active;

    }

}
