# 📖 Guía para el Estudiante — Cómo usar este repositorio

## Realidad Virtual y Aumentada | PSISP08075 | 2026-1

---

## ¿Para qué sirve este repositorio?

Este es el repositorio oficial del curso. Aquí encontrarás:
- ✅ Guías de trabajo semanales (para completar)
- ✅ Guías de laboratorio (para desarrollar en Unity)
- ✅ Materiales de cada sesión de clase
- ✅ Plantillas de entrega
- ✅ Recursos y referencias del curso

---

## PASO 1 — Crear una cuenta en GitHub

1. Ir a https://github.com
2. Clic en **Sign up**
3. Usar tu correo universitario: `xxxx@autonoma.edu.pe` o personal
4. Completar el registro y verificar tu correo
5. Enviar tu usuario de GitHub al docente

---

## PASO 2 — Hacer FORK del repositorio del curso

> **Fork** = hacer una copia del repositorio en tu propia cuenta de GitHub

1. Ir a: `https://github.com/RubenCarty/virtual-aumented-reality-2026-1-uap`
2. Clic en el botón **Fork** (esquina superior derecha)
3. Seleccionar tu cuenta como destino
4. Clic en **Create fork**

Ahora tienes una copia en: `https://github.com/TU-USUARIO/rva-2026-1-uap`

---

## PASO 3 — Clonar tu fork en tu computadora

```bash
# Abrir la terminal (cmd en Windows / Terminal en Mac)

# Clonar tu fork (reemplaza TU-USUARIO con tu usuario de GitHub)
git clone https://github.com/TU-USUARIO/virtual-aumented-reality-2026-1-uap.git

# Entrar a la carpeta clonada
cd virtual-aumented-reality-2026-1-uap

# Verificar que todo está bien
git status
# Debe decir: "On branch main, nothing to commit"
```

---

## PASO 4 — Mantener tu fork actualizado

El docente actualiza el repositorio cada semana. Para obtener las actualizaciones:

```bash
# Agregar el repositorio del docente como "upstream" (solo la primera vez)
git remote add upstream https://github.com/RubenCarty/rva-2026-1-uap.git

# Verificar que se agregó correctamente
git remote -v
# Debe mostrar:
#   origin    https://github.com/TU-USUARIO/virtual-aumented-reality-2026-1-uap.git (fetch)
#   upstream  https://github.com/RubenCarty/virtual-aumented-reality-2026-1-uap.git (fetch)

# Cada semana, traer las actualizaciones del docente:
git fetch upstream
git merge upstream/main
# O de forma abreviada:
git pull upstream main
```

---

## PASO 5 — Trabajar en cada semana

### Estructura de trabajo por semana:

```
Para cada semana debes:
1. Crear una rama nueva
2. Completar la guía de trabajo (GT)
3. Completar el laboratorio (LAB)
4. Hacer commit y push
5. Abrir un Pull Request (PR)
```

### Crear tu rama de trabajo:

```bash
# IMPORTANTE: Siempre trabaja en una rama, NUNCA en main directamente

# Crear rama para la semana (reemplaza CODIGO con tu código de alumno)
git checkout -b u-CODIGO-semana-01

# Ejemplo real:
git checkout -b u-20221234-semana-01
```

### Ver en qué rama estás:

```bash
git branch
# El asterisco (*) indica la rama actual
```

---

## PASO 6 — Completar y guardar tu trabajo

### Dónde guardar tus archivos:

```
entregas/
└── SEMANA-01/
    └── u-TU-CODIGO/
        ├── GT01_completado.md        ← Guía de trabajo completada
        ├── LAB01_completado.md       ← Laboratorio completado
        └── capturas/                 ← Capturas de pantalla de Unity
            ├── escena_final.png
            └── stats_fps.png
```

### Guardar cambios con Git:

```bash
# 1. Ver qué archivos cambiaste
git status

# 2. Agregar tus archivos al commit
git add entregas/SEMANA-01/u-TU-CODIGO/

# 3. Crear el commit con mensaje descriptivo
git commit -m "S01 GT01 y LAB01 completados - Juan Pérez (20221234)"

# 4. Subir tu rama a GitHub
git push origin u-CODIGO-semana-01
```
---
## PASO 7 — Abrir un Pull Request (PR)

> **Pull Request** = solicitar al docente que revise tu trabajo

