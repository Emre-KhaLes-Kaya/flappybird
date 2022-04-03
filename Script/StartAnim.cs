using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnim : MonoBehaviour
{
    public Text txt;
    public GameObject Bird;
    bool ispress => Input.anyKey;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (ispress) OpenClose();
    }
    public void OpenClose()
    {
        txt.enabled = !txt.enabled;
        FreezeConstraints();
        Bird.GetComponent<Player>().enabled = !Bird.GetComponent<Player>().enabled;
        Bird.GetComponent<GameMan>().enabled = !Bird.GetComponent<GameMan>().enabled;
        gameObject.active = !gameObject.active;
        Destroy(gameObject);
    }
    void FreezeConstraints()
    {
        int x = 0;
        if(x%2==1)
        {
            Bird.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            x++;
        }
        else
        {
            Bird.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            x++;
        }
    }

}
