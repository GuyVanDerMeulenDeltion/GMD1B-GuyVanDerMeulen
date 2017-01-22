using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameManager : MonoBehaviour {

    [Header("Player Settings")]

    [Range(1.0f, 50f)]
    [Tooltip("Changes the speed to look around with")]
    public float mouseSensitivity;

    [Range(1.0f, 50f)]
    [Tooltip("Changes the speed that you use while running")]
    public float sprintingSpeed;

    [Range(1.0f, 25f)]
    [Tooltip("Changes the speed when ur player is walking")]
    public float walkingSpeed;

    [Range(1.0f, 100f)]
    [Tooltip("The speed your character is falling at")]
    public float gravity;

    [Range(1.0f, 100f)]
    [Tooltip("As the name implies, its used as a force to get off the ground with")]
    public float jumpForce;

    [Tooltip("Sets the max amount of Jumps before u need to be grounded again")]
    public int maxJumps;
}