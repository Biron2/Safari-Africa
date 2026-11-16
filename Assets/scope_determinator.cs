using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope_determinator : MonoBehaviour
{
    private WeaponController _WeaponController;
    private game_controller _Game_Controller;
    private randomclickgame _Randomclickgame;

    private void Awake()
    {
        _WeaponController = GameObject.Find("Canvas/GameController/weapon").GetComponent<WeaponController>();
        _Game_Controller = GameObject.Find("Canvas/GameController").GetComponent<game_controller>();
        _Randomclickgame = GameObject.Find("GameManager").GetComponent<randomclickgame>();
        Destroy(gameObject, 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("animal"))
        {
            Destroy(collision.transform.parent.gameObject);
            _WeaponController.weapons_sound.PlayOneShot(_WeaponController.succes_hit);
            Destroy(gameObject);

            _Randomclickgame.shotedTarakan++;
            _Game_Controller.RatCounterUpdate();
            _Game_Controller.WinMethod();
        }
    }
}
