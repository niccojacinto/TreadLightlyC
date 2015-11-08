using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class World : MonoBehaviour {

    Player player;
    TLUI gameUI;


    void Awake() {
        player = GameObject.Find("/FPSController/FirstPersonCharacter").GetComponent<Player>();
        gameUI = new TLUI(GameObject.Find("/Canvas/Hint").GetComponent<Text>(),
                          GameObject.Find("/Canvas/Subtitles").GetComponent<Text>(),
                          GameObject.Find("/Canvas/BlackScreen").GetComponent<Animator>());
    }
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        // Subtitles("Huh? Where am I?");
        // Hint("Press [E] to open Door");
        // gameUI.FadeInB();
    
	}

	void Update () {

       /*
       if (Time.timeSinceLevelLoad > 5 && Time.timeSinceLevelLoad < 10) {
            Subtitles("Huh?... what am I doing here");
       } else if (Time.timeSinceLevelLoad > 15 && Time.timeSinceLevelLoad < 20) {
            Subtitles("Those pesky programmers must be at it again..");
       } else {
            Subtitles("");
        }
       */

	
	}

    void FixedUpdate() {
        if (player.CheckRay() != null) {
            switch (player.CheckRay().gameObject.tag) {
                case "Item":
                    gameUI.Hint("Press [E] to pickup Item");
                    break;
                default:
                    gameUI.Hint("");
                    break;
            }
        }
    }

    void Subtitles(string text) {
        gameUI.Subtitles(text);
    }

    void Hint(string text) {
        gameUI.Hint(text);
    }
}
