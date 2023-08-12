using System.Collections;
using UnityEngine;

public class rockets : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float rocketHeight = 20f;
    public float dropInterval = 2f;

    private void Start()
    {
        StartCoroutine(DropRockets());
    }

    private IEnumerator DropRockets()
    {
        // Find the RandomMovingCircle script on the same GameObject
        RandomMovingCircle movingCircleScript = GetComponent<RandomMovingCircle>();

        if (movingCircleScript == null)
        {
            Debug.LogError("RandomMovingCircle script not found on the same GameObject.");
            yield break;
        }

        while (true)
        {
            if (movingCircleScript.isMiddleSeconds)
            {

                Vector3 spawnPosition1 = transform.position + Vector3.up * rocketHeight + Vector3.back * 10f;
                Vector3 spawnPosition2 = transform.position + Vector3.up * rocketHeight + Vector3.back * 7f;
                Vector3 spawnPosition3 = transform.position + Vector3.up * rocketHeight + Vector3.back * 3f;

                Vector3 spawnPosition99 = transform.position + Vector3.up * rocketHeight + Vector3.back * 7f+ Vector3.left * 3f;
                Vector3 spawnPosition98= transform.position + Vector3.up * rocketHeight + Vector3.back * 5f + Vector3.left * 4f;
                Vector3 spawnPosition97= transform.position + Vector3.up * rocketHeight + Vector3.back * 3f + Vector3.left * 5f;

                Vector3 spawnPosition96 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 7f + Vector3.left * 3f;
                Vector3 spawnPosition95 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 5f + Vector3.left * 4f;
                Vector3 spawnPosition94 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 3f + Vector3.left * 5f;

                Vector3 spawnPosition93 = transform.position + Vector3.up * rocketHeight + Vector3.back * 7f + Vector3.right * 3f;
                Vector3 spawnPosition92 = transform.position + Vector3.up * rocketHeight + Vector3.back * 5f + Vector3.right * 4f;
                Vector3 spawnPosition91 = transform.position + Vector3.up * rocketHeight + Vector3.back * 3f + Vector3.right * 5f;

                Vector3 spawnPosition90 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 7f + Vector3.right * 3f;
                Vector3 spawnPosition89 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 5f + Vector3.right * 4f;
                Vector3 spawnPosition88 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 3f + Vector3.right * 5f;

                Vector3 spawnPosition4 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 10f;
                Vector3 spawnPosition5 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 7f;
                Vector3 spawnPosition6 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 3f;


                Vector3 spawnPosition7 = transform.position + Vector3.up * rocketHeight + Vector3.left * 6.5f;
                Vector3 spawnPosition8 = transform.position + Vector3.up * rocketHeight + Vector3.left * 5f;
                Vector3 spawnPosition9 = transform.position + Vector3.up * rocketHeight + Vector3.left * 3f;

                Vector3 spawnPosition10 = transform.position + Vector3.up * rocketHeight + Vector3.right * 6.5f;
                Vector3 spawnPosition11 = transform.position + Vector3.up * rocketHeight + Vector3.right * 5f;
                Vector3 spawnPosition12 = transform.position + Vector3.up * rocketHeight + Vector3.right * 3f;


                GameObject newRocket7 = Instantiate(rocketPrefab, spawnPosition7, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket98 = Instantiate(rocketPrefab, spawnPosition98, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket2 = Instantiate(rocketPrefab, spawnPosition2, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket91 = Instantiate(rocketPrefab, spawnPosition91, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket4 = Instantiate(rocketPrefab, spawnPosition4, Quaternion.Euler(180f, 0f, 0f));
                yield return new WaitForSeconds(0.7f);
                GameObject newRocket89 = Instantiate(rocketPrefab, spawnPosition89, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket90 = Instantiate(rocketPrefab, spawnPosition90, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket12 = Instantiate(rocketPrefab, spawnPosition12, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket94 = Instantiate(rocketPrefab, spawnPosition94, Quaternion.Euler(180f, 0f, 0f));
                yield return new WaitForSeconds(0.7f);
                GameObject newRocket99 = Instantiate(rocketPrefab, spawnPosition99, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket8 = Instantiate(rocketPrefab, spawnPosition8, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket93 = Instantiate(rocketPrefab, spawnPosition93, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket95 = Instantiate(rocketPrefab, spawnPosition95, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket1 = Instantiate(rocketPrefab, spawnPosition1, Quaternion.Euler(180f, 0f, 0f));
                yield return new WaitForSeconds(0.7f);
                GameObject newRocket96 = Instantiate(rocketPrefab, spawnPosition96, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket9 = Instantiate(rocketPrefab, spawnPosition9, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket11 = Instantiate(rocketPrefab, spawnPosition11, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket6 = Instantiate(rocketPrefab, spawnPosition6, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket88 = Instantiate(rocketPrefab, spawnPosition88, Quaternion.Euler(180f, 0f, 0f));
                yield return new WaitForSeconds(0.7f);
                GameObject newRocket5 = Instantiate(rocketPrefab, spawnPosition5, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket92 = Instantiate(rocketPrefab, spawnPosition92, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket3 = Instantiate(rocketPrefab, spawnPosition3, Quaternion.Euler(180f, 0f, 0f));
                GameObject newRocket10 = Instantiate(rocketPrefab, spawnPosition10, Quaternion.Euler(180f, 0f, 0f));




                //Vector3 spawnPosition1 = transform.position + Vector3.up * rocketHeight;
                //Vector3 spawnPosition2 = transform.position + Vector3.up * rocketHeight + Vector3.right * 6f;
                //Vector3 spawnPosition3 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 4f;
                //Vector3 spawnPosition4 = transform.position + Vector3.up * rocketHeight + Vector3.left * 5f + Vector3.forward * 4f;
                //Vector3 spawnPosition5 = transform.position + Vector3.up * rocketHeight + Vector3.back * 6f;
                //Vector3 spawnPosition7 = transform.position + Vector3.up * rocketHeight + Vector3.back * 7f;
                //Vector3 spawnPosition6 = transform.position + Vector3.up * rocketHeight + Vector3.right * 3f + Vector3.forward * 4f;
                //Vector3 spawnPosition8 = transform.position + Vector3.up * rocketHeight + Vector3.right * 3f + Vector3.forward * 4f;
                //Vector3 spawnPosition9 = transform.position + Vector3.up * rocketHeight + Vector3.left * 8f;
                //Vector3 spawnPosition11 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 8f;
                //Vector3 spawnPosition98 = transform.position + Vector3.up * rocketHeight + Vector3.left * 5f;
                //Vector3 spawnPosition99 = transform.position + Vector3.up * rocketHeight + Vector3.right * 8f;
                //Vector3 spawnPosition999= transform.position + Vector3.up * rocketHeight + Vector3.right * 7f+ Vector3.forward * 5f; ;

                //Vector3 spawnPosition88 = transform.position + Vector3.up * rocketHeight + Vector3.back * 8f;
                //Vector3 spawnPosition77 = transform.position + Vector3.up * rocketHeight + Vector3.right * 7f;
                //Vector3 spawnPosition888 = transform.position + Vector3.up * rocketHeight + Vector3.left * 6f + Vector3.forward * 6f;
                //Vector3 spawnPosition33 = transform.position + Vector3.up * rocketHeight + Vector3.back * 5f + Vector3.right * 3f;
                //Vector3 spawnPosition44 = transform.position + Vector3.up * rocketHeight + Vector3.left * 7f + Vector3.back * 4f;


                //Vector3 spawnPosition19 = transform.position + Vector3.up * rocketHeight + Vector3.left * 3f;
                //Vector3 spawnPosition17 = transform.position + Vector3.up * rocketHeight + Vector3.right * 7f + Vector3.back * 2f;
                //Vector3 spawnPosition18 = transform.position + Vector3.up * rocketHeight + Vector3.forward * 8f;
                //Vector3 spawnPosition16 = transform.position + Vector3.up * rocketHeight + Vector3.left * 2f + Vector3.back * 7f;


                //GameObject newRocket1 = Instantiate(rocketPrefab, spawnPosition1, Quaternion.Euler(180f, 0f, 0f));

                //GameObject newRocket6 = Instantiate(rocketPrefab, spawnPosition16, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket44 = Instantiate(rocketPrefab, spawnPosition8, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket77 = Instantiate(rocketPrefab, spawnPosition9, Quaternion.Euler(180f, 0f, 0f));

                //GameObject newRocket4 = Instantiate(rocketPrefab, spawnPosition4, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket98 = Instantiate(rocketPrefab, spawnPosition17, Quaternion.Euler(180f, 0f, 0f));
                //yield return new WaitForSeconds(0.6f);
                //GameObject newRocket5 = Instantiate(rocketPrefab, spawnPosition5, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket2 = Instantiate(rocketPrefab, spawnPosition2, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket99 = Instantiate(rocketPrefab, spawnPosition4, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket888 = Instantiate(rocketPrefab, spawnPosition6, Quaternion.Euler(180f, 0f, 0f));

                //yield return new WaitForSeconds(0.3f);
                //GameObject newRocket7 = Instantiate(rocketPrefab, spawnPosition99, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket9 = Instantiate(rocketPrefab, spawnPosition7, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket11 = Instantiate(rocketPrefab, spawnPosition19, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket88 = Instantiate(rocketPrefab, spawnPosition6, Quaternion.Euler(180f, 0f, 0f));


                //yield return new WaitForSeconds(0.3f);
                //GameObject newRocket8 = Instantiate(rocketPrefab, spawnPosition88, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket3 = Instantiate(rocketPrefab, spawnPosition16, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket999 = Instantiate(rocketPrefab, spawnPosition98, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket33 = Instantiate(rocketPrefab, spawnPosition888, Quaternion.Euler(180f, 0f, 0f));
                //yield return new WaitForSeconds(0.3f);
                //GameObject newRocket9999 = Instantiate(rocketPrefab, spawnPosition33, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket333 = Instantiate(rocketPrefab, spawnPosition44, Quaternion.Euler(180f, 0f, 0f));
                //GameObject newRocket3333 = Instantiate(rocketPrefab, spawnPosition11, Quaternion.Euler(180f, 0f, 0f));


            }

            yield return new WaitForSeconds(dropInterval);
        }
    }
}
