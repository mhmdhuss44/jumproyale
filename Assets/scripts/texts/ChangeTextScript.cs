using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class ChangeTextScript : MonoBehaviour
{
    private int countdownIterations = 0;
    private float countdownTimer = 30f;
    private Text textComponent;
    private bool isFlagSet = false;

    private void Start()
    {
        // Get the Text component attached to the canvas object
        textComponent = GetComponent<Text>();

        // Start the countdown
        StartCoroutine(UpdateCountdown());
    }

    private IEnumerator UpdateCountdown()
    {
        while (countdownIterations < 5)
        {
            countdownTimer--;

            // Update the text with the current countdown value
            textComponent.text = countdownTimer.ToString();

            // Check if countdown reached 0
            if (countdownTimer <= 0)
            {
                // Countdown finished, do something
                textComponent.text = "00:00";
                if (!isFlagSet)
                {
                    isFlagSet = true;
                    countdownIterations++;

                    // Find one object with the zlinertwo script and send the start moving flag
                    zlinertwo zoneScript = FindObjectOfType<zlinertwo>();
                    // Find one object with the zliner script and send the start moving flag
                    zliner zLineScript = FindObjectOfType<zliner>();

                    // Find one object with the xmover script and send the start moving flag
                    xmover xMoverScript = FindObjectOfType<xmover>();

                    // Find one object with the linemovetwo script and send the start moving flag
                    linemovetwo lineMoveScript = FindObjectOfType<linemovetwo>();

                    if (zoneScript != null)
                    {
                        zoneScript.StartMoving();
                        
                    }

                    if (xMoverScript != null)
                    {
                        xMoverScript.StartMoving();
                        
                    }

                    if (lineMoveScript != null)
                    {
                        lineMoveScript.StartMoving();
                        
                    }

                    if (zLineScript != null)
                    {
                        zLineScript.StartMoving();
                       
                    }

                    yield return new WaitForSeconds(20f);

                    // Reset the flag and restart the countdown
                    isFlagSet = false;
                    if (zoneScript != null)
                    {
                       
                        zoneScript.SetFalse();
                    }

                    if (xMoverScript != null)
                    {
                        
                        xMoverScript.SetFalse();
                    }

                    if (lineMoveScript != null)
                    {
                        
                        lineMoveScript.SetFalse();
                    }

                    if (zLineScript != null)
                    {
                        zLineScript.SetFalse();
                    }
                    countdownTimer = 30f;
                    textComponent.text = countdownTimer.ToString();
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
