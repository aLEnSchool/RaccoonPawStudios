using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    [Header("Selected Objects")]
    public SpriteRenderer other_character;
    public SpriteRenderer weapon;

    [Header("Character Sprites")]
    [SerializeField] private Sprite claye;
    [SerializeField] private Sprite sadie;
    [SerializeField] private Sprite frannie;
    [SerializeField] private Sprite rosa;
    [SerializeField] private Sprite john;

    [Header("Weapon Sprites")]
    [SerializeField] private Sprite lighter;
    [SerializeField] private Sprite lantern;
    [SerializeField] private Sprite cookbook;
    [SerializeField] private Sprite mercury;

    [Header("Dialog Files")]
    [SerializeField] private TextAsset clayeDialog;
    [SerializeField] private TextAsset sadieDialog;
    [SerializeField] private TextAsset frannieDialog;
    [SerializeField] private TextAsset rosaDialog;
    [SerializeField] private TextAsset johnDialog;

    // Start is called before the first frame update
    void Start()
    {
        setCharacter();
        setObject();
    }

    //Set Character
    private void setCharacter()
    {
        if (PlayerDataController.instance.characterSelected == 0)
        {
            other_character.sprite = claye;
            DialogueManager.GetInstance().EnterDialogueMode(clayeDialog);
        }
        if (PlayerDataController.instance.characterSelected == 1)
        {
            other_character.sprite = sadie;
            DialogueManager.GetInstance().EnterDialogueMode(sadieDialog);
        }
        if (PlayerDataController.instance.characterSelected == 2)
        {
            other_character.sprite = frannie;
            DialogueManager.GetInstance().EnterDialogueMode(frannieDialog);
        }
        if (PlayerDataController.instance.characterSelected == 3)
        {
            other_character.sprite = rosa;
            DialogueManager.GetInstance().EnterDialogueMode(rosaDialog);
        }
        if (PlayerDataController.instance.characterSelected == 4)
        {
            other_character.sprite = john;
            DialogueManager.GetInstance().EnterDialogueMode(johnDialog);
        }
    }

    //Set Object
    private void setObject()
    {
        if (PlayerDataController.instance.weaponSelected == 0)
        {
            weapon.sprite = lighter;
        }
        if (PlayerDataController.instance.weaponSelected == 1)
        {
            weapon.sprite = lantern;
        }
        if (PlayerDataController.instance.weaponSelected == 2)
        {
            weapon.sprite = cookbook;
        }
        if (PlayerDataController.instance.weaponSelected == 3)
        {
            weapon.sprite = mercury;
        }
    }
}
