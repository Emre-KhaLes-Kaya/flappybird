using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text gameobjesine kodlarla eri�mek i�in gerekli olan k�t�phane

public class Player : MonoBehaviour
{
    
    private bool ispress => Input.anyKeyDown; // Herhangi bir tu�a bas�ld���nda ispress'i o anl�k true yapan 'fonksion'
    [SerializeField]private int speed;//Unity �zerinde speed de�erini verdim '6'
    private Rigidbody2D rb;
    public Text txt;//Unity �zerinden text objsini belirttim
    public GameObject panel;//Unity �zerinden text objsini belirttim
    public Text txt_LastSkor;
    public Text txt_Best;
    private int skor;
    private int bestSkor;
    private void Start()//Ba�lad���nda bir kere �al���r
    {
        rb = transform.GetComponent<Rigidbody2D>(); //Rigidbody2D nin hangi Rigidbody2D oldu�unu belirttim
        if(PlayerPrefs.HasKey("BestSkor")) bestSkor=PlayerPrefs.GetInt("BestSkor");

    }
    void Update()//D�ng� halinde �al���r. D�ng� bitti�inde an�nda tekrar ba�a d�n�p �al���r
    {
        if (ispress)     Jump();//ispress true ise Jump void'i �a�r�l�r

    }
    private void FixedUpdate()//D�ng� halinde �al���r. D�ng� bitti�inde zamana ba�l� olarak tekrar ba�a d�n�p �al���r
    {
        max_min();  
        donmeanim(); 
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //�arp��ma ger�ekle�ti�i an 1 kere �al���r. Hangi Collider'a �arparsa onu 'collision' olarak d�nd�r�r. 
    {
        if (collision.collider.tag == "Yap�")  //TO DO GAMEOVER--------------------------------------------------------------------------
        {
            gameover();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Collider'da isTrigger tikli ise; �arp��ma ger�ekle�ti�i an 1 kere �al���r. Hangi Collider'a �arparsa onu 'collision' olarak d�nd�r�r. 
    {
        if (collision.tag == "Gecit")    skoryaz();

    }
    void Jump()//Ger�ek Flappy Birde benzesin diye detayl� u�ma
    {
        if (rb.velocity.y + speed > 10) //H�z� istedi�im de�erin �st�ne ��kmas�n diye kontrol if'i
            rb.velocity = new Vector2(0, 7);
        else//Yukar� y�nl� h�z ekleme 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, speed * 40));
        }
            
        transform.rotation=Quaternion.Euler(0,0,45); //Ku�un ba��n� yukar� kald�rma
    }
    void donmeanim()//Ku� a�a�� bakma olay�
    {
        if(transform.rotation.eulerAngles.z <= 90 || transform.rotation.eulerAngles.z>300)//Ku� a�a�� bakma s�n�r�
            transform.Rotate(new Vector3(0,0,-100)*Time.deltaTime, Space.World); //�zel Fonk Rotate gameobj verilen de�ere do�ru d�ner
    }
    void max_min()//Ku�un a�a�� d��me h�z�n� s�n�rlamak i�in
    {
        if (rb.velocity.y < -8) rb.velocity = new Vector2(0, -8);
    }
    void skoryaz()//Text de�i�tirmek i�in
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
