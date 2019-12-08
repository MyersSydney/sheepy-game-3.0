using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PurePower;
using TMPro;


public class Sword : MonoBehaviour
{

    [SerializeField]
    GameObject bin;

    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        bin = PurePower.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("wolf"))
        {
            if (collision.gameObject.GetComponent<Wolf>().hasSheep)
            {
                PurePower.instance.GetComponent<Bin>().AddSheep(1);
            }
            Destroy(collision.gameObject);
            print("you killed me... how dare you");
        }

            if (collision.CompareTag("shady"))
            {
                text.gameObject.SetActive(true);
                GetComponent<CameraShaker>().Appeased = true;
                text.SetText("Greetings uncivilized man... thank you for the sheep");
                 bin.GetComponent<Bin>().destroySheep();
        }

        }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("animal"))
        {
            text.gameObject.SetActive(true);
            text.SetText("Please appease our god...");
          

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
    }

}