1. Ir a tu fork en GitHub: `https://github.com/TU-USUARIO/virtual-aumented-reality-2026-1-uap`
2. Verás un mensaje: *"Your branch has recent pushes"* → Clic en **Compare & pull request**
3. Completar el formulario:
   - **Título:** `[S01] GT01 y LAB01 - Juan Pérez`
   - **Descripción:** Usar la plantilla (se carga automáticamente)
4. Clic en **Create pull request**
5. El docente revisará y aprobará (o pedirá correcciones)

---

## Flujo semanal resumido

```
Cada semana:

1. git pull upstream main          # Actualizar con materiales del docente
2. git checkout -b u-CODIGO-semana-XX   # Nueva rama
3. Completar GT y LAB en entregas/
4. git add . && git commit -m "..."
5. git push origin u-CODIGO-semana-XX
6. Abrir Pull Request en GitHub
```

---

## Comandos Git de referencia rápida

| Comando | Qué hace |
|---------|----------|
| `git status` | Ver archivos modificados y rama actual |
| `git branch` | Listar ramas / ver en cuál estás |
| `git checkout -b nombre` | Crear y cambiar a nueva rama |
| `git add archivo` | Agregar archivo al próximo commit |
| `git add .` | Agregar TODOS los archivos modificados |
| `git commit -m "mensaje"` | Guardar cambios con descripción |
| `git push origin rama` | Subir rama a GitHub |
| `git pull upstream main` | Traer actualizaciones del docente |
| `git log --oneline` | Ver historial de commits |
| `git diff` | Ver qué cambió en los archivos |

---

## ❗ Reglas importantes

1. **NUNCA** trabajes directamente en `main` — siempre crea una rama
2. **Un PR por semana** — una rama por semana
3. **Commits descriptivos** — incluye tu nombre y el número de semana
4. **No modificar** archivos de sesión, guías o laboratorios del docente
5. **Solo modificar** archivos en la carpeta `entregas/`
6. **Plazo:** Cada PR debe abrirse antes del inicio de la siguiente sesión

---

## 🆘 ¿Problemas con Git?

```bash
# Descarté mis cambios accidentalmente:
git checkout -- archivo.md

# Me equivoqué de rama:
git stash                    # Guardar cambios temporalmente
git checkout -b rama-correcta
git stash pop                # Restaurar cambios

# Necesito ver el historial:
git log --oneline --graph

# Conflictos al hacer pull:
git pull upstream main       # Si hay conflicto, editar el archivo
git add archivo_resuelto.md
git commit -m "Resolver conflicto"
```

---
##  ¿Qué significa `feat:` en commits?

Es el estándar **Conventional Commits** — un sistema de etiquetas para que los commits sean legibles por humanos Y máquinas:

```
tipo(alcance): descripción corta
   │      │          │
   │      │          └── qué se hizo (imperativo, presente)
   │      └──────────── área del código (opcional)
   └─────────────────── tipo de cambio
```

| Tipo       | Significa     | Cuándo usarlo                          |     |
| ---------- | ------------- | -------------------------------------- | --- |
| `feat`     | Feature nueva | Agregar nuevo contenido, funcionalidad |     |
| `fix`      | Corrección    | Arreglar un error en el contenido      |     |
| `docs`     | Documentación | README, guías, comentarios             |     |
| `chore`    | Mantenimiento | Cambios de configuración, .gitignore   |     |
| `refactor` | Reestructurar | Mover archivos sin cambiar contenido   |     |
| `test`     | Pruebas       | Agregar tests o verificaciones         |     |

## El flujo correcto (siempre este orden)

```bash
# PASO 1 — Ver qué hay en remoto SIN traerlo aún
git fetch origin

# PASO 2 — Ver la diferencia: ¿cuántos commits tienes atrás?
git status
# Output: "Your branch is behind 'origin/main' by 3 commits"

# PASO 3 — Traer los cambios del remoto a tu local
git pull origin main

# PASO 4 — Ahora sí hacer tu trabajo local
# (editar archivos, agregar contenido, etc.)

# PASO 5 — Registrar tus cambios
git add .
git commit -m "feat(s02): agregar sesion semana 2"

# PASO 6 — Subir al remoto
git push origin main
```



*¿Dudas? Consultar al docente o abrir un Issue en el repositorio.*
