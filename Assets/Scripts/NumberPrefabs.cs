using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPrefabs : MonoBehaviour
{
    [SerializeField] private static GameObject number1Prefab;
    [SerializeField] private static GameObject number2Prefab;
    [SerializeField] private static GameObject number3Prefab;
    [SerializeField] private static GameObject number4Prefab;
    [SerializeField] private static GameObject number5Prefab;
    [SerializeField] private static GameObject number6Prefab;
    [SerializeField] private static GameObject number7Prefab;
    [SerializeField] private static GameObject number8Prefab;
    [SerializeField] private static GameObject number9Prefab;
    [SerializeField] private static GameObject number10Prefab;

    private GameObject[] numberPrefabs = 
    {
        number1Prefab,
        number2Prefab,
        number3Prefab,
        number4Prefab,
        number5Prefab,
        number6Prefab,
        number7Prefab,
        number8Prefab,
        number9Prefab,
        number10Prefab,
    };

    GameObject[] GetNumberPrefabs(){
        return numberPrefabs;
    }
    
}
