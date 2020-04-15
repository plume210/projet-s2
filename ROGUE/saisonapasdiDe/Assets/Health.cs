using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health = 100;
    public RectTransform healthBar;
    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet") && view.IsMine)
        {
            health -= 10;
        }

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead!");
        }
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
    
}
