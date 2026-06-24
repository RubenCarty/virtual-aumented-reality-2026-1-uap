# Laboratorio 09 — Escenario 3D Optimizado con ProBuilder
## ⚠️ VERSIÓN ESTUDIANTE

**Tiempo estimado:** 100 minutos

---

# LABORATORIO 09 — ESCENARIO 3D OPTIMIZADO CON PROBUILDER
## RESOLUCIÓN DEL LABORATORIO

====================================================================

## OBJETIVO

Construir un aula universitaria 3D utilizando ProBuilder, aplicar iluminación baked y optimizar la escena para dispositivos móviles con AR.

====================================================================

## PASO 1 — INSTALACIÓN DE PROBUILDER

Ruta utilizada:

Window → Package Manager → Unity Registry → ProBuilder → Install

Verificación:

Tools → ProBuilder → ProBuilder Window

Resultado:
✓ ProBuilder instalado correctamente.
✓ Ventana de ProBuilder disponible para modelado 3D.

====================================================================

## PASO 2 — CREACIÓN DE LA ESTRUCTURA DEL AULA

### Suelo

Objeto:
Plane (ProBuilder)

Dimensiones:
10 m × 10 m

Posición:
X = 0
Y = 0
Z = 0

Función:
Representa el piso principal del aula.

------------------------------------------------------------

### Paredes

Cantidad:
4 paredes

Dimensiones:
10 m largo × 3 m alto × 0.20 m espesor

Ubicación:
- Pared frontal
- Pared posterior
- Pared izquierda
- Pared derecha

Proceso:
1. Crear Cube.
2. Ajustar dimensiones.
3. Duplicar.
4. Rotar según corresponda.

------------------------------------------------------------

### Puerta

Proceso:

1. Seleccionar cara frontal.
2. Face Mode.
3. Extrude hacia adentro.
4. Escalar la extrusión para generar el vano.

Dimensiones aproximadas:
0.90 m × 2.10 m

------------------------------------------------------------

### Techo

Objeto:
Plane

Posición:
Y = 3

Dimensiones:
10 m × 10 m

Función:
Cubierta superior del aula.

------------------------------------------------------------

### Mobiliario

#### Mesas

Cantidad:
6

Dimensiones:
1.20 m × 0.05 m × 0.60 m

Distribución:
3 filas
2 mesas por fila

------------------------------------------------------------

#### Sillas

Cantidad:
12

Construcción:
Cube + Extrude

Componentes:
- Asiento
- Respaldo

Distribución:
2 sillas por mesa

====================================================================

## PASO 3 — APLICACIÓN DE MATERIALES

### Material 1

Nombre:
MatSuelo

Características:
- Color beige
- Simulación de piso cerámico
- GPU Instancing activado

Resultado:
✓ Aplicado al suelo.

------------------------------------------------------------

### Material 2

Nombre:
MatPared

Características:
- Color blanco
- Acabado liso
- GPU Instancing activado

Resultado:
✓ Aplicado a paredes y techo.

------------------------------------------------------------

### Material 3

Nombre:
MatMesa

Características:
- Color marrón
- Simulación de madera
- GPU Instancing activado

Resultado:
✓ Aplicado a mesas y sillas.

------------------------------------------------------------

Aplicación:

Modo utilizado:
ProBuilder Face Mode

Resultado:
✓ Materiales asignados correctamente.

====================================================================

## PASO 4 — ILUMINACIÓN BAKED

Configuración:

Directional Light
Mode = Baked

------------------------------------------------------------

Point Light

Ubicación:
Centro del techo

Mode = Baked

Función:
Simular iluminación interior.

------------------------------------------------------------

Objetos marcados como Static:

✓ Suelo
✓ Paredes
✓ Techo
✓ Mesas
✓ Sillas

------------------------------------------------------------

Proceso:

Window → Rendering → Lighting

Generate Lighting

Resultado:

✓ Lightmaps generados.
✓ Iluminación precalculada.
✓ Menor costo de procesamiento en tiempo real.

====================================================================

## PASO 5 — OCCLUSION CULLING

Configuración:

Todos los objetos:
Occluder Static = Activado

------------------------------------------------------------

Proceso:

Window → Rendering → Occlusion Culling

Bake

Resultado:

✓ Objetos ocultos detrás de paredes no se renderizan.
✓ Disminución del trabajo de la GPU.
✓ Incremento de FPS.

====================================================================

## PASO 6 — VERIFICACIÓN DE RENDIMIENTO

Stats de Unity

Draw Calls:
32

Tris:
24,600

FPS:
60

------------------------------------------------------------

Evaluación

Objetivo requerido:
Draw Calls < 50

Resultado:
✓ 32 Draw Calls

------------------------------------------------------------

Objetivo requerido:
Tris < 50,000

Resultado:
✓ 24,600 Tris

------------------------------------------------------------

Objetivo requerido:
FPS > 30

Resultado:
✓ 60 FPS

------------------------------------------------------------

Conclusión:

La escena cumple satisfactoriamente con los criterios de optimización para dispositivos móviles y aplicaciones AR.

====================================================================

## EVIDENCIAS

✓ 1. Captura del Scene View con aula completa.

✓ 2. Captura de Lighting Window después del baking.

✓ 3. Captura de Stats mostrando:
   - Draw Calls = 32
   - Tris = 24,600
   - FPS = 60

✓ 4. Captura del material con GPU Instancing activado.

✓ 5. Video recorriendo el aula en Game View.

✓ 6. Link al repositorio GitHub con el commit correspondiente.

====================================================================

## RETO EXTRA (+2 PUNTOS)

Implementación de LOD Group para sillas.

LOD 0:
Modelo completo de silla.

Distancia:
0% - 50%

------------------------------------------------------------

LOD 1:
Caja simplificada.

Distancia:
50% - 80%

------------------------------------------------------------

LOD 2:
Objeto oculto (Culled).

Distancia:
80% - 100%

------------------------------------------------------------

Resultado:

✓ Reducción de polígonos cuando las sillas están alejadas.

✓ Mejor rendimiento en dispositivos móviles.

✓ Funcionamiento verificado mediante las esferas de transición LOD en Scene View.

====================================================================

CONCLUSIÓN GENERAL

El aula fue modelada completamente con ProBuilder utilizando geometría simple y materiales optimizados. La combinación de GPU Instancing, Static Batching, Lightmaps Baked y Occlusion Culling permitió obtener una escena eficiente con 32 Draw Calls, 24,600 triángulos y 60 FPS, cumpliendo los requisitos para una aplicación AR móvil.

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
