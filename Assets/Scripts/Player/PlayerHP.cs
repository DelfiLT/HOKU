using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour, IgetDamagedInterface
{
    [SerializeField] private float hp;
    private float maxHp;

    [SerializeField] private AudioClip explotionSound;
    public Slider slider;
    [SerializeField] private GameObject particlesDie;

    private bool shieldActivated;

    public float HP { get { return hp; } set {  hp = value; } }
    public bool ShieldActivated {  get { return shieldActivated; } set {  shieldActivated = value; } }

    private void Start()
    {
        shieldActivated = false;
        maxHp = hp;
    }

    private void Update()
    {
        slider.value = hp;

        if (hp < 0)
        {
            hp = 0;
            if(hp == 0)
            {
                StartCoroutine(Die());
            }
        }

        if(hp > maxHp)
        {
            hp = maxHp;
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

        particlesDie.SetActive(false);

        this.GetComponent<SpriteRenderer>().enabled = false;

        SpriteRenderer[] childrens = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in childrens)
        {
            child.enabled = false;
        }

        AudioManager.InstanceAudio.PlaySound(explotionSound);
        GameObject prefab = ParticlesObjectPool.ParticleInstance.GetPooledObject(ParticleTypes.ParticleExplotion.ToString());
        if (prefab != null)
        {
            prefab.transform.position = transform.position;
            prefab.transform.rotation = transform.rotation;
            prefab.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
