# Registro de Bugs — Monitoreo de Sensores AR Accesible
**Autor:** Peralta Sandoval, Isaac Josue
**Fecha:** 15 de Julio de 2026

---

## BUG-001: Subtítulos XR aparecen invertidos (rotados de cabeza) en el espacio tridimensional

| Campo | Valor |
|-------|-------|
| ID | BUG-001 |
| Reportado por | Peralta Sandoval, Isaac Josue |
| Fecha | 15 de Julio de 2026 |
| TC relacionado | TC-003 / TC-004 |
| Severidad | MAYOR |
| Prioridad | P2 |
| Estado | ABIERTO |

**Resumen en una línea:**
El Canvas de subtítulos configurado en World Space calcula su rotación de manera inversa, lo que provoca que el texto se renderice de cabeza (rotación invertida en el eje Z/Y), impidiendo su lectura al operario.

**Pasos para reproducir:**
1. Iniciar el modo Play en el editor de Unity.
2. Presionar la tecla **S** para forzar el despliegue del subtítulo de prueba.
3. Observar la orientación del texto respecto a la cámara principal.

**Resultado esperado:**
El texto del subtítulo debe aparecer horizontal, perfectamente legible de izquierda a derecha y orientado de frente al punto de vista de la cámara.

**Resultado actual:**
El texto del Canvas se renderiza rotado 180 grados, mostrándose invertido vertical y horizontalmente respecto al horizonte visual del usuario.

**Error en Console (si existe):**

**Severidad justificada:**
Es un bug de severidad **MAYOR** de accesibilidad porque anula completamente la utilidad de la característica implementada para personas con hipoacusia. Aunque la aplicación no experimenta cierres inesperados ("crashes"), la función de subtítulos queda completamente inutilizable para el usuario final.

**Causa raíz (si conocida):**
El método `Quaternion.LookRotation` en el script `SubtitulosXR.cs` calcula la dirección desde el panel hacia la cámara. Dependiendo de los ejes de diseño del Canvas de Unity, el vector forward resultante puede ocasionar que el Canvas mire en la dirección opuesta ("backwards"), obligando al motor a renderizarlo de espaldas al espectador.