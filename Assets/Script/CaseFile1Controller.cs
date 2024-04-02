using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CaseFile1Controller : MonoBehaviour
{
    [Header("Character Dropdown", order = 0)]
    [SerializeField] TMP_Dropdown character_dropdown;
    [SerializeField] SpriteRenderer character_image;

    [Header("Weapon Dropdown",order = 1)]
    [SerializeField] TMP_Dropdown weapon_dropdown;
    [SerializeField] SpriteRenderer weapon_image;

    // Start is called before the first frame update
    void Start()
    {
        //character_image.sprite = character_dropdown.captionImage.sprite;
        changeCharacterImage();
        changeWeaponImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Get Value
    public void GetValue()
    {
        Debug.Log(character_dropdown.value);
    }

    //Change Character image to new index
    public void changeCharacterImage()
    {
        //GetValue();
        //Debug.Log(character_image);
        character_image.sprite = character_dropdown.captionImage.sprite;
    }

    //Change Character image to new index
    public void changeWeaponImage()
    {
        //GetValue();
        //Debug.Log(weapon_image);
        weapon_image.sprite = weapon_dropdown.captionImage.sprite;
    }

    //NEXT SCENE Button
    public void caseFileSubmitted()
    {
        PlayerDataController.instance.characterSelected = character_dropdown.value;
        Debug.Log(character_dropdown.value);

        PlayerDataController.instance.weaponSelected = weapon_dropdown.value;
        Debug.Log(weapon_dropdown.value);

        SceneManager.LoadScene("End_scene");
    }
    //Grabs all inserted values
}
