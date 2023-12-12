using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private bool Level;
    public int indexlevel;
    [SerializeField] private AudioClip audioFire;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private ParticleSystem particles;


    void Update()
    {
        if (Level)
        {
            ChangeLevel(indexlevel);
        }
    }

    public void ChangeLevel(int index)
    {
        AudioManager.InstanceAudio.PlaySound(audioFire);
        SceneManager.LoadScene(index);
    }

    public void ChangePanel()
    {
        panelSettings.SetActive(true);
        AudioManager.InstanceAudio.PlaySound(audioFire);
    }

    public void exitPanel()
    {
        panelSettings.SetActive(false);
        AudioManager.InstanceAudio.PlaySound(audioFire);
    }

    public void Play()
    {
        timeline.Play();
        AudioManager.InstanceAudio.PlaySound(audioFire);
        StartCoroutine(Loadingscreen());
    }

    public void Exit()
    {
        AudioManager.InstanceAudio.PlaySound(audioFire);
        Application.Quit();
    }

   IEnumerator Loadingscreen()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene(1);
    }
}
