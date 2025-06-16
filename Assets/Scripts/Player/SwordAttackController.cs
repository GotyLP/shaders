using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlashParameters
{
    [Header("Efecto Visual")]
    public GameObject slashEffect;
    
    [Header("Timing")]
    [Tooltip("Tiempo antes de mostrar el efecto (en segundos)")]
    public float delay = 0.2f;
    
    [Header("Seguimiento del Arma")]
    [Tooltip("El efecto sigue la posición del arma durante la animación")]
    public bool followPosition = true;
    [Tooltip("El efecto sigue la rotación del arma durante la animación")]
    public bool followRotation = true;
    [Tooltip("Duración del seguimiento (0 = toda la duración del efecto)")]
    public float followDuration = 0.5f;
    
    [Header("Offset")]
    [Tooltip("Desplazamiento desde la posición del arma")]
    public Vector3 positionOffset = Vector3.zero;
    [Tooltip("Rotación adicional del efecto")]
    public Vector3 rotationOffset = Vector3.zero;
}

public class SwordAttackController : MonoBehaviour
{
    [Header("Configuración General")]
    public List<SlashParameters> slashes;
    public Transform sword;
    
    [Header("Sistema de Ataques")]
    [Tooltip("Duración total del efecto visual")]
    public float effectDuration = 2f;
    [Tooltip("Ciclar entre diferentes ataques")]
    public bool cycleAttacks = true;

    private Animator _animator;
    private MovementInput _movementInput;
    private SlashParameters _currentSlash;
    private int currentAttack = 1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movementInput = GetComponent<MovementInput>();
        
        if (slashes.Count > 0)
        {
            VFXSelector(1);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currentSlash != null)
        {
            _animator.SetTrigger("Attack0" + currentAttack.ToString());
            
            StartCoroutine(ExecuteSlash(_currentSlash));
            
            if (cycleAttacks)
            {
                CycleToNextAttack();
            }
        }
    }

    IEnumerator ExecuteSlash(SlashParameters slashParams)
    {
        yield return new WaitForSeconds(slashParams.delay);
        
        if (sword == null || slashParams.slashEffect == null)
        {
            Debug.LogWarning("Sword Transform o Slash Effect no asignados!");
            yield break;
        }

        Vector3 spawnPosition = sword.position + sword.TransformDirection(slashParams.positionOffset);
        Quaternion spawnRotation = sword.rotation * Quaternion.Euler(slashParams.rotationOffset);
        
        GameObject vfx = Instantiate(slashParams.slashEffect, spawnPosition, spawnRotation);
        
        float followTime = slashParams.followDuration > 0 ? slashParams.followDuration : effectDuration;
        
        if (slashParams.followPosition || slashParams.followRotation)
        {
            StartCoroutine(FollowSword(vfx, slashParams, followTime));
        }
        
        Destroy(vfx, effectDuration);
    }

    IEnumerator FollowSword(GameObject vfx, SlashParameters slashParams, float duration)
    {
        float elapsedTime = 0f;
        
        while (vfx != null && elapsedTime < duration && sword != null)
        {
            // Actualizar posición si está habilitado
            if (slashParams.followPosition)
            {
                vfx.transform.position = sword.position + sword.TransformDirection(slashParams.positionOffset);
            }
            
            // Actualizar rotación si está habilitado
            if (slashParams.followRotation)
            {
                vfx.transform.rotation = sword.rotation * Quaternion.Euler(slashParams.rotationOffset);
            }
            
            elapsedTime += Time.deltaTime;
            yield return null; // Esperar un frame
        }
    }

    void VFXSelector(int index)
    {
        if (slashes.Count == 0)
        {
            Debug.LogWarning("No hay efectos de slash asignados en el inspector!");
            return;
        }
        
        // Asegurar que el índice esté en rango
        int clampedIndex = Mathf.Clamp(index, 1, slashes.Count);
        currentAttack = clampedIndex;
        _currentSlash = slashes[clampedIndex - 1];
    }
    
    void CycleToNextAttack()
    {
        int nextAttack = currentAttack + 1;
        if (nextAttack > slashes.Count)
        {
            nextAttack = 1; // Volver al primer ataque
        }
        VFXSelector(nextAttack);
    }
    
    // Función pública para cambiar manualmente el tipo de ataque
    public void SetAttackType(int attackIndex)
    {
        VFXSelector(attackIndex);
    }
}
