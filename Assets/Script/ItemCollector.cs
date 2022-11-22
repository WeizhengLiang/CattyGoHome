using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    private int bananas = 0;

    [SerializeField] private TextMeshProUGUI BananaText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            bananas++;
            BananaText.text = "Bananas: " + bananas;
        }
    }
}
