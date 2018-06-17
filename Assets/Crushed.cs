using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushed : MonoBehaviour {

    public GameObject player;
    public GameObject blood;
    public GameObject blood2;
    public GameObject meat;
    public GameObject meat2;
    public GameObject meat3;
    public GameObject RestartPanel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Crate(Clone)")
        {
            SoundManagerScript.PlaySound("crushed");
            SoundManagerScript.PlaySound("scream");
            Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(blood2, transform.position, Quaternion.identity);
            Instantiate(meat, transform.position, Quaternion.identity);
            Instantiate(meat2, transform.position, Quaternion.identity);
            Instantiate(meat3, transform.position, Quaternion.identity);
            player.SetActive(false);
            RestartPanel.SetActive(true);
        }
    }
}
