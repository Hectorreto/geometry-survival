using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    public GameObject player;
    public float spriteSize; // Tamaño del sprite del jugador (ajústalo según tus necesidades)

    private float yMin;
    private float yMax;
    private float xMin;

    void Start()
    {
        // Calcula los límites de la cámara
        var cam = Camera.main;
        var camHeight = cam.orthographicSize;
        var camWidth = camHeight * cam.aspect;

        yMin = -camHeight + spriteSize; // Límite inferior
        yMax = camHeight - spriteSize; // Límite superior
        xMin = -camWidth + spriteSize; // Límite izquierdo
    }

    void Update()
    {
        // Mantén al jugador dentro de los límites
        var playerPos = player.transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, xMin, -xMin);
        playerPos.y = Mathf.Clamp(playerPos.y, yMin, yMax);
        player.transform.position = playerPos;
    }
}
