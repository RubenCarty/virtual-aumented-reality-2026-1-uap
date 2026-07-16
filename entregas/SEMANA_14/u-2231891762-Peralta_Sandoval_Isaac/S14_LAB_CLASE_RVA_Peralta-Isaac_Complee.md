# S14 — LABORATORIO EN CLASE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR

---

> **Laboratorio en clase — autónomo y autoexplicativo**
> **Tiempo:** 35–40 minutos
> **Modalidad:** Individual sobre el proyecto propio (labs S11-S13)
> **Objetivo:** Ejecutar el primer ciclo completo de pruebas en tu proyecto XR: crear plan, ejecutar casos de prueba, documentar un bug y crear el commit con el fix
> **Entrega:** `PLAN_PRUEBAS.md` + `BUGS.md` + commit antes de salir de clase

---

## ANTES DE EMPEZAR (2 min)

```
☐ Unity 2022.3.x abierto con tu proyecto AR (labs S11-S13)
☐ Tu proyecto puede entrar en Play sin errors críticos de compilación
☐ GitHub Desktop o terminal disponible para hacer commit al final
☐ Un archivo nuevo vacío listo para PLAN_PRUEBAS.md
```

---

## PASO 1 — CREAR EL PLAN DE PRUEBAS MÍNIMO (8 min)

En la raíz de tu proyecto Unity (misma carpeta donde está `Assets/`), crea el archivo `PLAN_PRUEBAS.md`:

```markdown
# Plan de Pruebas — [Nombre de tu Proyecto]
**Autor:** Peralta Sandoval, Isaac Josue
**Fecha:** 15/07/2026
**Versión Unity:** 2022.3.62f3
**Dispositivo target:** [ej: Android 12+, Samsung A53 o similar]
**Versión ARCore:** 5.2.2 (AR Foundation)

---

## Alcance

**En scope (qué vamos a probar):**
- [ ] Inicio de sesión AR y detección de planos
- [ ] Colocación de objetos con tap
- [ ] Gestos de escala y rotación (si implementados)
- [ ] Accesibilidad: subtítulos y/o modo daltonismo (S13)
- [ ] Rendimiento: FPS estable en dispositivo

**Fuera de scope (justificado):**
- Tests en iOS: no disponible en el equipo
- Tests de carga (app mono-usuario)
- Tests de redes (no aplica — app offline)

---

## Casos de Prueba

| TC-ID | Módulo | Descripción | Precondiciones | Pasos | Resultado Esperado | Estado |
|-------|--------|-------------|----------------|-------|-------------------|--------|
| TC-001 | ARSession | AR Session inicia correctamente | Dispositivo Android con ARCore, permiso cámara concedido, superficie texturizada | 1. Abrir app 2. Conceder permiso 3. Apuntar a superficie | ARSession.state = Tracking en < 10s. Sin errores en Console. | Pendiente |
| TC-002 | Placement | Tap coloca objeto en plano | TC-001 completado, plano detectado visible | 1. Tap en la superficie detectada | Prefab instanciado en posición del tap. Permanece fijo al mover cámara. | Pendiente |
| TC-003 | Input | Pinch escala el objeto | TC-002 completado, objeto en escena | 1. Pinch out (separar dedos) 2. Pinch in (juntar dedos) | El objeto aumenta/reduce tamaño. No excede límites de Mathf.Clamp definidos. | Pendiente |
| TC-004 | Accesibilidad | Subtítulos aparecen y desaparecen | SubtitulosXR implementado (S13) | 1. Activar evento que dispara subtítulo 2. Esperar 3 segundos | Texto visible con backing panel oscuro. Desaparece automáticamente. | Pendiente |
| TC-005 | Rendimiento | FPS ≥ 30 durante 60 segundos | Objeto colocado en escena, AR activo | 1. Abrir Stats panel (Game view → Stats) 2. Observar FPS durante 60s | FPS promedio ≥ 30. Sin picos de 0 FPS. | Pendiente |
| TC-006 | Estabilidad | No crash en 10 min de uso | Proyecto completo | 1. Usar la app continuamente 10 min con gestos variados | 0 crashes. 0 NullReferenceException en Console. | Pendiente |

---

## Criterios de Aceptación para Presentación

- 0 bugs de severidad CRÍTICA abiertos
- 0 bugs de severidad MAYOR abiertos
- TC-001 y TC-002 en estado PASA (funcionalidad core)
- FPS ≥ 30 en dispositivo físico (si disponible) o en editor
```

---

