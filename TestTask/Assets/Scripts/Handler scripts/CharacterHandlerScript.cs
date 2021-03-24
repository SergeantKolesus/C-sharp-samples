using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;

public class CharacterHandlerScript : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    private CharacterMovementScript _characterMoventScript;

    public void UpdateSpeed(float speed)
    {
        _characterMoventScript.Speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterMoventScript = (CharacterMovementScript) _character.GetComponent("CharacterMovementScript");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
