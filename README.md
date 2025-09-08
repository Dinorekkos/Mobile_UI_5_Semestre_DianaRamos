# Mobile UI 5 Semestre Diana Ramos
Este es un proyecto en unity de cómo contruir la UI de forma correcta y responsiva dee un juego mobile.

## Instrucciones
- Entrar a la escena "Mobile UI Example".
- Seleccionar el objeto "UI_Manager". en la jerarquía. Dentro de este objeto se encuentra el script "UI_Manager". que contiene las UIs del juego.


## UI Manager.cs
Este script contiene las referencias a los diferentes paneles de la UI del juego. Esta clase se encarga de mostrar y ocultar los diferentes paneles de la UI según sea necesario.

### Métodos Principales:
-  ShowUI(string windowID) : Muestra la ventana de la UI correspondiente al ID.
-  HideUI(string windowID) : Oculta la ventana de la UI correspondiente al ID.
-  HideAllUI() : Oculta todas las ventanas de la UI.
-  GetWindow(string windowID) : Devuelve la ventana de la UI correspondiente al ID.

## UI Window
Esta clase es una clase base para todas las ventanas de la UI del juego. Contiene métodos para mostrar y ocultar la ventana, así como para inicializarla.




