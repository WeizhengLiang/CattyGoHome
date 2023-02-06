using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishSoundEffect;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject BGM;
    [SerializeField] private float volumeChangeDuration;
    private float originalVolume;
    private float elapsedTime = 0;
    private bool levelCompleted = false;

    private void Start()
    {
        originalVolume = BGM.GetComponent<AudioSource>().volume;
    }


    private void Update()
    {
        if (dialogPanel.GetComponent<Dialog>().dialogFinished && levelCompleted)
        {
            Invoke("LevelCompleted", 2f);
        }
        if (levelCompleted==true && SceneManager.GetActiveScene().name == "Scene 2")
        {
            elapsedTime += Time.deltaTime;
            LowerBGMVolume();
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

    private void LowerBGMVolume()
    {
        
        BGM.GetComponent<AudioSource>().volume = Mathf.Lerp(originalVolume, 0f, elapsedTime / volumeChangeDuration);
    }


}
