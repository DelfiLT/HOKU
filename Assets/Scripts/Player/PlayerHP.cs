using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour, IgetDamagedInterface
{
    [SerializeField] private float hp;
    [SerializeField] private GameObject particle;
    [SerializeField] private AudioSource explotionSound;

    private bool shieldActivated;

    public float HP { get { return hp; } set {  hp = value; } }
    public bool ShieldActivated {  get { return shieldActivated; } set {  shieldActivated = value; } }

    private void Start()
    {
        shieldActivated = false;
    }

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

        if(hp > 100)
        {
            hp = 100;
        }
    }

    public void GetDamaged(int damage)
    {
        if (!shieldActivated)
        {
            hp -= damage;
        }
    }

    IEnumerator Die()
    {
        PlayerMovement playerMovement = this.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;

        PlayerShooting playerShooting = this.GetComponent<PlayerShooting>();
        playerShooting.enabled = false;

        this.GetComponent<SpriteRenderer>().enabled = false;

        SpriteRenderer[] childrens = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in childrens)
        {
            child.enabled = false;
        }

        explotionSound.Play(); //este sonido no esta funcionando
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
