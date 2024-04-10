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
    [SerializeField] private Sprite matches;

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
        EndDialogueController.GetInstance().dialoguePanel.SetActive(true);
    }
    private void Update()
    {
        EndDialogueController.GetInstance().dialoguePanel.SetActive(true);
    }

    //Set Character
    private void setCharacter()
    {
        if (PlayerDataController.instance.characterSelected == 0)
        {
            other_character.sprite = claye;
            EndDialogueController.GetInstance().EnterDialogueMode(clayeDialog);
        }
        if (PlayerDataController.instance.characterSelected == 1)
        {
            other_character.sprite = sadie;
            EndDialogueController.GetInstance().EnterDialogueMode(sadieDialog);
        }
        if (PlayerDataController.instance.characterSelected == 2)
        {
            other_character.sprite = frannie;
            EndDialogueController.GetInstance().EnterDialogueMode(frannieDialog);
        }
        if (PlayerDataController.instance.characterSelected == 3)
        {
            other_character.sprite = rosa;
            EndDialogueController.GetInstance().EnterDialogueMode(rosaDialog);
        }
        if (PlayerDataController.instance.characterSelected == 4)
        {
            other_character.sprite = john;
            EndDialogueController.GetInstance().EnterDialogueMode(johnDialog);
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
