using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {


    private GameObject gameManager;

    public GameObject cursor;

    public Camera cam;

    private GameManager gameOptions;

    public Ray ray;

    public RaycastHit targetHit;

    public Text actionReady;

    public string talkReady;
    public string talkNull;

    public List<string> npcTags = new List<string>();

    public Vector3 mouseLocation;

    public int textSkip;
    public int tagNumber;

    public List<string> conversationNpc = new List <string>();

    public void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();

    }

    public void Update() {

            mouseLocation = Input.mousePosition;
            cursor.transform.position = mouseLocation;
            ray = cam.ScreenPointToRay(mouseLocation);

            if(Physics.Raycast(ray, out targetHit)) {
            if (targetHit.transform.gameObject.tag.Contains(npcTags[tagNumber])) {
                actionReady.text = talkReady;
            } else if (targetHit.transform.gameObject.tag.Contains(npcTags[tagNumber])) {
                actionReady.text = talkNull;
            }
              if (Input.GetButtonDown("Fire1")) {
              gameOptions.isTalking = true;
            }
        }
    }
}
