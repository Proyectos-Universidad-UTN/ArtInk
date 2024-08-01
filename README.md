# ArtInk
Centro de tatuajes y piercing 


# SonarCloud 
[ArtInk project](`https://sonarcloud.io/organizations/proyectos-universidad-utn/projects`)
- Solo evalua la rama `main`
- Se ejecuta cada vez que hay cambios en el main(Pull request)
- Se excluyen validaciones para archivos en folder `migrations`, `*.css`, `*.sql`, `*css` y cualquier archivo relacionado que se considere DTO
- Dado que proforma y factura origina casi el mismo proceso se agrega como excepción la facturación en el control de duplicados
- Se exceptan las vistas parciales
- Se separan los procesos referentes a los tag helps for de los labels
- Se ignoran los edit.cshhtml y create.cshtml
- Se excluye validaciones de required en los response y todo lo incluido en misc 