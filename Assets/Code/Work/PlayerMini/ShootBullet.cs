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
    private void Awake()
    {
        PC = new PlayerMini_Control();
    }

    void Start()
    {

        energy = maxEnergy;
        SetEnergyBar();
    }

    private void OnEnable()
    {
        PC.PlayerMini.Shoot.performed += Shoot;
        PC.Enable();
    }

    private void OnDisable()
    {

        PC.Disable();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (energy > 0)
        {
            Debug.Log("shoot");

            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = this.transform.up * 12f;
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
            energy -= 1;
            SetEnergyBar();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown("Attack"))
        //{
        //    if (energy > 0)
        //    {
        //        Shoot();
        //        energy -= 1;
        //        SetEnergyBar();
        //    }
        //}
    }

    void SetEnergyBar()
    {
        energyBar.GetComponent<Image>().fillAmount = energy / maxEnergy;
    }
}