## PASO 2 — EJECUTAR LOS CASOS DE PRUEBA (15 min)

### 2.1 — Preparación

1. Presiona ▶ **Play** en Unity
2. Abre **Window → Analysis → Console** (no cerrarla durante las pruebas)
3. Abre **Game view → Stats** (clic en el botón "Stats" arriba del Game view)

### 2.2 — Ejecutar TC-001 a TC-004

Ejecuta cada caso de prueba en orden. Para cada uno:

1. Lee las precondiciones — ¿se cumplen?
2. Ejecuta los pasos exactamente como están descritos
3. Observa el resultado real
4. Actualiza el estado en `PLAN_PRUEBAS.md`:
   - **PASA** → resultado real = resultado esperado
   - **FALLA** → resultado real ≠ resultado esperado
   - **BLOQUEADO** → no se puede ejecutar porque otra cosa falló antes

```
TC-001: Estado → __________ Observaciones: ____________________________
TC-002: Estado → __________ Observaciones: ____________________________
TC-003: Estado → __________ Observaciones: ____________________________
TC-004: Estado → __________ Observaciones: ____________________________
TC-005: Estado → __________ FPS promedio observado: ________________
TC-006: Estado → __________ Crashes observados: _____ Exceptions: _____
```

### 2.3 — Capturar errores de Console

Si aparecen mensajes en Console durante las pruebas:

| Color del mensaje | Significado |
|-------------------|-------------|
| Blanco (Log) | Información — no es un error |
| Amarillo (Warning) | Advertencia — puede ser un problema potencial |
| **Rojo (Error)** | **Error — debe documentarse como bug** |

Para cada mensaje rojo:
- Clic en el mensaje → copia el texto completo del Call Stack
- Lo necesitarás para el bug report en el Paso 3

---

## PASO 3 — DOCUMENTAR EL PRIMER BUG (8 min)

### 3.1 — Crear BUGS.md

En la raíz del proyecto (junto a `PLAN_PRUEBAS.md`), crea el archivo `BUGS.md`:

```markdown
# Registro de Bugs — [Nombre del Proyecto]

---

## BUG-001: [Título corto descriptivo del bug]

| Campo | Valor |
|-------|-------|
| ID | BUG-001 |
| Reportado por | [Tu nombre] |
| Fecha | [fecha de hoy] |
| TC relacionado | TC-00X |
| Severidad | CRÍTICO / MAYOR / MENOR / COSMÉTICO |
| Prioridad | P1 / P2 / P3 / P4 |
| Estado | ABIERTO |

**Resumen en una línea:**
[Qué falla, en qué condición, con qué resultado]

**Pasos para reproducir:**
1. [Paso 1]
2. [Paso 2]
3. [Paso 3]

**Resultado esperado:**
[Qué debería pasar]

**Resultado actual:**
[Qué pasa en realidad]

**Error en Console (si existe):**
```
[Pegar aquí el mensaje de error completo con el Call Stack]
```

**Severidad justificada:**
[Por qué es CRÍTICO/MAYOR/MENOR/COSMÉTICO en el contexto de tu proyecto]

**Causa raíz (si conocida):**
[Dónde en el código está el problema]
```

### 3.2 — ¿No encontraste ningún bug?

Si todos los TC pasaron sin errores:

**Opción A:** Ejecuta TC-006 intencionalmente mal — haz la acción más extrema posible (100 taps rápidos, pinch en ángulos extremos, cubrir y descubrir la cámara rápidamente). Si algo falla, documéntalo.

**Opción B:** Introduce un bug controlado — en `GestorColocacionAR.cs`, comenta temporalmente el guard clause de hits.Count > 0, entra en Play, toca donde no hay plano → deberías ver un NullReferenceException. Documéntalo, luego descomenta para corregirlo.

**Opción C:** Reporta un bug de accesibilidad — revisa el checklist de S13: ¿algún criterio que falló? Un botón demasiado pequeño, texto sin backing panel, parpadeo excesivo — son bugs de accesibilidad válidos.

---

## PASO 4 — CORREGIR UN BUG Y HACER COMMIT (7 min)

### 4.1 — Elegir el bug a corregir en clase

Criterios para elegir cuál corregir ahora:
- Prioridad P1 o P2
- Corrección estimada < 5 minutos (para el tiempo de clase)
- Si el bug es de severidad MAYOR pero la corrección es larga, documentarlo en BUGS.md con estado "ABIERTO" y hacerlo en casa

### 4.2 — Aplicar la corrección

Ejemplo de corrección rápida — guard clause para null hits:

