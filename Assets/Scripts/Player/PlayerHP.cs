using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour, IgetDamagedInterface
{
    public int hp;
    [SerializeField] private GameObject particle;
    [SerializeField] private AudioSource explotionSound;

    private void Update()
    {
        if (hp < 0)
        {
            hp = 0;
            if(hp == 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
    }

    IEnumerator Die()
    {
        explotionSound.Play();
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
