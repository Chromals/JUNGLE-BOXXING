using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListener : MonoBehaviour
{
    private CharacterController2D _character;

    [SerializeField]
    float damage;

    [SerializeField]
    bool isPercentage;

    private void Awake()
    {
        _character = GetComponentInParent<CharacterController2D>();
    }


    public void OnPunch()
    {
        _character.Punch(damage,isPercentage);
    }
}
