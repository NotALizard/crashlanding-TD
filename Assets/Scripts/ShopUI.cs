using UnityEngine;
using System.Collections;

public class ShopUI : MonoBehaviour {
    Animator leftAnim;
    Animator topAnim;
    Animator rightAnim;
    Animator bottomAnim;
    public bool test;
    Transform leftSelect;
    Transform topSelect;
    Transform rightSelect;
    Transform bottomSelect;

	// Use this for initialization
	void Start () {
        leftAnim = transform.FindChild("LeftIcon").GetComponent<Animator>();
        topAnim = transform.FindChild("TopIcon").GetComponent<Animator>();
        rightAnim = transform.FindChild("RightIcon").GetComponent<Animator>();
        bottomAnim = transform.FindChild("BottomIcon").GetComponent<Animator>();

        leftSelect = transform.FindChild("LeftIcon").FindChild("IconSelect");
        topSelect = transform.FindChild("TopIcon").FindChild("IconSelect");
        rightSelect = transform.FindChild("RightIcon").FindChild("IconSelect");
        bottomSelect = transform.FindChild("BottomIcon").FindChild("IconSelect");
    }

    public void DisplayShop(int[] costs, int[] icons, int[] techLevels)
    {
        int playerTech = GetComponentInParent<Player>().GetTechLevel();
        if (playerTech >= techLevels[0])
        {
            leftAnim.SetInteger("id", icons[0]);
        }
        else
        {
            leftAnim.SetInteger("id", Builder.GhostSprite);
        }
        if (playerTech >= techLevels[1])
        {
            topAnim.SetInteger("id", icons[1]);
        }
        else
        {
            topAnim.SetInteger("id", Builder.GhostSprite);
        }
        if (playerTech >= techLevels[2])
        {
            rightAnim.SetInteger("id", icons[2]);
        }
        else
        {
            rightAnim.SetInteger("id", Builder.GhostSprite);
        }
        bottomAnim.SetInteger("id", icons[3]);

        SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in sprites)
        {
            s.enabled = true;
        }
    }

    public void Sleep()
    {
        SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer s in sprites){
            s.enabled = false;
        }
    }

    public void SetProgress(float percentage, bool left, bool top, bool right, bool bottom)
    {
        if (left)
        {
            leftSelect.localScale = new Vector3(leftSelect.localScale.x, percentage, leftSelect.localScale.z);
        }
        else
        {
            leftSelect.localScale = new Vector3(leftSelect.localScale.x, 0, leftSelect.localScale.z);
        }

        if (top)
        {
            topSelect.localScale = new Vector3(topSelect.localScale.x, percentage, topSelect.localScale.z);
        }
        else
        {
            topSelect.localScale = new Vector3(topSelect.localScale.x, 0, topSelect.localScale.z);
        }

        if (right)
        {
            rightSelect.localScale = new Vector3(rightSelect.localScale.x, percentage, rightSelect.localScale.z);
        }
        else
        {
            rightSelect.localScale = new Vector3(rightSelect.localScale.x, 0, rightSelect.localScale.z);
        }

        if (bottom)
        {
            bottomSelect.localScale = new Vector3(bottomSelect.localScale.x, percentage, bottomSelect.localScale.z);
        }
        else
        {
            bottomSelect.localScale = new Vector3(bottomSelect.localScale.x, 0, bottomSelect.localScale.z);
        }

    }
}
