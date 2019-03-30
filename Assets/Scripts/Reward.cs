using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reward : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI reward;
    int chaos;

    // Use this for initialization
    void Start()
    {
        chaos = Random.Range(1, 14);
        reward.text = chaos.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
