using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    public GameObject player;
    public float spriteSize; // Tama�o del sprite del jugador (aj�stalo seg�n tus necesidades)

    private float yMin;
    private float yMax;
    private float xMin;

    void Start()
    {
        // Calcula los l�mites de la c�mara
        var cam = Camera.main;
        var camHeight = cam.orthographicSize;
        var camWidth = camHeight * cam.aspect;

        yMin = -camHeight + spriteSize; // L�mite inferior
        yMax = camHeight - spriteSize; // L�mite superior
        xMin = -camWidth + spriteSize; // L�mite izquierdo
    }

    void Update()
    {
        // Mant�n al jugador dentro de los l�mites
        var playerPos = player.transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, xMin, -xMin);
        playerPos.y = Mathf.Clamp(playerPos.y, yMin, yMax);
        player.transform.position = playerPos;
    }
}
