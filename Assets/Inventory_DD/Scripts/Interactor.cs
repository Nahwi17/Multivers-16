using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] public float _interactionPointRadius = 2f;
    [SerializeField] private LayerMask _interactableMask;

    //===== UI TEXT =====
    //[SerializeField] private InteractionPromptUI _interactionPromptUI;
    //===== UI TEXT =====

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    private void Update()
    {
        //Ambil berapa banyak Collider dan Object tersebut
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
         _interactableMask);

        //Validasi ketika InteractionPoint dapet 2 Object yang Interactable
        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();


            //===== UI TEXT =====
            if (_interactable != null)
            {
                //if (!_interactionPromptUI.isDisplay)
                //{
                //    //_interactionPromptUI.SetUp(_interactable.InteractionPrompt, this, _interactable);
                //    _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                //}
            }
            //===== UI TEXT =====

            if (_interactable != null && Keyboard.current.fKey.wasPressedThisFrame)
            {
                _interactable.Interact(this);
            }
        }
        //===== UI TEXT =====
        else
        {
            if (_interactable != null)
            {
                _interactable = null;
            }

            //if (_interactionPromptUI.isDisplay)
            //{
            //    _interactionPromptUI.Close();
            //}
        }
        //===== UI TEXT =====
    }


    //Draw Line Only
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

}
