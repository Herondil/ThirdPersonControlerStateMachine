using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    //membres utilis�s par la classe, devraient �tre private
    public Vector2              m_move;
    public CharacterController  m_characterController;
    public float                m_speed;

    //membres publics utilis�s pour contr�ler le mouvement
    public bool AllowMovement;
    public bool AllowRotation;

    //les param�tres de configuration du joueur
    public PlayerSettings Settings;

    private void Awake()
    {
        m_speed = Settings.jogSpeed;
    }

    void Update()
    {
        if (AllowMovement)
        {
            m_characterController.Move(new Vector3(m_move.x * m_speed * Time.deltaTime, 0f, m_move.y * m_speed * Time.deltaTime));
        }
        if(AllowRotation)
        {
            Quaternion q = Quaternion.LookRotation(new Vector3(m_move.y, 0f, m_move.x), Vector3.up);
            gameObject.transform.parent.transform.rotation = q;
        }
    }

    //public car utilis� par l'instance de PlayerInput
    public void ReadDirFromInput(InputAction.CallbackContext context)
    {
        m_move = context.ReadValue<Vector2>();
    }

    //On peut imaginer des m�thodes publiques pour configurer le mouvement en g�n�ral, par exemple pour changer de vitesse
    public void ChangeSpeed()
    {

    }

    //
}
