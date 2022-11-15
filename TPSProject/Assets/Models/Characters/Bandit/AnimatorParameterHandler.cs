using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

//Aller chercher les informations des autres components pour les "envoyer" à l'Animator
public class AnimatorParameterHandler : MonoBehaviour
{
    public Movement m_movement;
    public Animator m_animator;

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("DirZ", m_movement.m_move.x);
        m_animator.SetFloat("DirY", m_movement.m_move.y);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire triggered");
        switch (context.phase)
        {
            case InputActionPhase.Started:
                m_animator.SetBool("Rotating", true);
                break;

            //input lag ? Essayer de passer à 240 fps ?
            case InputActionPhase.Canceled:
                m_animator.SetBool("Rotating", false);
                break;
        }
    }
}
