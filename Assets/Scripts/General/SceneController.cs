using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool Level;
    public int indexlevel;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource audioWhoosh;
    [SerializeField] private AudioSource audiofire;
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
       SceneManager.LoadScene(index);
    }

    public void ChangePanel()
    {
        panelSettings.SetActive(true);
        music.Play();
    }

    public void exitPanel()
    {
        panelSettings.SetActive(false);
        music.Play();
    }

    public void Play()
    {
        timeline.Play();
        StartCoroutine(Loadingscreen());
    }

    public void Exit()
    {
        Application.Quit();
    }

   IEnumerator Loadingscreen()
    {
        yield return new WaitForSeconds(1f);
        audioWhoosh.Play();
        audiofire.Play();

        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene(1);
    }
}
