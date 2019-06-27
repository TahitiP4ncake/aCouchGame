using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body {
    public bool leftHand;
    public bool rightHand;
    public bool leftFoot;
    public bool rightFoot;
    public bool butt;
    public bool head;

    public GameObject leftHandImage;
    public GameObject rightHandImage;
    public GameObject leftFootImage;
    public GameObject rightFootImage;
    public GameObject buttImage;
    public GameObject headImage;

    public Cushion ToCushion () {
        return new Cushion (
            (leftHand ? 0 : 1) + (rightHand ? 0 : 1),
            (leftFoot ? 0 : 1) + (rightFoot ? 0 : 1),
            (butt ? 0 : 1),
            (head ? 0 : 1)
        );
    }

    public void ToggleLeftHand () {
        leftHand = !leftHand;
        leftHandImage.SetActive(!leftHandImage.activeSelf);
    }

    public void ToggleRightHand () {
        rightHand = !rightHand;
        rightHandImage.SetActive(!rightHandImage.activeSelf);
    }

    public void ToggleLeftFoot () {
        leftFoot = !leftFoot;
        leftFootImage.SetActive(!leftFootImage.activeSelf);
    }

    public void ToggleRightFoot () {
        rightFoot = !rightFoot;
        rightFootImage.SetActive(!rightFootImage.activeSelf);
    }

    public void ToggleButt () {
        butt = !butt;
        buttImage.SetActive(!buttImage.activeSelf);
    }
    
    public void ToggleHead () {
        head = !head;
        headImage.SetActive(!headImage.activeSelf);
    }
}