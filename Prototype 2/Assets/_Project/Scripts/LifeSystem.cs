using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] GameObject everything;
    [SerializeField] private int _playerLife = 3;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy"){
            _playerLife--;
            Debug.Log("Player life: " + _playerLife);
            if(_playerLife == 0){
                Debug.Log("Player is dead!");
                Destroy(everything);
            }
        }
    }
}
