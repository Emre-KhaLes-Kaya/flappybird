using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    
    [SerializeField]private GameObject pipe;//Unity �zerinden Boruyu belirttim
    public Vector3 pipepos=new Vector3(5,0,0);
    private void Start()
    {
        startinspipe();
    }
   public void instantePipe()//Boru ekleme kodu
    {
        
        Instantiate(pipe, pipepos, Quaternion.identity);
        poscalc();
    }
   public void poscalc()//Borular�n Y de�erini hesaplamak i�in
    {
        var chance = Random.value;
        var value = Random.value;

        if (chance <= 0.5f && pipepos.y + value < 2) pipepos.y += value;
        else if (chance > 0.5f && pipepos.y - value > -2) pipepos.y -= value;
        else poscalc();

    }

    void startinspipe()
    {
        for (int i = 0; i < 4; i++)//Ba�lang��ta 4 boru ekliyoruz. 
        {
            Instantiate(pipe, pipepos, Quaternion.identity);//Se�ili gameobj'nin sahneye eklenmesi i�in
            poscalc();
            pipepos.x += 5;
        }
        pipepos = new Vector3(10, 0, 0);
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
