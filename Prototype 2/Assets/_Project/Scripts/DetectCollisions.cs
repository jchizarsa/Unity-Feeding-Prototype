using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public enum AnimalType{
        Fox,
        Moose,
        Stag,
    };
    public Slider slider;
    public AnimalType animalType;
    
    void Start(){

    }
    /// <summary> -- If you hit something, destroy both projectile and enemy -- </summary>
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Player"){
            switch(animalType){
                case AnimalType.Fox:{
                    slider.value += 1;
                    Destroy(other.gameObject);
                    if(slider.value == 1){
                        StartCoroutine(WaitThenDestroy());
                        GameManager.instance.Score += 1;
                        Debug.Log("Score is: " + GameManager.instance.Score);
                    }
                    break;
                }
                case AnimalType.Moose:{
                    slider.value += .25f;
                    Destroy(other.gameObject);
                    if(slider.value == 1){
                        StartCoroutine(WaitThenDestroy());
                        GameManager.instance.Score += 2;
                        Debug.Log("Score is: " + GameManager.instance.Score);
                    }
                    break;
                }
                case AnimalType.Stag:{
                    slider.value += .5f;
                    Destroy(other.gameObject);
                    if(slider.value == 1){
                        StartCoroutine(WaitThenDestroy());
                        GameManager.instance.Score += 4;
                        Debug.Log("Score is: " + GameManager.instance.Score);
                    }
                    break;
                }
                    
            }
        }
    }

    IEnumerator WaitThenDestroy(){
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
