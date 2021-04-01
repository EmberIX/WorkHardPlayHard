using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShootBullet : MonoBehaviour
{
    public PlayerMini_Control PC;
    public GameObject Bullet;
    public GameObject smallBullet;
    public GameObject specialBullet;
    public Image energyBar;

    //public InputAction shoot;
    public float energy;
    public float maxEnergy;
    // Start is called before the first frame update
    void Start()
    {
        PC = new PlayerMini_Control();
        energy = maxEnergy;
        SetEnergyBar();
    }

    private void OnEnable()
    {
        //PC.PlayerMini.Shoot.performed += Shoot;
        //PC.Enable();
    }

    private void OnDisable()
    {

        PC.Disable();
    }

    private void Shoot()
    {
        Debug.Log("shoot");

        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = this.transform.up * 12f;
        bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
    }

    // Update is called once per frame
    void Update()
    {
        //shoot.performed += Shoot;

        if (Input.GetButtonDown("Attack"))
        {
            if (energy > 0)
            {
                Shoot();
                energy -= 1;
                SetEnergyBar();
            }
        }
    }

    void SetEnergyBar()
    {
        energyBar.GetComponent<Image>().fillAmount = energy / maxEnergy;
    }
}
