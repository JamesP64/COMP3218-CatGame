using UnityEngine;

public class TorchSetup : MonoBehaviour
{
    public AnimationClip torchClip;

    void Awake()
    {
      
        var animator = GetComponent<Animator>();
        if (animator == null)
            animator = gameObject.AddComponent<Animator>();

        
        var controller = new AnimatorOverrideController();
        var baseController = new AnimatorControllerParameter[0];

        
        RuntimeAnimatorController emptyController = new AnimatorControllerPlaceholder();
        controller.runtimeAnimatorController = emptyController;
        controller["Empty"] = torchClip;

        animator.runtimeAnimatorController = controller;

        
        if (!torchClip.isLooping)
        {
            torchClip.wrapMode = WrapMode.Loop;
        }
    }
}

public class AnimatorControllerPlaceholder : RuntimeAnimatorController { }