```csharp
// ANTES (bug):
public void AlTapEnPantalla(Vector2 pos)
{
    raycastManager.Raycast(pos, hits, TrackableType.PlaneWithinPolygon);
    Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
}

// DESPUÉS (corregido):
public void AlTapEnPantalla(Vector2 pos)
{
    if (raycastManager.Raycast(pos, hits, TrackableType.PlaneWithinPolygon)
        && hits.Count > 0)
    {
        Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
    }
}
```

### 4.3 — Verificar la corrección

1. ▶ Play
2. Re-ejecutar el caso de prueba que encontró el bug (TC-00X)
3. Verificar que el resultado actual ahora = resultado esperado
4. Actualizar en `BUGS.md`:
   - `Estado: CERRADO`
   - `Corregido en commit: [ID del commit que harás en el siguiente paso]`
5. Actualizar en `PLAN_PRUEBAS.md`:
   - El TC correspondiente: Estado `PASA`

### 4.4 — Commit con referencia al Bug ID

```bash
# Desde terminal o Git Bash en la raíz del proyecto:
git add PLAN_PRUEBAS.md BUGS.md Assets/Scripts/[ArchivoCorregido].cs
git commit -m "fix(ar-placement): [descripción breve de la corrección] — BUG-001"
git push
```

**Formato del mensaje de commit:**
```
fix(módulo): descripción de qué se corrigió — BUG-NNN

Opcional: una línea de explicación de la causa raíz
```

Ejemplos válidos:
- `fix(ar-placement): guard clause para hits vacíos en tap sin plano — BUG-001`
- `fix(subtitulos): detener corrutina anterior antes de iniciar nueva — BUG-002`
- `fix(accessibility): null check en colorManager.SiguienteModo — BUG-003`

---

## CHECKLIST DE ENTREGA

```
☐ PLAN_PRUEBAS.md creado con al menos 5 casos de prueba con todos los campos
☐ Al menos 4 casos de prueba ejecutados (estado PASA / FALLA / BLOQUEADO)
☐ BUGS.md creado con al menos 1 bug documentado en formato completo
☐ Al menos 1 bug con estado CERRADO (corregido y re-testeado)
☐ Commit con mensaje en formato convencional referenciando Bug ID
☐ Push verificado en GitHub (aparece el commit en el repositorio)
```

---

## SOLUCIÓN RÁPIDA DE PROBLEMAS

| Síntoma | Causa probable | Solución |
|---------|----------------|----------|
| TC-001 BLOQUEADO — sin plano detectado | Surface mode o iluminación | Usar mesa texturizada, iluminar bien, esperar 5-10s |
| NullReferenceException en Console al tap | hits.Count no verificado | Agregar `&& hits.Count > 0` antes de acceder a hits[0] |
| FPS < 30 en editor | Escena pesada | Desactivar sombras: Edit → Project Settings → Quality → Shadows: Disable |
| git push falla | Credenciales o remote | `git remote -v` para verificar URL, luego autenticar con GitHub Desktop |
| El archivo PLAN_PRUEBAS.md no aparece en git status | Está fuera de la carpeta del repo | Mover el archivo a la carpeta raíz del repositorio git |
| Commit mensaje rechazado por hook | Hook de Conventional Commits activo | Usar formato exacto: `tipo(scope): descripción` |

---

## ROL DEL DOCENTE

**Mientras circula, verificar:**
- ¿El estudiante creó casos de prueba con TODOS los campos requeridos (no solo descripción)?
- ¿El bug report tiene los pasos para reproducir específicos (no solo "no funciona")?
- ¿El estudiante verificó que la corrección funciona ANTES de hacer el commit?
- ¿El mensaje de commit referencia el Bug ID?

**Preguntas de andamiaje:**
- "¿Qué pasa si el usuario toca la pantalla antes de que haya planos detectados? ¿Tu app lo maneja?"
- "Si alguien más leyera tu bug report ahora mismo, ¿podría reproducir el bug sin preguntarte nada?"
- "¿Tu TC-005 (FPS) pasó? ¿Qué harías si el FPS fuera 15?"

**Cierre del lab (3 min):**
> "Guarden su trabajo. Quien no terminó: el Plan de Pruebas y el registro de bugs son la tarea de esta noche — parte del laboratorio de casa que veremos en un momento. Lo que hicieron hoy — identificar bugs en su propio proyecto — es probablemente la primera vez que hacen esto de forma sistemática. La próxima vez que hagan una app profesional, van a recordar que esto era la parte que faltaba."

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 14 | 2026-1*
