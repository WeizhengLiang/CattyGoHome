using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishSoundEffect;
    [SerializeField] private GameObject dialogPanel;
    private bool levelCompleted = false;

    private void Update()
    {
        if (dialogPanel.GetComponent<Dialog>().dialogFinished && levelCompleted)
        {
            Invoke("LevelCompleted", 2f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSoundEffect.Play();
            ActivateDialog();
            levelCompleted = true;

            if (SceneManager.GetActiveScene().name == "Scene 2")
            {
                GameObject.Find("PLayer").GetComponent<PLayerMovement>().End();
            }
        }
    }

    private void ActivateDialog()
    {
        dialogPanel.SetActive(true);
    }

    private void LevelCompleted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
