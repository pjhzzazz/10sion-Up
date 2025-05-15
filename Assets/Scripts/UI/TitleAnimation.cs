using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public class TitleAnimationTrigger : MonoBehaviour
    {
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        void OnEnable()
        {
            animator.Play("Title", 0, 0f);  // 다시 재생
        }
    }
}
