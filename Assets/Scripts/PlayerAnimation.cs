using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    int horizontal, vertical;

    public static object Instance { get; internal set; }

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float HorizontalMovement, float VerticalMovement)
    {
        if (PlayerManager.Instance.isSprinting) { 
            HorizontalMovement = 2; 
        }
        PlayerManager.Instance.playerAnim.SetFloat(horizontal, HorizontalMovement, 0.1f, Time.deltaTime);
        PlayerManager.Instance.playerAnim.SetFloat(vertical, VerticalMovement, 0.1f, Time.deltaTime);
    }
}
