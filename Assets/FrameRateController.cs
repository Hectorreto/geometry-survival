using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] private int target = 60;

    private void Awake()
    {
        Application.targetFrameRate = target;
    }
}
